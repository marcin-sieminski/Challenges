using System;
using System.Collections.Generic;

namespace Foreach
{
    public class Program
    {
        static void Main()
        {
            var peopleNames = GetPeopleNames();

            Console.WriteLine("There are the following names on the list:");

            foreach (var personName in peopleNames)
            {
                Console.WriteLine($"{personName.FirstName} {personName.LastName}");
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static List<PersonModel> GetPeopleNames()
        {
            var output = new List<PersonModel>
            {
                new("Anna", "Kowalska"),
                new("Jan", "Kowalski"),
                new("Wojciech", "Abacki"),
                new("Joanna", "Cabacka")
            };
            return output;
        }
    }
}
