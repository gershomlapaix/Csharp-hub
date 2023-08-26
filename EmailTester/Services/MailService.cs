
//  A concrete class for implementing IMailService interface
using Microsoft.Extensions.Options;
using MimeKit;

namespace EmailTester.Services{
    
    public class MailService: IMailService{
        private readonly MailSettings _mailSettings;
        public MailService(IOptions<MailSettings> mailSettings){ // IOptions is Used to retrieve configured MailSettings instances.
            _mailSettings = mailSettings.Value;
        }

        public Task SendEmailASync(MailRequest mailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.getMail());
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;
        }
    }
}