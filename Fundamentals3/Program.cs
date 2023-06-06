static void PrintList(List<string> MyList)
{
    for (int i = 0; i < MyList.Count; i++)
    {
        Console.WriteLine(MyList[i]);
    }
}

List<string> TestStringList = new List<string>() { "Harry", "Steve", "Carla", "Jeanne" };
PrintList(TestStringList);

static void SumOfNumbers(List<int> IntList)
{
    int sum = 0;
    foreach (int num in IntList)
    {
        sum += num;
    }
    Console.WriteLine("Sum: " + sum);
}

List<int> TestIntList = new List<int>() {2,7,12,9,3};
// You should get back 33 in this example
SumOfNumbers(TestIntList);

static int FindMax(List<int> IntList)
{
    return IntList.Max();
}

List<int> TestIntList2 = new List<int>() {-9,12,10,3,17,5};

// You should get back 17 in this example
int maxNumber = FindMax(TestIntList2);
Console.WriteLine("Max: " + maxNumber);

static List<int> SquareValues(List<int> IntList)
{
    List<int> squaredList = new List<int>();
    foreach (int num in IntList)
    {
        int squaredValue = num * num;
        squaredList.Add(squaredValue);
    }
    return squaredList;
}

List<int> TestIntList3 = new List<int>() {1,2,3,4,5};
// You should get back [1,4,9,16,25], think about how you will show that this worked
List<int> squaredList = SquareValues(TestIntList3);
Console.WriteLine("Squared List: " + string.Join(", ", squaredList));

static int[] NonNegatives(int[] IntArray)
{
    for (int i = 0; i < IntArray.Length; i++)
    {
        if (IntArray[i] < 0)
        {
            IntArray[i] = 0;
        }
    }
    return IntArray;
}


int[] TestIntArray = new int[] { -1, 2, 3, -4, 5 };
// You should get back [0,2,3,0,5], think about how you will show that this worked

int[] modifiedArray = NonNegatives(TestIntArray);
Console.WriteLine("Modified Array: " + string.Join(", ", modifiedArray));

static void PrintDictionary(Dictionary<string, string> MyDictionary)
{
    foreach (KeyValuePair<string, string> pair in MyDictionary)
    {
        Console.WriteLine(pair.Key + ": " + pair.Value);
    }
}

Dictionary<string, string> TestDict1 = new Dictionary<string, string>();
TestDict1.Add("HeroName", "Iron Man");
TestDict1.Add("RealName", "Tony Stark");
TestDict1.Add("Powers", "Money and intelligence");
PrintDictionary(TestDict1);

static bool FindKey(Dictionary<string, string> MyDictionary, string SearchTerm)
{
    return MyDictionary.ContainsKey(SearchTerm);
}

Dictionary<string, string> TestDict2 = new Dictionary<string, string>();
TestDict2.Add("HeroName", "Iron Man");
TestDict2.Add("RealName", "Tony Stark");
TestDict2.Add("Powers", "Money and intelligence");

Console.WriteLine(FindKey(TestDict2, "RealName"));
Console.WriteLine(FindKey(TestDict2, "Name"));


static Dictionary<string, int> GenerateDictionary(List<string> Names, List<int> Numbers)
{
    Dictionary<string, int> dictionary = new Dictionary<string, int>();

    if (Names.Count == Numbers.Count)
    {
        for (int i = 0; i < Names.Count; i++)
        {
            string name = Names[i];
            int number = Numbers[i];
            dictionary.Add(name, number);
        }
    }

    return dictionary;
}

List<string> names = new List<string>() { "Julie", "Harold", "James", "Monica" };
List<int> numbers = new List<int>() { 6, 12, 7, 10 };

Dictionary<string, int> result = GenerateDictionary(names, numbers);

foreach (KeyValuePair<string, int> pair in result)
{
    Console.WriteLine(pair.Key + ": " + pair.Value);
}
