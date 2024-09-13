using Chilkat;
using Task = System.Threading.Tasks.Task;

namespace gmail_imap
{
    internal class Extractor
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Account { get; set; }
        public string Username { get; set; }

        public Extractor(string host, int port, string account)
        {
            Host = host;
            Port = port;
            Account = account;
        }

        private Imap Connect()
        {

            Imap imap = new()
            {
                Ssl = true,
                Port = Port
            };

            bool success = imap.Connect(Host);
            if (!success)
            {
                throw new Exception(imap.LastErrorText);
            }

            return imap;
        }

        private Imap Auth()
        {
            var imap = Connect();
            var account = Account.Split(new char[] { ',', ':', ';'});
            if(account.Length != 2)
            {
                throw new Exception("Invalid account format");
            }
            
            Username = account[0].Split('@')[0];

            var success = imap.Login(account[0], account[1]);
            if (!success)
            {
                throw new Exception(imap.LastErrorText);
            }

            return imap;
        }

        public async Task Extract_Froms()
        {
            var imap = Auth();
            var success = imap.SelectMailbox("Inbox");
            if (!success)
            {
                throw new Exception(imap.LastErrorText);
            }

            var messageSet = imap.Search("ALL", true);
            if (imap.LastMethodSuccess != true)
            {
                throw new Exception(imap.LastErrorText);
            }
           
            var bundle = imap.FetchHeaders(messageSet);

            List<string> froms = new();
            for (int i = 0; i < bundle.MessageCount; i++)
            {
                var email = bundle.GetEmail(i);                
                var from = email.FromAddress;
                if(!string.IsNullOrEmpty(from))
                {
                    froms.Add(from);
                }
            }

            //disconnet
            imap.Disconnect();

            //remove duplicate 
            froms = froms.Distinct().ToList();
            if(froms.Count != 0)
            {
                await File.AppendAllTextAsync(Username + "_froms.txt", string.Join('\n', froms));
            }
        }

        public async Task Extract_Bounce_Emails()
        {
            var imap = Auth();
            var success = imap.SelectMailbox("Inbox");
            if (!success)
            {
                throw new Exception(imap.LastErrorText);
            }

            var last30days = DateTime.Now.AddDays(-30).ToString("dd-MMM-yyyy");
            var messageSet = imap.Search($"FROM \"mailer-daemon@googlemail.com\" SINCE {last30days}", true);
            if (imap.LastMethodSuccess != true)
            {
                throw new Exception(imap.LastErrorText);
            }

            var bundle = imap.FetchBundle(messageSet);
            List<string> bounces = new();

            for (int i = 0; i < bundle.MessageCount; i++)
            {
                var email = bundle.GetEmail(i);
                var from = email.FromAddress;

                if (from == "mailer-daemon@googlemail.com")
                {
                    // Check if body contains "?p=NoSuchUser"
                    if (email.Body.Contains("?p=NoSuchUser"))
                    {
                        // Extract the "X-Failed-Recipients" header
                        var failedRecipients = email.GetHeaderField("X-Failed-Recipients");
                        if (!string.IsNullOrEmpty(failedRecipients))
                        {
                            bounces.Add(failedRecipients);
                        }
                    }
                }
            }

            // Disconnect
            imap.Disconnect();

            // Remove duplicates
            bounces = bounces.Distinct().ToList();

            if (bounces.Count != 0)
            {
                await File.AppendAllTextAsync(Username + "_bounces.txt", string.Join('\n', bounces));
            }
        }
    }
}
