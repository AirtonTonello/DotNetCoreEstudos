
using System.Collections;

int length = 5;

Array list2 = new int[length];
Array list = Array.CreateInstance(typeof(int), length);

for (int i = 0; i < length; i++)
{
    list.SetValue(100 * i, i);
}


ArrayList arrayList = new();

arrayList.Add(new
{
    Name = "Airton"
});

arrayList.Add(new
{
    Name = "Airton",
    Price = 0,
});

foreach (var item in arrayList)
{
    ;
}

SortedList<int, string> sortedList = new();

sortedList.Add(1, "airton 1");
sortedList.Add(2, "airton 2");
sortedList.Add(0, "airton 0");


SortedList<string, string> sortedList2 = new();

sortedList2.Add("c", "airton 1");
sortedList2.Add("b", "airton 2");
sortedList2.Add("a", "airton 0");


// LIFO -> Last In - First Out
Stack<int> stack = new();
stack.Push(1);
stack.Push(2);
stack.Push(3);
stack.Push(4);

var stackItem1 = stack.Peek();
stack.Pop();

var stackItem2 = stack.Peek();
stack.Pop();

// FIFO -> First In - First Out
Queue<int> queue = new Queue<int>();
queue.Enqueue(1);
queue.Enqueue(2);
queue.Enqueue(3);
queue.Enqueue(4);

var queueItem1 = queue.Dequeue();
var queueItem2 = queue.Dequeue();


// Sem duplicados
HashSet<int> hashSet = new();
hashSet.Add(0);
hashSet.Add(1);
hashSet.Add(1);
hashSet.Add(1);
hashSet.Add(1);

Console.ReadKey();