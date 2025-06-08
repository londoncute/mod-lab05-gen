using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class BigramGenerator
{
    private readonly Dictionary<string, double> bigramProb = new();
    private readonly Random rand = new();

    public void LoadFromFile(string path)
    {
        foreach (var line in File.ReadLines(path))
        {
            var parts = line.Split(';');
            if (parts.Length < 3) continue;
            var bigram = parts[1];
            var prob = double.Parse(parts[2]);
            bigramProb[bigram] = prob;
        }
    }

    public string Generate(int length = 1000)
    {
        var output = "";
        var keys = bigramProb.Keys.ToList();
        var weights = bigramProb.Values.ToList();
        double total = weights.Sum();
        while (output.Length < length)
        {
            double r = rand.NextDouble() * total;
            double acc = 0;
            for (int i = 0; i < keys.Count; i++)
            {
                acc += weights[i];
                if (r < acc)
                {
                    output += keys[i][0];
                    break;
                }
            }
        }
        return output;
    }
}
