using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhoneBook.Dal.Model
{
    public class Address
    {

        public int Id { get; set; }
        public int ContactId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string Appartment { get; set; }
        public int Status { get; set; }
      
    }
}
