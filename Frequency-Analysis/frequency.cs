using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FrequencyAnalysis
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Default options
            bool caseSensitive = true;

            // Parse command line arguments
            if (args.Length < 1)
            {
                Console.WriteLine("Usage: frequency.exe <filename> [-c]");
                return;
            }

            string filename = args[0];
            if (args.Length > 1 && args[1] == "-c")
            {
                caseSensitive = false;
            }

            // Read file contents
            string fileContents = File.ReadAllText(filename);

            // Remove whitespace characters
            string cleanedContents = new string(fileContents.Where(c => !char.IsWhiteSpace(c)).ToArray());

            // Perform frequency analysis
            Dictionary<char, int> frequencies = new Dictionary<char, int>();
            foreach (char i in cleanedContents)
            {
                char c = caseSensitive ? i : char.ToLower(i);
                if (char.IsWhiteSpace(c))
                {
                    continue;
                }

                if (frequencies.ContainsKey(c))
                {
                    frequencies[c]++;
                }
                else
                {
                    frequencies[c] = 1;
                }
            }

            // Output results
            Console.WriteLine("Total characters: {0}", cleanedContents.Length);

            var topFrequencies = frequencies.OrderByDescending(x => x.Value).Take(10);
            foreach (var pair in topFrequencies)
            {
                Console.WriteLine("{0} ({1})", pair.Key, pair.Value);
            }

        }
    }
}