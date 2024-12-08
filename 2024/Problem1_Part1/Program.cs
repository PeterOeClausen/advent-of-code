using Common;

namespace Problem1_Part1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string inputFilePath = "input.txt";
            List<Pair> pairs = File
                .ReadLines(inputFilePath)
                .Select(x =>
                {
                    var res = x.Split("   ");
                    return new Pair()
                    {
                        Left = int.Parse(res[0]),
                        Right = int.Parse(res[1])
                    };
                })
                .ToList();

            List<int> lefts = pairs
                .Select(x => x.Left)
                .OrderBy(x => x)
                .ToList();

            List<int> rights = pairs
                .Select(x => x.Right)
                .OrderBy(x => x)
                .ToList();

            int res = lefts
                .Zip(rights)
                .Select((pair) => Math.Abs(pair.First - pair.Second))
                .Sum();

            Console.WriteLine($"Result should be: {res}");
        }
    }


}