using Task_3;

var queue = new BiDirectionalPriorityQueue<string>();


queue.Enqueue("apple", 2);
queue.Enqueue("banana", 3);
queue.Enqueue("cherry", 1);


Console.WriteLine($"Highest priority item: {queue.Peek(Mode.Highest)}"); 

var dequeuedItem = queue.Dequeue(Mode.Highest);
Console.WriteLine($"Dequeued item: {dequeuedItem}"); 

Console.WriteLine($"Newest item: {queue.Peek(Mode.Newest)}"); 

dequeuedItem = queue.Dequeue(Mode.Newest);
Console.WriteLine($"Dequeued newest item: {dequeuedItem}"); 

Console.WriteLine($"Oldest item: {queue.Peek(Mode.Oldest)}"); 

dequeuedItem = queue.Dequeue(Mode.Oldest);
Console.WriteLine($"Dequeued oldest item: {dequeuedItem}"); 