﻿class Program
{
    static void Main()
    {
        var lines = ReadFrom("sample.txt");
        foreach (var line in lines)
        {
            Console.Write(line);
            if (!string.IsNullOrWhiteSpace(line))
            {
                var pause = Task.Delay(100);
                // Synchronously waiting on a task is an
                // anti-pattern. This will get fixed in later
                // steps.
                pause.Wait();
            }
        }
    }

    static IEnumerable<string> ReadFrom(string file)
    {
        string? line;
        using (var reader = File.OpenText(file))
        {
            while ((line = reader.ReadLine()) != null)
            {
                var words = line.Split(' ');
                foreach (var word in words)
                {
                    yield return word + " ";
                }
                yield return Environment.NewLine;
            }
        }
    }
}