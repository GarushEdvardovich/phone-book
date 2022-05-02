using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhoneBook.Dal.Model
{
    public class Contact
    {
        public Contact()
        {
            Addresses = new List<Address  >(); // te HashSet
        }
        public int Id { get; set; }       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PrimaryPhoneNumber { get; set; }
        public string SecondaryPhoneNumber { get; set; }  
        
        public string Email { get; set; }
        public int Status { get; set; }           
        public virtual ICollection<Address> Addresses { get; set; }

    }
}
