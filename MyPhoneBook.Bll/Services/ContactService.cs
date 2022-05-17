using Microsoft.EntityFrameworkCore;
using MyPhoneBook.Bll.IMyPhoneBookServices;
using MyPhoneBook.Dal.Model;
using MyPhoneBook.Models;

//TODO: Replace with Interface DBContext

namespace MyPhoneBook.Bll.Services
{
    public class ContactService : IContactService
    {
        //TO DO: If a record with same FirstName and/or Primary Phone Number exists and is with status Deleted we can recover it.
        private readonly IMyPhoneBookContext _dbContext;
        public ContactService(IMyPhoneBookContext context)
        {
            _dbContext = context;
        }

        public async Task<ContactModel> AddContact(ContactModel contactModel)
        {
            if (string.IsNullOrWhiteSpace(contactModel.FirstName))
            {
                throw new Exception("First name in the contact is mandatory.");
            }

            var contactRecord = new Contact()
            {    
                Id = contactModel.Id,
                AddressId = contactModel.AddressId,
                FirstName = contactModel.FirstName,
                LastName = contactModel.LastName,
                PrimaryPhoneNumber = contactModel.PrimaryPhoneNumber,
                SecondaryPhoneNumber = contactModel.SecondaryPhoneNumber,
                Email = contactModel.Email,
                Status = (int)contactModel.Status,
            };

            var savedContactRecord = _dbContext.Contacts.AddAsync(contactRecord);
            _dbContext.SaveChanges();

            var contact = await _dbContext.Contacts.Where(con => con.PrimaryPhoneNumber == contactModel.PrimaryPhoneNumber).FirstOrDefaultAsync();          
            
                return new ContactModel(contact);          
           
        }
        public async Task<ContactModel> GetContactById(int id)
        {
            {
                var contact = await _dbContext.Contacts.Where(c => c.Id == id && c.Status != (int)ContactStatus.Deleted).FirstOrDefaultAsync();
                if (contact != null)
                {
                    return new ContactModel(contact);
                }
                return null;
            }
        }

        public async Task<List<ContactModel>> GetContacts()
        {
            {
                var dbContacts = await _dbContext.Contacts.Where(c => c.Status == (int)ContactStatus.Active).ToListAsync();//.ToList();
                List<ContactModel> contactModelList = new List<ContactModel>();
                foreach (var dbContact in dbContacts)
                {
                    var contactModel = new ContactModel(dbContact);
                    contactModelList.Add(contactModel);

                }
                return contactModelList;
            }
        }

        public async Task<bool> DeleteContact(int id)
        {
            {
                var contact = await _dbContext.Contacts.Where(c => c.Id == id && c.Status == (int)ContactStatus.Active).FirstOrDefaultAsync();

                if (contact != null)
                {
                    contact.Status = (int)ContactStatus.Deleted;
                    _dbContext.SaveChanges();
                    return true;
                }
            }

            return false;
        }

        public async Task<ContactModel> UpdateContact(int id, ContactModel contactModel)
        {
            if (string.IsNullOrWhiteSpace(contactModel.FirstName))
            {
                throw new Exception("First name in the contact is mandatory.");
            }

            {
                var contact = await _dbContext.Contacts.Where(_c => _c.Id == id && _c.Status == (int)ContactStatus.Active).FirstOrDefaultAsync();
                if (contact != null)
                {
                    contact.AddressId = contactModel.AddressId;
                    contact.FirstName = contactModel.FirstName;
                    contact.LastName = contactModel.LastName;
                    contact.PrimaryPhoneNumber = contactModel.PrimaryPhoneNumber;
                    contact.SecondaryPhoneNumber = contactModel.SecondaryPhoneNumber;
                    contact.Email = contactModel.Email;
                    _dbContext.SaveChanges();
                    contactModel.Id = contact.Id;

                    return contactModel;
                }

                return null;
            }
        }
    }
}




