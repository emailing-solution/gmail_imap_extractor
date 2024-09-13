using System.Diagnostics;
using Task = System.Threading.Tasks.Task;

namespace gmail_imap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Extract_From(object sender, EventArgs e)
        {
            string host_setting = host.Text;
            if (string.IsNullOrEmpty(host_setting))
            {
                MessageBox.Show("Please enter a host", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int port_setting = int.Parse(port.Text);
            if (port_setting == 0)
            {
                MessageBox.Show("Please enter a port", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var account_settings = accounts.Text.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            if (account_settings.Length == 0)
            {
                MessageBox.Show("Please enter accounts", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Task? allTasks = null;
            try
            {
                extract_from.Enabled = false;

                var tasks = account_settings.Select(account => new Extractor(host_setting, port_setting, account).Extract_Froms()).ToList();

                allTasks = Task.WhenAll(tasks);
                await allTasks;

                MessageBox.Show("Extract completed", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception)
            {
                AggregateException exception = allTasks.Exception;
                foreach (var error in exception.InnerExceptions)
                {
                    Debug.WriteLine(error);
                }
            }
            finally
            {
                extract_from.Enabled = true;
            }
        }

        private void port_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string host_setting = host.Text;
            if (string.IsNullOrEmpty(host_setting))
            {
                MessageBox.Show("Please enter a host", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int port_setting = int.Parse(port.Text);
            if (port_setting == 0)
            {
                MessageBox.Show("Please enter a port", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var account_settings = accounts.Text.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            if (account_settings.Length == 0)
            {
                MessageBox.Show("Please enter accounts", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Task? allTasks = null;
            try
            {
                extract_bounce.Enabled = false;

                var tasks = account_settings.Select(account => new Extractor(host_setting, port_setting, account).Extract_Bounce_Emails()).ToList();

                allTasks = Task.WhenAll(tasks);
                await allTasks;

                MessageBox.Show("Extract bounce completed", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                AggregateException exception = allTasks.Exception;
                foreach (var error in exception.InnerExceptions)
                {
                    Debug.WriteLine(error);
                }
            }
            finally
            {
                extract_bounce.Enabled = true;
            }
        }
    }
}