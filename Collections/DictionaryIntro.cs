/*
Each addition to the dictionary consists of avalue and its associated key. Retrieving a value by using its key is fast because the
Dictionary class is implemented as a hash table.
*/

public class Element
{
    public string Symbol { get; set; }
    public string Name { get; set; }
    public int AtomicNUmber { get; set; }
}

public class DictionaryOperations
{
    // methods
    public static void IterateThruDictionary()
    {
        Dictionary<string, Element> elements = BuildDictionary();
        foreach (KeyValuePair<string, Element> kvp in elements)
        {
            Element theElement = kvp.Value;
            Console.WriteLine("key: " + kvp.Key);
            Console.WriteLine("values: " + theElement.Symbol + " " +
            theElement.Name + " " + theElement.AtomicNUmber);
        }
    }

    // build the dictionary
    private static Dictionary<string, Element> BuildDictionary()
    {
        var elements = new Dictionary<string, Element>();

        AddToDictionary(elements, "K", "Potassium", 19);
        AddToDictionary(elements, "Ca", "Calcium", 20);

        return elements;
    }


    // adding the data to the dictionary
    private static void AddToDictionary(Dictionary<string, Element> elements, string symbol, string name, int atomicNumber)
    {
        Element theElement = new Element();
        theElement.Symbol = symbol;
        theElement.Name = name;
        theElement.AtomicNUmber = atomicNumber;

        elements.Add(key: theElement.Symbol, value: theElement);
    }
}