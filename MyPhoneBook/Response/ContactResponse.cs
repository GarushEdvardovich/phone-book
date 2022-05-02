using MyPhoneBook.Models;

namespace MyPhoneBook.Response
{
    public class ContactResponse
    {
        public int Id { get; set; }        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PrimaryPhoneNumber { get; set; }
        public string SecondaryPhoneNumber { get; set; }  
        public string Email { get; set; }
        public ContactResponse(ContactModel contactModel)
        {
            Id = contactModel.Id;           
            FirstName = contactModel.FirstName;
            LastName = contactModel.LastName;
            PrimaryPhoneNumber = contactModel.PrimaryPhoneNumber;
            SecondaryPhoneNumber = contactModel.SecondaryPhoneNumber;   
            Email = contactModel.Email;            
        }
    }

}
