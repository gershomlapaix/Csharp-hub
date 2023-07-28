/* The example  below sorts instances of the Car class that are stored 
in a List<T>. The Car class implements the IComparable<T> interface, 
which requires that the CompareTo method be implemented.*/

class SortingIntro
{

    public static void ListCars()
    {
        var cars = new List<Car>{
        {new Car(){Name = "car1", Color="blue", Speed = 20}},
        {new Car(){Name = "car2", Color="red", Speed = 50}},
        {new Car(){Name = "car3", Color="gren", Speed = 10}},
         {new Car(){Name = "car4", Color="red", Speed = 20}},
    };

        // Sort the cars by color alphabetically, and then by speed
        // in descending order.
        cars.Sort();
        foreach (Car thisCar in cars)
        {
            Console.Write(thisCar.Color.PadRight(5) + " ");
            Console.Write(thisCar.Speed.ToString() + " ");
            Console.Write(thisCar.Name);
            Console.WriteLine();
        }
    }
}

public class Car : IComparable<Car>
{
    public string Name { get; set; }
    public int Speed;
    public string Color;

    public int CompareTo(Car other)
    {

        // compare the colors
        int compare;
        compare = String.Compare(this.Color, other.Color, true);

        // If the colors are the same, compare the speeds.
        if (compare == 0)
        {
            compare = this.Speed.CompareTo(other.Speed);

            // use the descending order for speed
            compare = -compare;
        }

        return compare;
    }
}