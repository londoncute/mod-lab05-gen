using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class FrequencyWordGenerator
{
    private readonly List<(string Word, double Weight)> words = new();
    private readonly Random rand = new();

    public void LoadFromFile(string path)
    {
        foreach (var line in File.ReadLines(path))
        {
            var parts = line.Split(';');
            if (parts.Length < 2) continue;
            words.Add((parts[0], double.Parse(parts[1])));
        }
    }

    public string Generate(int count = 1000)
    {
        var result = new List<string>();
        var total = words.Sum(w => w.Weight);

        for (int i = 0; i < count; i++)
        {
            double r = rand.NextDouble() * total;
            double acc = 0;
            foreach (var word in words)
            {
                acc += word.Weight;
                if (r < acc)
                {
                    result.Add(word.Word);
                    break;
                }
            }
        }

        return string.Join(" ", result);
    }
}
