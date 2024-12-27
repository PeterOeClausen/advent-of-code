namespace Problem2_Part2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // var fileName = "sample_input.txt";
            // var fileName = "my_sample_input.txt";
            var fileName = "puzzle_input.txt";
            var reports = File.ReadLines(fileName);

            Func<int, int, bool> isIncreasing = (x, y) => x < y;
            Func<int, int, bool> isDecreasing = (x, y) => x > y;
            Func<int, int, bool> differenceIsAtMostThree = (x, y) => Math.Abs(x - y) <= 3;
            Func<int, int, bool> isSafelyIncreasing = (x, y) => isIncreasing(x, y) && differenceIsAtMostThree(x, y);
            Func<int, int, bool> isSafelyDecreasing = (x, y) => isDecreasing(x, y) && differenceIsAtMostThree(x, y);

            int safeReportCount = 0;
            foreach (var report in reports)
            {
                var levels = report
                    .Split(" ")
                    .Select(int.Parse)
                    .ToList();

                for (int skipIndex = 0; skipIndex < levels.Count; skipIndex++)
                {
                    bool safelyIncreasing = true;
                    bool safelyDecreasing = true;
                    for (int i = 0; i < levels.Count; i++)
                    {
                        if (skipIndex == i)
                        {
                            i++;
                        }
                        if (i > levels.Count - 2) // No elements left for j. Levels are safe.
                        {
                            continue;
                        }
                        int j = i + 1;
                        if (skipIndex == j)
                        {
                            j++;
                        }
                        if (j > levels.Count - 1) // j is out of bounds, levels are safe.
                        {
                            continue;
                        }
                        safelyIncreasing &= isSafelyIncreasing(levels[i], levels[j]);
                        safelyDecreasing &= isSafelyDecreasing(levels[i], levels[j]);
                    }
                    if (safelyIncreasing || safelyDecreasing)
                    {
                        safeReportCount++;
                        // Print safe level (for debugging)
                        for (int i = 0; i < levels.Count; i++)
                        {
                            Console.Write($"{levels[i]} ");
                        }
                        Console.WriteLine();
                        break; // Found a safe combination, move on to next report.
                    }
                }
            }

            Console.WriteLine($"Safe report count: {safeReportCount}");
        }
    }
}
