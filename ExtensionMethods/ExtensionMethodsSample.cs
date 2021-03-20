using System;

namespace ExtensionMethods
{
    public static class ExtensionMethodsSample
    {
        public static void Print(this string stringToPrint)
        {
            Console.WriteLine(stringToPrint);
        }

        public static string Excite(this string stringToExcite)
        {
            return stringToExcite.Replace('.', '!');
        }

        public static Person Fill(this Person inputPerson)
        {
            Console.Write("Enter first name: ");
            inputPerson.FirstName = Console.ReadLine();
            Console.Write("Enter last name: ");
            inputPerson.LastName = Console.ReadLine();
            Console.Write("Enter age: ");
           var ageInputString = Console.ReadLine();
           inputPerson.Age = int.Parse(ageInputString);
           return inputPerson;
        }

        public static Person Print(this Person inputPerson)
        {
            Console.WriteLine($"{inputPerson.FirstName} {inputPerson.LastName} is {inputPerson.Age} years old");
            return inputPerson;
        }

        public static double Add(this double input, double x)
        {
            return input + x;
        }

        public static double Subtract(this double input, double x)
        {
            return input - x;
        }

        public static double MultiplyBy(this double input, double x)
        {
            return input * x;
        }
        
        public static double DivideBy(this double input, double x)
        {
            return input / x;
        }
    }
}
