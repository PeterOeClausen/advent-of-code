namespace Problem2_Part1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // var fileName = "sample_input.txt";
            var fileName = "puzzle_input.txt";
            var reports = File.ReadLines(fileName);

            Func<int, int, bool> isIncreasing = (x, y) => x < y;
            Func<int, int, bool> isDecreasing = (x, y) => x > y;
            Func<int, int, bool> differenceIsAtMostThree = (x, y) => Math.Abs(x - y) <= 3;

            var safeReportCount = 0;
            foreach (var report in reports)
            {
                var levels = report
                    .Split(" ")
                    .Select(x => int.Parse(x))
                    .ToList();

                bool isStillDecreasingRequirement = true;
                bool isStillIncreasingRequirement = true;

                for (int i = 0; i < levels.Count - 1; i++)
                {
                    if (isStillDecreasingRequirement == false && isStillIncreasingRequirement == false)
                    {
                        break; // Report is not safe, no need to continue
                    }
                    var currentLevel = levels[i];
                    var nextLevel = levels[i + 1];

                    isStillDecreasingRequirement &= isDecreasing(currentLevel, nextLevel) && differenceIsAtMostThree(currentLevel, nextLevel);
                    isStillIncreasingRequirement &= isIncreasing(currentLevel, nextLevel) && differenceIsAtMostThree(currentLevel, nextLevel);
                }

                if (isStillDecreasingRequirement || isStillIncreasingRequirement)
                {
                    safeReportCount++;
                }
            }

            Console.WriteLine($"Safe report count: {safeReportCount}");
        }
    }
}