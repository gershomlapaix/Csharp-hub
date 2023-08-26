// this class is designed to hold the data from appsettings.Development.json
public class MailSettings{
    private string mail;
    private string displayName;
    private string password;
    private string host;
    private int  port;

    // getters and setters
    public string Mail{
        get{return mail;}
        set{mail = value;}
    }

    public string DisplayName{
        get{return displayName;}
        set{displayName = value;}
    }

    public string Password{
        get{return password;}
        set{password= value;}
    }

    public string Host{
        get{return host;}
        set{host= value;}
    }

    public int Port{
        get{return port;}
        set{port= value;}
    }
}