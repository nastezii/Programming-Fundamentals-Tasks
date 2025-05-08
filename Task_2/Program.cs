using Task_2;

Func<int, int> CalculateSquare = x =>
{
    Console.WriteLine($"calculating the square of {x}");
    return x * x;
};

Memoizer memoizer = new Memoizer();
var memoizedSquareLFU = memoizer.Memoize(CalculateSquare, maxCacheSize: 3, strategy: EvictionStrategy.LFU);

Console.WriteLine(memoizedSquareLFU(2));
Console.WriteLine(memoizedSquareLFU(2));
Console.WriteLine(memoizedSquareLFU(3));
Console.WriteLine(memoizedSquareLFU(4));
Console.WriteLine(memoizedSquareLFU(5));
Console.WriteLine(memoizedSquareLFU(2));
Console.WriteLine(memoizedSquareLFU(3));
Console.ReadLine();
