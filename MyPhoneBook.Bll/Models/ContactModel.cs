

using MyPhoneBook.Dal.Model;
using System.ComponentModel.DataAnnotations;

namespace MyPhoneBook.Models
{
    public class ContactModel
    {
        public ContactModel()
        { }

        public ContactModel(Contact contact)
        {
            Id = contact.Id;
            FirstName = contact.FirstName;
            LastName = contact.LastName;
            PrimaryPhoneNumber = contact.PrimaryPhoneNumber;
            SecondaryPhoneNumber = contact.SecondaryPhoneNumber;
            Email = contact.Email;
            Status = (ContactStatus)(int)contact.Status;
            Addresses = contact.Addresses;
        }

        public int Id { get; set; }              
        public string FirstName { get; set; }  
        public string LastName { get; set; }    
        public string PrimaryPhoneNumber { get; set; }
        public string SecondaryPhoneNumber { get; set; }    
        [EmailAddress]
        public string Email { get; set; }  
        public ContactStatus Status { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
