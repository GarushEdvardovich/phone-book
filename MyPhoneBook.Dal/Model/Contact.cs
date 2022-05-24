namespace MyPhoneBook.Dal.Model
{
    public class Contact
    {       
        public int Id { get; set; }
        public int AddressId { get; set; }  
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PrimaryPhoneNumber { get; set; }
        public string SecondaryPhoneNumber { get; set; }
        public string Email { get; set; }
        public int Status { get; set; }
       

    }
}
