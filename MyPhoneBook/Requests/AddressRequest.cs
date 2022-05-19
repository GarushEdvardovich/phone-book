using System.ComponentModel.DataAnnotations;

namespace MyPhoneBook.Requests
{
    public class AddressRequest
    {
        [Required]
        [Range (1, int.MaxValue)]
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string Apartment { get; set; }

    }
}
