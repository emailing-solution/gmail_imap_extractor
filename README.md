# Gmail IMAP Extractor

This project is a C# application that uses the Chilkat library to interact with Gmail's IMAP services. It provides functionality to extract email addresses from the "From" field and identify bounced emails using specific search criteria.

## Features

- **Extract "From" Addresses**: Connects to a Gmail account, retrieves emails from the inbox, and extracts unique email addresses from the "From" field.
- **Extract Bounced Emails**: Searches for bounced emails (from `mailer-daemon@googlemail.com`) and extracts the failed recipient email addresses.
- **Multi-account Support**: Supports extracting emails from multiple Gmail accounts at once.
- **IMAP over SSL**: The application securely connects to Gmail's IMAP server using SSL.

## Requirements

- **Chilkat Library**: Chilkat .NET library for IMAP and email functionality.
- **.NET Framework**: .NET framework for running the application.
- **Gmail IMAP**: Make sure IMAP is enabled in your Gmail account settings.

## Installation

1. Install the **Chilkat .NET** library:
   - Download and install the Chilkat library from [Chilkat .NET](https://chilkatsoft.com).
   
2. Clone this repository:

    ```bash
    git clone https://github.com/emailing-solution/gmail-imap-extractor.git
    ```

3. Open the project in Visual Studio and ensure that the Chilkat library is referenced.

## Usage

1. **Host & Port Settings**: 
   - Input the IMAP host (`imap.gmail.com`) and port (`993` for SSL).
   
2. **Account Input**:
   - Enter Gmail accounts in the format: `email@example.com:password` in the `accounts` text area (one per line).

3. **Extract "From" Addresses**:
   - Click the **Extract Froms** button to start the extraction process. This will fetch all emails from the inbox and write the unique "From" email addresses to a file named `<username>_froms.txt`.

4. **Extract Bounced Emails**:
   - Click the **Extract Bounce Emails** button to start the process. The app will search for bounced emails from the last 30 days and write the failed recipient email addresses to a file named `<username>_bounces.txt`.


## Contributing

Feel free to submit pull requests or open issues for any bug fixes or enhancements.

## License

This project is licensed under the MIT License.

---

For more details on using Chilkat for IMAP, visit the official [Chilkat documentation](https://chilkatsoft.com).