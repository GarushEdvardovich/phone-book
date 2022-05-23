using Microsoft.AspNetCore.Mvc;
using MyPhoneBook.Models;
using System.ComponentModel.DataAnnotations;

namespace MyPhoneBook.Requests
{    
    public class ContactRequest
    {
        [Range(0, int.MaxValue)]
        public int Id { get; set; }  
        [Range(1, int.MaxValue)]
        public int AddressId { get; set; }
        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 3)]
        public string FirstName { get; set; }
        [StringLength(maximumLength: 30, MinimumLength = 3)]
        public string LastName { get; set; }
        [Required]
        [Phone]
        public string PrimaryPhoneNumber { get; set; }
        [Phone]
        public string SecondaryPhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        public ContactModel GetPostContactModel()
        {
            return new ContactModel()
            {
                Id = 0,
                AddressId = AddressId,
                FirstName = this.FirstName,
                LastName = this.LastName,
                PrimaryPhoneNumber = this.PrimaryPhoneNumber,
                SecondaryPhoneNumber = this.SecondaryPhoneNumber,
                Email = this.Email,
            };

        }

        public ContactModel GetPutContactModel()
        {
            return new ContactModel()
            {
                Id = this.Id,
                AddressId = this.AddressId,
                FirstName = this.FirstName,
                LastName = this.LastName,
                PrimaryPhoneNumber = this.PrimaryPhoneNumber,
                SecondaryPhoneNumber = this.SecondaryPhoneNumber,
            };

        }
    }
}
