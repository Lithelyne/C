//Arrays
int[] numArray = new int[]{0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
String[] namesArray = new String[]{"Tim", "Martin", "Nikki", "Sara"};

int length = 10;
bool[] booleanArray = new bool[length];

for (int i = 0; i < length; i++)
{
    booleanArray[i] = i % 2 == 0;
}



//Lists
List<string> iceCream = new List<string>()
{
    "Vanilla", "Chocolate", "Strawberry", "Rocky Road", "Root Beer"
};

Console.WriteLine($"We currently know of {iceCream.Count} flavors.");
Console.WriteLine($"The third flavor in the list is: {iceCream[2]}");
iceCream.RemoveAt(2);
Console.WriteLine($"The length of the iceCream list is now: {iceCream.Count}");

//Dictionary
Dictionary<string, string> profile = new Dictionary<string, string>();

Random random = new Random();

foreach (string name in namesArray)
{
    int randomIceCream = random.Next(0, iceCream.Count);
    string randomFlavor = iceCream[randomIceCream];
    profile.Add(name, randomFlavor);
}

foreach (KeyValuePair<string, string> entry in profile)
{
    Console.WriteLine($"User: {entry.Key}, Flavor: {entry.Value}");
}