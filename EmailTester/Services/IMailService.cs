namespace EmailTester.Services{
    public interface IMailService{
        Task SendEmailASync(MailRequest mailRequest);
    }
}