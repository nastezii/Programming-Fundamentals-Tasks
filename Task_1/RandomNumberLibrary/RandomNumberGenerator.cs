namespace RandomNumberLibrary
{
    public class RandomNumberGenerator
    {
        private Random _random = new Random();

        public IEnumerable<int> GenerateInfinite(int minValue, int maxValue)
        {
            while (true) yield return _random.Next(minValue, maxValue + 1);
        }
    }
}