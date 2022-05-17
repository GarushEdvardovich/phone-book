using MyPhoneBook.Dal.Model;

namespace MyPhoneBook.Models
{
    public class AddressModel
    {
        public AddressModel()
        { }
        public AddressModel(Address address)
        {
            Id = address.Id;          
            City = address.City;
            Street = address.Street;
            Building = address.Building;
            Apartment = address.Apartment;
        }

        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string Apartment { get; set; }
    }
}
