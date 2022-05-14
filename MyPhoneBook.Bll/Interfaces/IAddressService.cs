using MyPhoneBook.Models;




namespace MyPhoneBook.Bll.IMyPhoneBookServices
{
    public interface IAddressService
    {
        Task<List<AddressModel>> GetAddresses();
        // public IEnumerable<AddressModel> GetAddresses();
        Task<AddressModel> AddAddress(AddressModel address);
        // public AddressModel AddAddress(AddressModel address);
        Task<AddressModel> GetAddressById(int id);
        // public AddressModel GetAddressById(int id);
        Task<AddressModel> UpdateAddressComplete(int id, AddressModel updatedAddressModel);
        // public AddressModel UpdateAddressComplete(int id, AddressModel addressModel);
        Task<bool> DeleteAddress(int id);
        // public bool DeleteAddress(int id);

        //  public AddressModel UpdateAddressPartial(AddressModel addressModel);
    }
}
