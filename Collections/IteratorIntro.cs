/*
     yeild return
  
  When a yield return statement is reached in the iterator, an expression is
returned, and the current location in code is retained. Execution is restarted from that
location the next time that the iterator is called
*/

public class IteratorsIntro
{
    public static void ListEvenNumbers()
    {
        foreach (int number in EvenSequence(5, 18))
        {
            Console.Write(number.ToString() + " ");
        }
        Console.WriteLine();
    }

    private static IEnumerable<int> EvenSequence(int firstNumber, int lastNumber)
    {
        for (var number = firstNumber; number <= lastNumber; number++)
        {
            if (number % 2 == 0)
            {
                yield return number;
            }
        }

    }
}