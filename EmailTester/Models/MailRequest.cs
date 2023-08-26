
public class MailRequest{
    private string ToEmail {get; set;}
    private string Subject {get; set;}
    private string Body {get; set;}
    private List<IFormFile> Attachments {get; set;}
    // IFormFile is a feature of ASP.NET Core to help speed up the process of uploading files 
    // It also acts as a medium for holding the files
}