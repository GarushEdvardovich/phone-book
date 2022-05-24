using MyPhoneBook.Models;
using System.ComponentModel.DataAnnotations;

namespace MyPhoneBook.Requests
{
    public class AddressRequest
    {   [Range (0, int.MaxValue)]        
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string Apartment { get; set; }
        public AddressModel GetPostAddressModel()
        {
            return new AddressModel()
            {
                Id = 0,
                City = this.City,
                Street = this.Street,
                Building = this.Building,
                Apartment = this.Apartment,
            };

        }

        public AddressModel GetPutAddressModel()
        {
            return new AddressModel()
            {
                Id = this.Id,
                City = this.City,
                Street = this.Street,
                Building = this.Building,
                Apartment = this.Apartment,
            };

        }
    }
}
