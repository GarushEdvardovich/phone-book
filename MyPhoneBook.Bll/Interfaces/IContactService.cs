using MyPhoneBook.Models;


namespace MyPhoneBook.Bll.IMyPhoneBookServices
{
    public interface IContactService
    {
        //Task<ContactModel> GetContacts();
        Task<List<ContactModel>> GetContacts();
        //public IEnumerable<ContactModel> GetContacts();
        Task<ContactModel> AddContact(ContactModel contactModel);
        Task<ContactModel> GetContactById(int id);
        // public ContactModel GetContactById(int id);
        Task<bool> DeleteContact(int id);
        // public bool DeleteContact(int id);
        Task<ContactModel> UpdateContact(int id, ContactModel contactModel);
        //public ContactModel UpdateContact(int id, ContactModel contactModel);

    }
}
