using MyPhoneBook.Models;


namespace MyPhoneBook.Bll.IMyPhoneBookServices
{
    public interface IContactService
    {        
        Task<List<ContactModel>> GetContacts();
        Task<ContactModel> AddContact(ContactModel contactModel);
        Task<ContactModel> GetContactById(int id);
        Task<bool> DeleteContact(int id);
        Task<ContactModel> UpdateContact(int id, ContactModel contactModel);

    }
}
