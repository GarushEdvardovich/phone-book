using Microsoft.EntityFrameworkCore;
using MyPhoneBook.Bll.IMyPhoneBookServices;
using MyPhoneBook.Dal.Model;

namespace MyPhoneBook.Controllers.Models
{


    public class MyPhoneBookContext : DbContext, IMyPhoneBookContext
    {
        private readonly string _connectionString;
        private DbContextOptions<MyPhoneBookContext> _options;

        public MyPhoneBookContext(DbContextOptions<MyPhoneBookContext> options) : base(options)
        {
            _options = options;
            Console.WriteLine("MyPhoneBookContext with options is called");
        }

        public MyPhoneBookContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasKey(x => x.Id);
            modelBuilder.Entity<Contact>().ToTable("Contacts");
            modelBuilder.Entity<Address>().HasKey(x => x.Id);
            modelBuilder.Entity<Address>().ToTable("Addresses");

            base.OnModelCreating(modelBuilder);
        }

        void IMyPhoneBookContext.SaveChanges()
        {
            SaveChanges();
        }
       async Task<int> IMyPhoneBookContext.SaveChangesAsync()
        {
          return await SaveChangesAsync();
          
        }
    }

}
