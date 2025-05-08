using Task_2;

Func<int, int> CalculateSquare = x =>
{
    Console.WriteLine($"calculating the square of {x}");
    return x * x;
};