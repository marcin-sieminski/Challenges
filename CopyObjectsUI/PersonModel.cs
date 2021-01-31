using System;
using System.Collections.Generic;

namespace CopyObjectsUI
{
    public class PersonModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<AddressModel> Addresses { get; set; } = new List<AddressModel>();

        public PersonModel()
        {
            
        }

        public PersonModel(PersonModel sourcePerson)
        {
            FirstName = sourcePerson.FirstName;
            LastName = sourcePerson.LastName;
            DateOfBirth = sourcePerson.DateOfBirth;
            foreach (var sourcePersonAddress in sourcePerson.Addresses)
            {
                var newAddress = new AddressModel(sourcePersonAddress);
                Addresses.Add(newAddress);
            }
        }
    }
}