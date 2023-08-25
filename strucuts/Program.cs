// tester
class Program{
    public static void Main(){
    var m1 = new Measurement();
    Console.WriteLine(m1);

    var m2 = default(Measurement);
    Console.WriteLine(m2);

    var ms = new Measurement[2];
    Console.WriteLine(string.Join(", ", ms));

    // other more
    
    int? maybe = 12;
    if(maybe is int number){
        Console.WriteLine($"The nullable int 'maybe' has the value {number}");
    }else
    {
        Console.WriteLine("The nullable int 'maybe' doesn't hold a value");
    }


    string? message = "This is not null string";
    if(message is not null){
        Console.WriteLine(message);
    }

    // relational patterns
    string WaterState(int tempInFahrenheit)=>
    tempInFahrenheit switch{
        (> 32) and (< 212) => "Liquid",
         < 32 => "solid",
        32 => "solid/liquid transition",
        212 => "liquid / gas transition",
        _=> "gas"
    };

    Console.WriteLine(WaterState(365));
}
}