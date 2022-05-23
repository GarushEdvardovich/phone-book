using Microsoft.EntityFrameworkCore;
using MyPhoneBook.Bll.IMyPhoneBookServices;
using MyPhoneBook.Models;

//TODO: Replace with Interface DBContext

namespace MyPhoneBook.Bll.Services
{
    public class AddressService : IAddressService
    {
        private readonly IMyPhoneBookContext _dbContext;
        public AddressService(IMyPhoneBookContext context)
        {
            _dbContext = context;
        }
        public async Task<AddressModel> AddAddress(AddressModel addressModel)
        {
           var savedAddressRecord = await _dbContext.Addresses.AddAsync(addressModel.GetAddress());
           await _dbContext.SaveChangesAsync();
            return new AddressModel(savedAddressRecord.Entity);
         
        }   
        public async Task<List<AddressModel>> GetAddresses()
        {
            {
                var dbAddresses = await _dbContext.Addresses.Where(a => a.Status == (int)Status.Active).ToListAsync();                
                List<AddressModel> addressModelList = new List<AddressModel>();
                
                foreach (var dbAddress in dbAddresses)
                {
                    var addressModel = new AddressModel(dbAddress);
                    addressModelList.Add(addressModel);
                }
                return addressModelList;
               
            }
        }

        public async Task<AddressModel> GetAddressById(int id)
        {
            {

                var address = await _dbContext.Addresses.Where(a => a.Id == id && a.Status != (int)Status.Deleted).FirstOrDefaultAsync();
                
                if (address != null)
                {
                    return new AddressModel(address);
                }
                return null;
            }
        }
        public async Task<AddressModel> UpdateAddress(int id, AddressModel updatedAddressModel)
        {
            {               
                var currentAddress = await _dbContext.Addresses.Where(a => a.Id == id && a.Status == (int)Status.Active).FirstOrDefaultAsync();
                
                if (currentAddress != null)
                {
                    currentAddress.City = updatedAddressModel.City;
                    currentAddress.Street = updatedAddressModel.Street;
                    currentAddress.Building = updatedAddressModel.Building;
                    currentAddress.Apartment = updatedAddressModel.Apartment;
                    await _dbContext.SaveChangesAsync();
                    return updatedAddressModel;
                }
                return null;
            }
        }
        public async Task<bool> DeleteAddress(int id)
        {
            {
                var address = await _dbContext.Addresses.Where(a => a.Id == id && a.Status == (int)Status.Active).FirstOrDefaultAsync();
                
                if (address != null)
                {
                    address.Status = (int)Status.Deleted;
                    await _dbContext.SaveChangesAsync();
                    return true;
                }

            }
            return false;
        }

        // TO DO: Review partial update
        //public AddressModel UpdateAddressPartial(AddressModel inputAddressModel)
        //{
        //    using (var dbContext = new MyPhoneBookContext())
        //    {
        //        var oldAddress = dbContext.Addresses.Where(a => a.Id == inputAddressModel.Id).FirstOrDefault();

        //        if (oldAddress != null && oldAddress.Status != (int)ContactStatus.Deleted)
        //        {
        //            oldAddress.City = inputAddressModel.City == null ? oldAddress.City : inputAddressModel.City;
        //            oldAddress.Street = inputAddressModel.Street == null ? oldAddress.Street : inputAddressModel.Street;
        //            oldAddress.Building = inputAddressModel.Building == null ? oldAddress.Building : inputAddressModel.Building;
        //            oldAddress.Appartment = inputAddressModel.Appartment == null ? oldAddress.Appartment : inputAddressModel.Appartment;
        //            dbContext.SaveChanges();
        //            var outputAddressModel = new AddressModel
        //            {
        //                City = oldAddress.City,
        //                Street = oldAddress.Street,
        //                Building = oldAddress.Building,
        //                Appartment = oldAddress.Appartment,
        //            };
        //            return outputAddressModel;
        //        }
        //        return null;
        //    }
        //}

    }
}
