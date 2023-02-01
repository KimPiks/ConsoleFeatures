# ConsoleFeatures

A library that gives functionality to the console (Progressbar, selection menu, acceptance field)

<p align="center">
  <img src="https://raw.githubusercontent.com/KimPiks/ConsoleFeatures/main/output.png" />
</p>

## Docs
- `void Progressbar(int value, int min = 0, int max = 100, string information = "")`<br>
Shows a progressbar<br>
    - `int value` - Progressbar value
    - `int min` - Progressbar minimum value (default 0)
    - `int max` - Progressbar minimum value (default 100)
    - `string information` - Additional information (e.q. download speed)
    - `ArgumentOutOfRangeException` - The exception is returned when the progressbar value is outside its range (min < = value < = max)

- `int Selector(List<string> options, int selectedIndex = 0)`<br>
Shows a form with options to choose from<br>
    - `List<string> options` - List of options to choose from
    - `int selectedIndex` - Currently selected option, no need to specify, needed for recursion
    - `Return` - The index of the selected option

- `bool Acceptance(string text, bool approvalRequired = false)`<br>
Shows acceptable condition (Y/N)<br>
    - `string text` - Acceptable condition
    - `bool approvalRequired` - Whether the user must accept the terms to proceed
    - `Return` - Whether the user has accepted the terms


- `void ClearLastLine()`<br>
Clears the last console line

## Example
```
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
```

