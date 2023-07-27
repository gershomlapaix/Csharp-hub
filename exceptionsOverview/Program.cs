namespace Exceptions
{
    // custom exception------------
    public class CustomException : Exception
    {
        public CustomException() { }
        public CustomException(string message)
        { }

        // test a custom exception
        public void TestThrow()
        {
            throw new CustomException("Custom exception in TestThrow()");
        }
    }


    // First example-----------------
    public class ExceptionTest
    {
        public double SafeDivision(double x, double y)
        {
            if (y == 0)
                throw new DivideByZeroException();
            return x / y; // else
        }
    }

    public class Program
    {
        /*
                public static void Main()
                {
                    double a = 98, b = 0;
                    double result;

                    try
                    {
                        result = new ExceptionTest().SafeDivision(a, b);
                        Console.WriteLine("{0} divided by {1} = {2}", a, b, result);
                    }
                    catch (DivideByZeroException)
                    {
                        Console.WriteLine("Attempted divide by zero.");
                    }
                }
        */



        /*
        public static void Main()
        {
            try
            {
                new CustomException().TestThrow();
            }
            catch (CustomException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        */

        // The order of using exceptions--------------
        public static void Main()
        {
            try
            {
                using (var sw = new StreamWriter("./test.txt"))
                {
                    sw.WriteLine("Hello");
                }
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex);
            }
            Console.WriteLine("Done");
        }

    }
}