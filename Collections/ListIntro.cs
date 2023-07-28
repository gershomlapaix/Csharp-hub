/*
 Lists with LINQ to access the collections
*/
public class ListIntro
{

    // methods

    public static void ShowLINQ()
    {
        List<Element> elements = BuildList();

        var subset = from theElement in elements
                     where theElement.AtomicNumber < 22
                     orderby theElement.Name
                     select theElement;

        foreach (Element theElement in subset)
        {
            Console.WriteLine(theElement.Name + " " + theElement.AtomicNumber);
        }
    }

    // list building
    private static List<Element> BuildList()
    {
        return new List<Element>{
        {new Element(){Symbol="K", Name="Potassium", AtomicNumber=19}},
        { new Element() { Symbol="Ca", Name="Calcium", AtomicNumber=20}},
{ new Element() { Symbol="Sc", Name="Scandium", AtomicNumber=21}},
{ new Element() { Symbol="Ti", Name="Titanium", AtomicNumber=22}}
        };

    }
}