using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyPhoneBook.Dal.Model;

namespace MyPhoneBook.Bll.ContactConfig
{
    public class ContactConfig : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.ToTable<Contact>("Contact");
        }
    }

    public class AddressConfig : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.ToTable<Address>("Address");
        }
    }
}
