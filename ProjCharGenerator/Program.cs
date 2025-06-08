using System;
using System.IO;

class Program
{
    static void Main()
    {
        Directory.CreateDirectory("Results");

        var bigram = new BigramGenerator();
        bigram.LoadFromFile("data/bigrams.csv");
        var bigramText = bigram.Generate(1000);
        File.WriteAllText("Results/gen-1.txt", bigramText);

        var freqGen = new FrequencyWordGenerator();
        freqGen.LoadFromFile("data/words.csv");
        var wordText = freqGen.Generate(1000);
        File.WriteAllText("Results/gen-2.txt", wordText);

        Console.WriteLine("Генерация завершена.");
    }
}
