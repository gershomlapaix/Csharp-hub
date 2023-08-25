public readonly struct Coords
{

    // constructor
    public Coords(double x, double y){
        X = x;
        Y = y;
    }

// getters and setters
    public double X{get; set;}
    public double Y{get; set}

// override toString() method
    public override string ToString() => $"({X}, {Y})"
}