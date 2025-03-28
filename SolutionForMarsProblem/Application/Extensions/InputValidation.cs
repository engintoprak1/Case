using System.Text.RegularExpressions;

namespace Application.Extensions;

public sealed class InputValidation
{
    private static readonly Regex coordinatePattern = new(@"^\d+ \d+$");
    private static readonly Regex currentLocationPattern = new(@"^\d+ \d+ [A-Z]$");
    private static readonly Regex commandPattern = new(@"^[LMR]*$");

    public static bool IsValidCoordinate(string input)
    {
        return coordinatePattern.IsMatch(input);
    } 
    
    public static bool IsValidLocation(string input)
    {
        return currentLocationPattern.IsMatch(input);
    }

    public static bool IsValidCommand(string input)
    {
        return commandPattern.IsMatch(input);
    }

    public static string GetValidInput(string message, Func<string, bool> validationFunc, string errorMessage)
    {
        while (true)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Lütfen bir değer giriniz.");
            }
            else if (!validationFunc(input))
            {
                Console.WriteLine(errorMessage);
            }
            else
            {
                return input; // Geçerli bir giriş alındığında döngüden çık
            }
        }
    }
}
