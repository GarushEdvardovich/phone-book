using System.ComponentModel.DataAnnotations;

namespace MyPhoneBook.Requests
{
    public class ContactRequest
    {
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string PrimaryPhoneNumber { get; set; }
        public string SecondaryPhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
