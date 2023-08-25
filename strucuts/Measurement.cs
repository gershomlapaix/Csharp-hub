using System;

public readonly struct Measurement{

// constructor with initialized values
    public Measurement(){
        Value = double.NaN;
        Description = "Undefined";
    }

    // parameterized constructor
    public Measurement(double value, string description){
        Value = value;
        Description = description;
    }

    // properties with getters and initializers
    public double Value{get; init;}
    public string Description{get; init;}


// override toString method
    public override string ToString() => $"{Value} ({Description})";

}

