using MimeKit;

namespace S.A.M.Helper.Email
{
    public class EmailContent
    {
        public List<MailboxAddress> To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public List<MimePart> EmbededImageAttachements { get; set; }
        public List<MimePart> Attachments { get; set; }
        public InternetAddressList Cc { get; set; } = new InternetAddressList();

        public EmailContent()
        {

        }
        public EmailContent(IEnumerable<string> to, string subject, string content, List<MimePart> attachments)
        {
            To = new List<MailboxAddress>();

            // Fix: Use the appropriate constructor for MailboxAddress
            To.AddRange(to.Select(x => new MailboxAddress(x, x)));
            Subject = subject;
            Content = content;
            Attachments = attachments;
        }
    }
}
