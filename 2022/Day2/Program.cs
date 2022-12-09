// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string[] inputData;
try
{
	inputData = File.ReadAllLines(@"..\..\..\InputData.txt");
}
catch (Exception ex)
{
	throw ex;
}

Part1();
Part2();

void Part1()
{
	var winMap = new HashSet<string>
	{
		"C X",
		"A Y",
		"B Z"
	};

	var drawMap = new HashSet<string>
	{
		"A X",
		"B Y",
		"C Z"
	};

	var pointsMap = new Dictionary<string, int>
	{
		{ "X", 1},
		{ "Y", 2},
		{ "Z", 3},
	};

	var points = 0;
	foreach (var round in inputData)
	{
		var userAction = round.Split(" ")[1];
		if (winMap.Contains(round))
		{
			points += 6 + pointsMap[userAction];
		}
		else if (drawMap.Contains(round))
		{
			points += 3 + pointsMap[userAction];
		}
		else
		{
			points += pointsMap[userAction];
		}
	}

	Console.WriteLine($"PART 1: My score: {points} points");
}

void Part2()
{
	var winMap = new Dictionary<string, int>
	{
		{ "C X", 1 },
		{ "A Y", 2 },
		{ "B Z", 3 }
	};

	var loseMap = new Dictionary<string, int>
	{
		{ "A Z", 3 },
		{ "B X", 1 },
		{ "C Y", 2 }
	};

	var drawMap = new Dictionary<string, int>
	{
		{ "A", 1},
		{ "B", 2},
		{ "C", 3},
	};

	var points = 0;
	foreach (var round in inputData)
	{
		var oponentAction = round.Split(" ")[0];
		var userResult = round.Split(" ")[1];

		switch (userResult.ToLower())
		{
			case "x":
				points += loseMap.First(x => x.Key.StartsWith(oponentAction)).Value;
				break;
			case "y":
				points += 3 + drawMap[oponentAction];
				break;
			case "z":
				points += 6 + winMap.First(x => x.Key.StartsWith(oponentAction)).Value;
				break;
			default:
				break;
		}
	}

	Console.WriteLine($"PART 2: My score: {points} points");
}


