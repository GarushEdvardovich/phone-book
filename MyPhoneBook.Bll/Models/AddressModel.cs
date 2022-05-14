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
            ContactId = address.ContactId;
            City = address.City;
            Street = address.Street;
            Building = address.Building;
            Appartment = address.Appartment;
            Status = (ContactStatus)(int)address.Status;
        }

        public int Id { get; set; }
        public int ContactId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string Appartment { get; set; }
        public ContactStatus Status { get; set; }
    }
}
