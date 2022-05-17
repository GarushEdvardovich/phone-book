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
            AddressId = contact.AddressId;
            FirstName = contact.FirstName;
            LastName = contact.LastName;
            PrimaryPhoneNumber = contact.PrimaryPhoneNumber;
            SecondaryPhoneNumber = contact.SecondaryPhoneNumber;
            Email = contact.Email;
            Status = (ContactStatus)(int)contact.Status;            

        }

        public int Id { get; set; }
        public int AddressId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PrimaryPhoneNumber { get; set; }
        public string SecondaryPhoneNumber { get; set; }
        public string Email { get; set; }      
        public ContactStatus Status { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
