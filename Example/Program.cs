using Console = ConsoleFeatures.Console;

System.Console.WriteLine("Progressbar");

Random rand = new();
for (var i = 0; i <= 100; i++)
{
    var downloadSpeed = rand.NextInt64(1, 20);
    Console.Progressbar(i, information: $"{downloadSpeed} Mb/s");
    Thread.Sleep(100);
}

System.Console.Write("\n");

System.Console.WriteLine("Selector");

var options = new List<string>()
{
    "First option",
    "Second option",
    "Third option"
};

var selectedOptionIndex = Console.Selector(options);
System.Console.WriteLine($"Selected option: {options[selectedOptionIndex]}");

System.Console.Write("\n");
System.Console.WriteLine("Acceptance");

var accepted = Console.Acceptance("Do you accept sth?");
System.Console.WriteLine(accepted.ToString());

System.Console.Write("\n");

Console.Acceptance("Do you accept sth? required", true);