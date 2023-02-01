namespace ConsoleFeatures
{
    /// <summary>
    /// A class that extends the console with new functionalities
    /// </summary>
    public static class Console
    {
        /// <summary>
        /// Shows a progressbar
        /// </summary>
        /// <param name="value">Progressbar value</param>
        /// <param name="min">Progressbar minimum value (default 0)</param>
        /// <param name="max">Progressbar minimum value (default 100)</param>
        /// <param name="information">Additional information (e.q. download speed)</param>
        /// <exception cref="ArgumentOutOfRangeException">The exception is returned when the progressbar value is outside its range (min <= value <= max)</exception>
        public static void Progressbar(int value, int min = 0, int max = 100, string information = "")
        {
            // Checks if value is in specific range
            if (value < min || value > max)
                throw new ArgumentOutOfRangeException(nameof(value));

            // If progressbar already started, refresh it on every next call
            if (value != min)
                ClearLastLine();

            // Calculate the percentage of the value in the given range (necessary when changing the minimum or maximum value) 
            var valuePercent = ((value - min) * 100 / (max - min));

            // Print the progressbar
            for (var i = 1; i <= 40; i++)
            {
                if (i <= valuePercent / 2.5)
                    System.Console.Write("█");
                else
                    System.Console.Write(" ");
            }

            // Show additional informations
            System.Console.Write(" {0}% ", valuePercent);
            System.Console.WriteLine("{0}", information);
        }

        /// <summary>
        /// Shows a form with options to choose from
        /// </summary>
        /// <param name="options">List of options to choose from</param>
        /// <param name="selectedIndex">Currently selected option, no need to specify, needed for recursion</param>
        /// <returns>The index of the selected option</returns>
        public static int Selector(List<string> options, int selectedIndex = 0)
        {
            // Print options
            foreach (var (option, index) in options.Select((option, index) => (option, index)))
            {
                if (selectedIndex == index)
                    System.Console.ForegroundColor = ConsoleColor.Blue;

                System.Console.WriteLine($"{index + 1}. {option}");
                System.Console.ResetColor();
            }

            // Selection control
            var selectedKey = System.Console.ReadKey();

            switch (selectedKey.Key)
            {
                case ConsoleKey.Enter:
                    return selectedIndex;
                case ConsoleKey.DownArrow:
                    if (selectedIndex == options.Count - 1)
                        break;

                    selectedIndex += 1;
                    break;
                case ConsoleKey.UpArrow:
                    if (selectedIndex == 0)
                        break;

                    selectedIndex -= 1; 
                    break;
                default:
                    break;
            }
            for (var i = 0; i < options.Count; i++)
            {
                ClearLastLine();
            }

            return Selector(options, selectedIndex);
        }

        /// <summary>
        /// Shows acceptable condition (Y/N)
        /// </summary>
        /// <param name="text">Acceptable condition</param>
        /// <param name="approvalRequired">Whether the user must accept the terms to proceed</param>
        /// <returns>Whether the user has accepted the terms</returns>
        public static bool Acceptance(string text, bool approvalRequired = false)
        {
            System.Console.Write($"{text} (Y/N): ");

            var selectedKey = System.Console.ReadKey();

            switch (selectedKey.Key)
            {
                case ConsoleKey.Y:
                    System.Console.WriteLine();
                    return true;
                case ConsoleKey.N:
                    System.Console.WriteLine();

                    if (approvalRequired)
                    {
                        System.Console.WriteLine("Acceptance is required");
                        return Acceptance(text, true);
                    }
                    return false;
                default:
                    System.Console.WriteLine();
                    ClearLastLine();
                    return Acceptance(text);
            }
        }
        
        /// <summary>
        /// Clears the last console line
        /// </summary>
        public static void ClearLastLine()
        {
            System.Console.SetCursorPosition(System.Console.CursorLeft, System.Console.CursorTop - 1);
            System.Console.Write("\r" + new string(' ', System.Console.WindowWidth) + "\r");
        }
    }
}
