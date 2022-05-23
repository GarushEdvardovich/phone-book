using MyPhoneBook.Dal.Model;

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


        }
        public Contact GetContact(ContactModel contactModel)
        {
            return new Contact()

            {
                Id = contactModel.Id,
                AddressId = contactModel.AddressId,
                FirstName = contactModel.FirstName,
                LastName = contactModel.LastName,
                PrimaryPhoneNumber = contactModel.PrimaryPhoneNumber,
                SecondaryPhoneNumber = contactModel.SecondaryPhoneNumber,
                Email = contactModel.Email
            };
        }
        public int Id { get; set; }
        public int AddressId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PrimaryPhoneNumber { get; set; }
        public string SecondaryPhoneNumber { get; set; }
        public string Email { get; set; }

    }
}


