/*
 * structs do not support inheritance


 * The following illustration shows a class WorkItem that represents an item 
   of work in some businees process.
*/

public class WorkItem
{
    private static int currentID; // to hold the id of the last created workitem

    protected int Id { get; set; }
    protected string Title { get; set; }
    protected string Description { get; set; }
    protected TimeSpan JobLength { get; set; }

    // default constructor
    public WorkItem()
    {
        Id = 0;
        Title = "Default title";
        Description = "Default description";
        JobLength = new TimeSpan();
    }


    // Instance constructor
    public WorkItem(string title, string description, TimeSpan JobLength)
    {
        this.Id = GetNextId();
        this.Title = title;
        this.Description = description;
        this.JobLength = JobLength;
    }


    // static constructor to initialise currentID property. It will be automatically invoked before any other thing
    static WorkItem() => currentID = 0;

    // methods
    protected int GetNextId() => ++currentID;

    public void Update(string title, TimeSpan jobLen)
    {
        this.Title = title;
        this.JobLength = jobLen;
    }

    // overriding ToString() method
    public override string ToString() => $"{this.Id} - {this.Title} ";
}


// Another class
public class ChangeRequest : WorkItem
{
    protected int originalItemId { get; set; }

    // default constructor
    public ChangeRequest() { }

    // instance constructor
    public ChangeRequest(string title, string description, TimeSpan jobLen, int originalId)
    {
        this.Id = GetNextId();
        this.Title = title;
        this.Description = description;
        this.JobLength = jobLen;
        this.originalItemId = originalId;
    }
}


class Program
{
    static void Main()
    {
        WorkItem item = new WorkItem("Fix Bugs",
        "Fix all bugs in my code branch",
        new TimeSpan(3, 4, 0, 0));

        Console.WriteLine(item.ToString());

// change request
        ChangeRequest change = new ChangeRequest("Change Base Class Design",
"Add members to the class",
new TimeSpan(4, 0, 0),
1);

        Console.WriteLine(item.ToString());

// make an update
        change.Update("Change the Design of the Base Class",
new TimeSpan(4, 0, 0));

Console.WriteLine(change.ToString());
    }
}