/* The difference between classes and structs*/

// class
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}

// struct
public struct PersonStruct
{
    public string Name;
    public int Age;
    public PersonStruct(string name, int age)
    {

        Name = name;
        Age = age;
    }
}
class Program
{
    static void Main(string[] args)
    {
        // about classes
        Person p1 = new Person("Leopold", 60);
        Console.WriteLine("Person1 name ={0} Ag={1}", p1.Name, p1.Age);

        Person p2 = p1;

        p2.Name = "Malik";
        p2.Age = 43;

        Console.WriteLine("person2 Name = {0} Age = {1}", p2.Name,
p2.Age);
        Console.WriteLine("person1 Name = {0} Age = {1}", p1.Name,
        p1.Age);

        Console.WriteLine("\n");
        // about structs
        PersonStruct p1struct = new PersonStruct("Alex", 9);
        Console.WriteLine("p1struct Name = {0} Age = {1}", p1struct.Name, p1struct.Age);

        PersonStruct p2struct = p1struct;
        p2struct.Name = "Spencer";
        p2struct.Age = 7;
        Console.WriteLine("p2struct Name = {0} Age = {1}", p2struct.Name, p2struct.Age);
        Console.WriteLine("p1struct Name = {0} Age = {1}", p1struct.Name, p1struct.Age);

    }
}