using Microsoft.AspNetCore.Mvc;
using MyPhoneBook.Models;




namespace MyPhoneBook.Bll.IMyPhoneBookServices
{
    public interface IAddressService
    {
        public IEnumerable<AddressModel> GetAddresses();
        public AddressModel AddAddress(AddressModel address);
        public AddressModel GetAddressById(int id);
        public AddressModel UpdateAddressComplete(AddressModel addressModel);
        public bool DeleteAddress(int id);
      //  public AddressModel UpdateAddressPartial(AddressModel addressModel);
    }
}
