using Common;

namespace Problem1_Part2
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

            var result = pairs.Select(x =>
            {
                var left = x.Left;
                var count = pairs.Where(x => x.Right == left).Count();
                return left * count;
            })
            .Sum();

            Console.WriteLine($"Result should be: {result}");
        }
    }
}