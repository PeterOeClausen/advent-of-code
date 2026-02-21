using System.Text.RegularExpressions;

namespace Problem3_Part1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var fileName = "puzzle_input.txt";
            if (!File.Exists(fileName))
            {
                Console.WriteLine($"File {fileName} does not exist.");
                return;
            }
            var lines = File.ReadLines(fileName);
            var result = 0;

            Console.WriteLine("Matches found:");
            foreach (var line in lines)
            {
                var matches = Regex.Matches(line, @"mul\(\d+,\d+\)");
                foreach (Match match in matches)
                {
                    Console.WriteLine(match.Value);
                    var numbers = match.Value
                        .Replace("mul(", "")
                        .Replace(")", "")
                        .Split(",")
                        .Select(int.Parse)
                        .ToArray();

                    result += numbers[0] * numbers[1];
                }
            }
            Console.WriteLine("\nFinal result:");
            Console.WriteLine(result);
        }
    }
}

