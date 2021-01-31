namespace CopyObjectsUI
{
    public class AddressModel
    {
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public AddressModel()
        {
            
        }

        public AddressModel(AddressModel sourceAddress)
        {
            StreetAddress = sourceAddress.StreetAddress;
            City = sourceAddress.City;
            State = sourceAddress.State;
            ZipCode = sourceAddress.ZipCode;
        }
    }
}