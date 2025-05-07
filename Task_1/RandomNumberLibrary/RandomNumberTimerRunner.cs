using System.Diagnostics;

namespace RandomNumberLibrary
{
    public class RandomNumberTimerRunner
    {
        public void GenerateRandomNumbers(IEnumerable<int> numbers, double intervalSeconds, double totalDurationSeconds)
        {
            var enumerator = numbers.GetEnumerator();
            Stopwatch stopwatch = Stopwatch.StartNew();
            System.Timers.Timer timer = new(intervalSeconds * 1000);

            int sum = 0;
            int count = 0;

            timer.Elapsed += (s, e) =>
            {
                if (enumerator.MoveNext())
                {
                    int current = enumerator.Current;
                    sum += current;
                    count++;
                    Console.WriteLine($"Random number: {current}\nAverage: {sum / count}\nSum: {sum}");
                }

                if (stopwatch.Elapsed.TotalSeconds >= totalDurationSeconds)
                {
                    timer.Stop();
                    Console.WriteLine("\nTime is over.");
                }
            };

            stopwatch.Start();
            timer.Start();
            Console.WriteLine($"Generating numbers for {intervalSeconds} seconds.\n");
            Console.ReadLine();
        }
    }
}