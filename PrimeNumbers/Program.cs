using System;
using System.Linq;

const int startNumber = 1;
const int endNumber = 1000;

Console.WriteLine($"The prime numbers between {startNumber} and {endNumber} are:");

var numbers = Enumerable
    .Range(startNumber, endNumber - startNumber)
    .Where(IsPrime);

Console.WriteLine(string.Join(", ", numbers));
Console.WriteLine("\nPress Enter to exit");
Console.ReadLine();

static bool IsPrime(int number)
{
    bool CalculatePrime(int value)
    {
        var possibleFactors = Math.Sqrt(number);
        for (var factor = 2; factor <= possibleFactors; factor++)
        {
            if (value % factor == 0)
            {
                return false;
            }
        }

        return true;
    }

    return number > 1 && CalculatePrime(number);
}