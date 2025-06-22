using MailKit.Net.Smtp;
using MimeKit;
using S.A.M.Helper.Configuration;

namespace S.A.M.Helper.Email.EmailSender
{
    public class EmailSenderSerivce : IEmailSenderSerivce
    {
        private readonly ILogger Logger;
        private readonly IApplicationConfigurationService _appConfigurationService;
        //private readonly EmailConfiguration _emailConfig;
        public EmailSenderSerivce(ILoggerFactory loggerFactory, IApplicationConfigurationService appConfigurationService)
        {
            Logger = loggerFactory.CreateLogger<EmailSenderSerivce>(); ;
            _appConfigurationService = appConfigurationService;
            //_emailConfig = emailConfig;
        }

        public void SendEmail(EmailContent emailContent)
        {
            var emailMessage = CreateEmailMessage(emailContent);

            Send(emailMessage);
        }


        public async Task SendEmailAsync(EmailContent emailContent)
        {
            try
            {
                var mailMessage = CreateEmailMessage(emailContent);
                //throw new Exception("Fake!!!");
                await SendAsync(mailMessage);
            }
            catch (Exception exp)
            {
                throw;
            }
        }

        private MimeMessage CreateEmailMessage(EmailContent emailContent)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("وزارة التضامن الإجتماعي", _appConfigurationService.EmailConfiguration.From));
            emailMessage.To.AddRange(emailContent.To);
            emailMessage.Subject = emailContent.Subject;

            var bodyBuilder = new BodyBuilder { HtmlBody = emailContent.Content };

            if (emailContent.Attachments != null && emailContent.Attachments.Any())
            {
                //byte[] fileBytes;
                //foreach (var attachment in emailContent.Attachments)
                //{
                //    using (var ms = new MemoryStream())
                //    {
                //        attachment.CopyTo(ms);
                //        fileBytes = ms.ToArray();
                //    }

                //    bodyBuilder.Attachments.Add(attachment.FileName, fileBytes, ContentType.Parse("image/png"));//attachment.ContentType
                //}
                foreach (var attach in emailContent.Attachments)
                {
                    bodyBuilder.Attachments.Add(attach);

                }
            }

            if (emailContent.EmbededImageAttachements != null && emailContent.EmbededImageAttachements.Any())
            {
                foreach (var attach in emailContent.EmbededImageAttachements)
                {
                    bodyBuilder.LinkedResources.Add(attach);
                }
            }
            emailMessage.Bcc.AddRange(emailContent.Cc.ToList());

            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }

        private void Send(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_appConfigurationService.EmailConfiguration.SmtpServer, _appConfigurationService.EmailConfiguration.PortLocal, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_appConfigurationService.EmailConfiguration.UserName, _appConfigurationService.EmailConfiguration.Password);

                    client.Send(mailMessage);
                }
                catch
                {
                    //log an error message or throw an exception, or both.
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }

        private async Task SendAsync(MimeMessage mailMessage)
        {
            try
            {
                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    try
                    {

                        client.CheckCertificateRevocation = false;
                        client.ServerCertificateValidationCallback = (s, c, h, e) => true;
#if Publish
                        await client.ConnectAsync(_appConfigurationService.SmtpServer, _appConfigurationService.PortPublished, false);
#else

                        await client.ConnectAsync(_appConfigurationService.EmailConfiguration.SmtpServer, _appConfigurationService.EmailConfiguration.PortLocal, MailKit.Security.SecureSocketOptions.StartTls);
#endif

                        client.AuthenticationMechanisms.Remove("XOAUTH2");
                        await client.AuthenticateAsync(_appConfigurationService.EmailConfiguration.UserName, _appConfigurationService.EmailConfiguration.Password);

                        await client.SendAsync(mailMessage);
                        Logger.LogInformation($"Email Send To {string.Join(',', mailMessage.To)}");
                    }
                    catch (Exception exp)
                    {
                        Logger.LogError($"Error While Send Emial To {string.Join(',', mailMessage.To)}, Err: {exp.Message}");
                        throw;
                    }
                    finally
                    {
                        await client.DisconnectAsync(true);
                        client.Dispose();
                    }
                }
            }
            catch (Exception exp)
            {
                throw;
            }

        }
    }
}
