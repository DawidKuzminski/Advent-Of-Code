string path = @"D:\PROJECTS\Advent-Of-Code\2021\Day1\InputData.txt";

if(File.Exists(path))
{
	var inputData = File.ReadAllText(path).Split(Environment.NewLine);
	int count = 0;

	for (int i = 1; i < inputData.Length; i++)
	{
		Int32.TryParse(inputData[i], out int currentValue);
		Int32.TryParse(inputData[i - 1], out int previousValue);
		
		if(currentValue > previousValue)
			count++;
	}

	Console.WriteLine($"{count} measurements are larger than the previous measurement");
}



int[] PrepareAdvancedInput(string[] inputData)
{

	for (int i = 1; i < inputData.Length; i++)
	{
		Int32.TryParse(inputData[i], out int currentValue);
		Int32.TryParse(inputData[i - 1], out int previousValue);			
	}
}
