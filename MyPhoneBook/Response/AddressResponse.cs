using MyPhoneBook.Models;


namespace MyPhoneBook.Response
{
    public class AddressResponse
    {
        public int Id { get; set; }
        public int ContactId { get; set; }  
        public string City { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string Appartament { get; set; }
        public AddressResponse(AddressModel addressModel)
        {
            Id = addressModel.Id;
            ContactId = addressModel.ContactId;
            City = addressModel.City;
            Street = addressModel.Street;
            Building = addressModel.Building;
            Appartament = addressModel.Appartment;
        }
        public AddressResponse()
        {
        }

    }
}
