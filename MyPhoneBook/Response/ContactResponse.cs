using MyPhoneBook.Dal.Model;
using MyPhoneBook.Models;
using System.ComponentModel.DataAnnotations;

namespace MyPhoneBook.Response
{
    public class ContactResponse
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int AddressId { get; set; }  
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string PrimaryPhoneNumber { get; set; }
        public string SecondaryPhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public ContactResponse(ContactModel contactModel)
        {
            Id = contactModel.Id;
            AddressId = contactModel.AddressId;
            FirstName = contactModel.FirstName;
            LastName = contactModel.LastName;
            PrimaryPhoneNumber = contactModel.PrimaryPhoneNumber;
            SecondaryPhoneNumber = contactModel.SecondaryPhoneNumber;
            Email = contactModel.Email;
            
        }
        //public ContactResponse()
        //{

        //}
        public static List<ContactResponse> GetResponseList(List<ContactModel> contactModels)
        {
            List<ContactResponse> contacts = new List<ContactResponse>();
            foreach (var contactModel in contactModels)
            {
                var contactResponse = new ContactResponse(contactModel);
                contacts.Add(contactResponse);
            }
            return contacts;
        }
    }
}
