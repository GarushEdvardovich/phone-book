using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc;
using MyPhoneBook.Bll.IMyPhoneBookServices;
using MyPhoneBook.Controllers.Models;
using MyPhoneBook.Dal.Model;
using MyPhoneBook.Models;

namespace MyPhoneBook.Bll.Services
{
    public class ContactService : IContactService
    {
        //TO DO: If a record with same FirstName and/or Primary Phone Number exists and is with status Deleted we can recover it.
        public ContactModel  AddContact(ContactModel contactModel)
        {
            if (string.IsNullOrWhiteSpace(contactModel.FirstName))
            {
                throw new Exception("First name in the contact is mandatory.");
            }

            using (var dbContext = new MyPhoneBookContext())
            {
                var contactRecord = new Contact()                        
                {                   
                    FirstName = contactModel.FirstName,
                    LastName = contactModel.LastName,
                    PrimaryPhoneNumber = contactModel.PrimaryPhoneNumber,
                    SecondaryPhoneNumber = contactModel.SecondaryPhoneNumber,
                    Status = (int)ContactStatus.Active,
                    Email = contactModel.Email,
                };

                var savedContactRecord =  dbContext.Contacts.Add(contactRecord);
                dbContext.SaveChanges();               
                contactModel.Id = savedContactRecord.Entity.Id;

                return contactModel;                
            }
        }

        public ContactModel GetContactById(int id)
        {
            using (var dbContext = new MyPhoneBookContext())
            {
                var contact = dbContext.Contacts.Where(c => c.Id == id && c.Status != (int)ContactStatus.Deleted).FirstOrDefault();

                if (contact != null)
                {
                    return new ContactModel(contact);
                }

                return null;
            }
        }

        public IEnumerable<ContactModel> GetContacts()
        {
            using (var dbContext = new MyPhoneBookContext())
            {
                var dbContacts = dbContext.Contacts.Where(c => c.Status != (int)ContactStatus.Deleted).ToList();

                foreach (var dbContact in dbContacts)
                {
                    var contact = new ContactModel(dbContact);
                    yield return contact;
                }
            }
        }

        public bool DeleteContact(int id)
        {
            using (var dbContext = new MyPhoneBookContext())
            {
                var contact = dbContext.Contacts.Where(c => c.Id == id && c.Status != (int)ContactStatus.Deleted).FirstOrDefault();

                if (contact != null)
                {
                    contact.Status = (int)ContactStatus.Deleted;
                    dbContext.SaveChanges();
                    return true;
                }
            }

            return false;
        }

        public ContactModel UpdateContact(ContactModel contactModel)
        {
            if (string.IsNullOrWhiteSpace(contactModel.FirstName))
            {
                throw new Exception("First name in the contact is mandatory.");
            }

            using (var dbContext = new MyPhoneBookContext())
            {
                var contact = dbContext.Contacts.Where(c => c.Id == contactModel.Id && c.Status != (int)ContactStatus.Deleted).FirstOrDefault();
                
                if (contact != null)
                {                    
                    contact.FirstName = contactModel.FirstName;
                    contact.LastName = contactModel.LastName;
                    contact.PrimaryPhoneNumber = contactModel.PrimaryPhoneNumber;
                    contact.SecondaryPhoneNumber = contactModel.SecondaryPhoneNumber;
                    contact.Email = contactModel.Email;                    
                    dbContext.SaveChanges();

                    return contactModel;
                }

                return null;
            }
        }
    }
}




