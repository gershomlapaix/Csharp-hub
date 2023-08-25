// Todo model to manage the todo data that the app will manage
public class Todo{

    // properties
    public int Id{get; set;}
    public string? Name {get; set;}
    public bool IsComplete{get; set;}
    public string? Secret{get; set;}   // added field; it needs to be hidden from the clients
    
}