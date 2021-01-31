using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CopyObjectsUI
{
    public static class Program
    {
        public static void Main()
        {
            var firstPerson = new PersonModel
            {
                FirstName = "Sue",
                LastName = "Storm",
                DateOfBirth = new DateTime(1998, 7, 19),
                Addresses = new List<AddressModel>
                {
                    new AddressModel
                    {
                        StreetAddress = "101 State Street",
                        City = "Salt Lake City",
                        State = "UT",
                        ZipCode = "76321"
                    },
                    new AddressModel
                    {
                        StreetAddress = "842 Lawrence Way",
                        City = "Jupiter",
                        State = "FL",
                        ZipCode = "22558"
                    }
                }
            };

            // Set the value of the secondPerson and thirdPerson to be a copy of the firstPerson
            var secondPerson = CopyPersonWithSerialization(firstPerson);
            var thirdPerson = new PersonModel(firstPerson);

            // Update the secondPerson's and thirdPerson's FirstName to "Bob" 
            // and change the Street Address for each of Bob's addresses to a different value
            secondPerson.FirstName = "Bob";
            secondPerson.Addresses[0].StreetAddress = "2 State Street";
            secondPerson.Addresses[1].StreetAddress = "1 Lawrence Way";
            thirdPerson.FirstName = "Bob";
            thirdPerson.Addresses[0].StreetAddress = "2 State Street";
            thirdPerson.Addresses[1].StreetAddress = "1 Lawrence Way";

            // Ensure that the following statements are true
            Console.WriteLine($"{ firstPerson.FirstName } != { secondPerson.FirstName }");
            Console.WriteLine($"{ firstPerson.LastName } == { secondPerson.LastName }");
            Console.WriteLine($"{ firstPerson.DateOfBirth.ToShortDateString() } == { secondPerson.DateOfBirth.ToShortDateString() }");
            Console.WriteLine($"{ firstPerson.Addresses[0].StreetAddress } != { secondPerson.Addresses[0].StreetAddress }");
            Console.WriteLine($"{ firstPerson.Addresses[0].City } == { secondPerson.Addresses[0].City }");
            Console.WriteLine($"{ firstPerson.Addresses[1].StreetAddress } != { secondPerson.Addresses[1].StreetAddress }");
            Console.WriteLine($"{ firstPerson.Addresses[1].City } == { secondPerson.Addresses[1].City }");
            Console.WriteLine();
            Console.WriteLine($"{ firstPerson.FirstName } != { thirdPerson.FirstName }");
            Console.WriteLine($"{ firstPerson.LastName } == { thirdPerson.LastName }");
            Console.WriteLine($"{ firstPerson.DateOfBirth.ToShortDateString() } == { thirdPerson.DateOfBirth.ToShortDateString() }");
            Console.WriteLine($"{ firstPerson.Addresses[0].StreetAddress } != { thirdPerson.Addresses[0].StreetAddress }");
            Console.WriteLine($"{ firstPerson.Addresses[0].City } == { thirdPerson.Addresses[0].City }");
            Console.WriteLine($"{ firstPerson.Addresses[1].StreetAddress } != { thirdPerson.Addresses[1].StreetAddress }");
            Console.WriteLine($"{ firstPerson.Addresses[1].City } == { thirdPerson.Addresses[1].City }");

            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();
        }

        private static PersonModel CopyPersonWithSerialization(PersonModel sourcePerson)
        {
            var temporaryPerson = JsonConvert.SerializeObject(sourcePerson);
            var destinationPerson = JsonConvert.DeserializeObject<PersonModel>(temporaryPerson);
            return destinationPerson;
        }
    }
}
