
//  A concrete class for implementing IMailService interface
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace EmailTester.Services{
    
    public class MailService: IMailService{
        private readonly MailSettings _mailSettings;
        public MailService(IOptions<MailSettings> mailSettings){ // IOptions is Used to retrieve configured MailSettings instances.
            _mailSettings = mailSettings.Value;
        }
        

        /**
         below is the real method to send an email

         The idea is to create an object of MimeMessage and send it using SMTP client instance(from MailKit)

         26-29: creates a new object of MimeMessage
         
        */ 
        public async Task SendEmailASync(MailRequest mailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;

            var builder = new BodyBuilder();
            if(mailRequest.Attachments != null){ // if there are some attached files
                byte[] fileBytes;
                foreach(var file in mailRequest.Attachments){
                    if(file.Length > 0){
                        using(var ms = new MemoryStream()){
                            file.CopyTo(ms);
                            fileBytes = ms.ToArray();
                        }
                        builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                    }
                }
            }

            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
}