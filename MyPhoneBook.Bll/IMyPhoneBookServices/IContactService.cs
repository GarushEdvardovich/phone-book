using Microsoft.AspNetCore.Mvc;
using MyPhoneBook.Models;


namespace MyPhoneBook.Bll.IMyPhoneBookServices
{
    public interface IContactService
    {
        public IEnumerable<ContactModel> GetContacts();
        public ContactModel AddContact(ContactModel contactModel);
        public ContactModel GetContactById(int id);       
        public bool DeleteContact(int id);
        public ContactModel UpdateContact(ContactModel contactModel);
       // public bool UpdateContact(ContactModel contactInfo, int id);
    }
}
