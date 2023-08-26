
public class MailRequest{
    private string toEmail;
    private string subject;
    private string body;
    private List<IFormFile> attachments;
    // IFormFile is a feature of ASP.NET Core to help speed up the process of uploading files 
    // It also acts as a medium for holding the files


    // getters and setters

    public string ToEmail
    {
        get {return toEmail;}
        set{
            try
            {
                if(!value.Contains("@")){
                    throw new InvalidDataException("Your email must include '@'.");
                }
                toEmail = value;
            }
            catch (InvalidDataException ie)
            {
                Console.WriteLine(ie);
            }
        }
    }

    public string Subject{
        get {return subject;}
        set {subject = value;}
    }

    public string Body{
        get {return body;}
        set{body = value;}
    }

    public List<IFormFile> Attachments{
        get {return attachments;}
        set{attachments = value;}
    }
}