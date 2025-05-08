using Task_3;

var queue = new BiDirectionalPriorityQueue<string>();

queue.Enqueue("cat", 10);
queue.Enqueue("dog", 15);
queue.Enqueue("hamster", 20);

Console.WriteLine($"Newest item: {queue.Peek(Mode.Newest)}"); 
Console.WriteLine($"Oldest item: {queue.Peek(Mode.Oldest)}");
Console.WriteLine($"Highest priority item: {queue.Peek(Mode.Highest)}");
Console.WriteLine($"Lowest priority item: {queue.Peek(Mode.Lowest)}");

var dequeuedItem = queue.Dequeue(Mode.Highest);
Console.WriteLine($"Dequeued item: {dequeuedItem}");

Console.WriteLine($"Highest priority item: {queue.Peek(Mode.Highest)}");
Console.ReadLine();