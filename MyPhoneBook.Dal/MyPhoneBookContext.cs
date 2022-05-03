using Microsoft.EntityFrameworkCore;
using System.Reflection;
using MyPhoneBook.Dal.Model;

namespace MyPhoneBook.Controllers.Models  
{
   
    public class MyPhoneBookContext:DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           => optionsBuilder.UseNpgsql("Host=localhost;Database=MyPhonebook;Username=postgres;Password=12061988");
        public MyPhoneBookContext() { }
        public MyPhoneBookContext(DbContextOptions<MyPhoneBookContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<Contact>().HasKey(x => x.Id);
            modelBuilder.Entity<Contact>().ToTable("Contacts");
            modelBuilder.Entity<Address>().HasKey(x => x.Id);
            modelBuilder.Entity<Address>().ToTable("Addresses");

            base.OnModelCreating(modelBuilder);
        }
    }
   
}
