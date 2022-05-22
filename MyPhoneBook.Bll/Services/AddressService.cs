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
            _dbContext.SaveChanges();
            return new AddressModel(savedAddressRecord.Entity);
         
        }   
        public async Task<List<AddressModel>> GetAddresses()
        {
            {
                var dbAddresses = await _dbContext.Contacts.Where(c => c.Status == (int)Status.Active).ToListAsync();
                var addresses = await _dbContext.Addresses.ToListAsync();
                List<AddressModel> addressModelList = new List<AddressModel>();
                
                foreach (var address in addresses)
                {
                    var dbAddress = new AddressModel(address);
                    addressModelList.Add(dbAddress);
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
                var oldAddress = await _dbContext.Addresses.Where(a => a.Id == id && a.Status == (int)Status.Active).FirstOrDefaultAsync();
                
                if (oldAddress != null)
                {
                    oldAddress.City = updatedAddressModel.City;
                    oldAddress.Street = updatedAddressModel.Street;
                    oldAddress.Building = updatedAddressModel.Building;
                    oldAddress.Apartment = updatedAddressModel.Apartment;
                    _dbContext.SaveChanges();
                    updatedAddressModel.Id = id;
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
                    _dbContext.SaveChanges();
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
