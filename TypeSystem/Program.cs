char firstLetter = 'C';
var limit = 4;
int[] source = { 0, 1, 2, 3 };
string message = "This is a string";

var query = from item in source
            where item <= limit
            select item;

Console.WriteLine(message);

// reference types
public class Person
{

    // required: modifier that mandates to set properties as a part of new expression
    public required string LastName { get; set; }
    public required string FirstName { get; set; }
}

// var p1 = new Person(); // error
// var p2 = new Person() { FirstName = "Grace", LastName = "Hopper" };

