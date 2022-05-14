using Microsoft.EntityFrameworkCore;
using MyPhoneBook.Dal.Model;

namespace MyPhoneBook.Bll.IMyPhoneBookServices
{
    public interface IMyPhoneBookContext
    {
        DbSet<Contact> Contacts { get; set; }
        DbSet<Address> Addresses { get; set; }
        void SaveChanges();
    }
}
