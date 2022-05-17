using System.ComponentModel.DataAnnotations;

namespace MyPhoneBook.Requests
{
    public class ContactRequest
    {
        [Required]
      //  [Range(1, int.MaxValue)]
        public int Id { get; set; }
        public int AddressId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
       // [Phone]
        public string PrimaryPhoneNumber { get; set; }
        public string SecondaryPhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
