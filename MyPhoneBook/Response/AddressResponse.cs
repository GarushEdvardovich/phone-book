using MyPhoneBook.Models;
using System.ComponentModel.DataAnnotations;

namespace MyPhoneBook.Response
{
    public class AddressResponse
    {
        [Required]
        public int Id { get; set; }       
        public string City { get; set; }
        public string Street { get; set; } 
        public string Building { get; set; } 
        public string Apartment { get; set; }  
        public AddressResponse(AddressModel addressModel)
        {
            Id = addressModel.Id;           
            City = addressModel.City;
            Street = addressModel.Street;
            Building = addressModel.Building;
            Apartment = addressModel.Apartment;
        }       
        public static List<AddressResponse> GetResponseList(List<AddressModel> addressModels)
        {
            List<AddressResponse> addresses = new List<AddressResponse>();
            foreach (var addressModel in addressModels)
            {
                var addressResponce = new AddressResponse(addressModel);
                addresses.Add(addressResponce);
            }
            return addresses;
        }
    }
}
