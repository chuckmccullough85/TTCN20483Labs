
using GenericsLab;

var list = new GenericArrayList<string>();
if (list.Size != 0)
    throw new Exception("Size should be 0");

list.Add("Hello").Add("World").Add("Test");
if (list.Size != 3)
    throw new Exception("Size should be 3");

list.Remove(1);
if (list.Size != 2)
    throw new Exception("Size should be 2");

if (!list[0].Equals("Hello"))
    throw new Exception("Index 0 should be Hello");

if (!list[1].Equals("Test"))
    throw new Exception("Index 1 should be Test");

for (int i = 0; i < 30; i++)
    list.Add("Hello" + i);

if (list.Size != 32)
    throw new Exception("Size should be 32");

try {
    list[32] = "Hello";
    throw new Exception("Should have thrown an exception");
} catch (ArgumentOutOfRangeException) {
    // Expected 
}

foreach (var txt in list)
    Console.WriteLine(txt);


Console.WriteLine("All tests passed");