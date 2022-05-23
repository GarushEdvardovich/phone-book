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
        public Address GetAddress()
        {
            return new Address()
            {
                Id = this.Id,
                City = this.City,
                Street = this.Street,
                Building = this.Building,
                Apartment = this.Apartment,
            };
        }


        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string Apartment { get; set; }
      //  public Status Status  { get; set; } delete i hamara petq
    }
}
