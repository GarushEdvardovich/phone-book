using MyPhoneBook.Models;




namespace MyPhoneBook.Bll.IMyPhoneBookServices
{
    public interface IAddressService
    {
        Task<List<AddressModel>> GetAddresses();
        Task<AddressModel> AddAddress(AddressModel address);
        Task<AddressModel> GetAddressById(int id);
        Task<AddressModel> UpdateAddressComplete(int id, AddressModel updatedAddressModel);
        Task<bool> DeleteAddress(int id);

    }
}
