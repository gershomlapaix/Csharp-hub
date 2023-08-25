
/*
  DTO
  --- 

  1. For preventing over-posting
  2. Hide properties that clients are not supposed to view
  3. Omit some properties in order to reduce payload size;
  4. Flatten object graphs that contain nested object. Flattened object graphs can be more convenient
     for clients.
*/
public class TodoItemDTO{
    public int Id{get; set;}
    public string? Name{get; set;}
    public bool IsComplete{get; set;}

// contructor
    public TodoItemDTO(){}

    // constructor
    public TodoItemDTO(Todo todoitem)=>
    (Id, Name, IsComplete) = (todoitem.Id, todoitem.Name,todoitem.IsComplete);
}