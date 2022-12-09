//See https://aka.ms/new-console-template for more information

using System.IO;

Console.WriteLine("Hello, World!");


var inputData = File.ReadAllLines(@"..\..\..\InputData.txt");

var elvesInvetories = new Dictionary<int, int>();
int caloriesCounter = 0;
int elvsCounter = 1;

foreach (var calories in inputData)
{
	if (calories != string.Empty)
	{
		if (int.TryParse(calories, out var caloriesAsNumber))
		{ caloriesCounter += caloriesAsNumber; }
	}
	else
	{
		elvesInvetories.Add(elvsCounter, caloriesCounter);
		caloriesCounter = 0;
		elvsCounter++;
	}
}

elvesInvetories = elvesInvetories.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
Console.WriteLine($"Elvs with most calories: {elvesInvetories.First().Key}. Number of calories: {elvesInvetories.First().Value}");
Console.WriteLine("------------------------------------------------------------------------------------------------------------");
//Part 2

var sumOfCaloriesTopThreeElves = 0;
for(int i = 0; i < 3; i++)
{
	sumOfCaloriesTopThreeElves += elvesInvetories.ElementAt(i).Value;
}

Console.WriteLine($"Top 3 elves have {sumOfCaloriesTopThreeElves} calories in inventories");

Console.ReadKey();
