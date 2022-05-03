using Microsoft.AspNetCore.Mvc;
using MyPhoneBook.Bll.IMyPhoneBookServices;
using MyPhoneBook.Controllers.Models;
using MyPhoneBook.Dal.Model;
using MyPhoneBook.Models;


namespace MyPhoneBook.Bll.Services
{
    public class AddressService : IAddressService
    {
        public AddressModel AddAddress(AddressModel address)
        {
            using (var dbContext = new MyPhoneBookContext())
            {
                var dbaddress = new Address()
                {
                    ContactId = address.ContactId,
                    City = address.City,
                    Street = address.Street,
                    Building = address.Building,
                    Appartment = address.Appartment,            
                   
                };

                dbContext.Add(dbaddress);
                dbContext.SaveChanges();
                address.Id = dbaddress.Id;
                return address;
            }
        }

        public IEnumerable<AddressModel> GetAddresses()
        {
            using (var dbContext = new MyPhoneBookContext())
            {
                var addresses = dbContext.Addresses.Where(c => c.Status != (int)ContactStatus.Deleted).ToList();

                foreach (var address in addresses)
                {
                    var dbAddress = new AddressModel(address);

                    yield return dbAddress;
                }
            }
        }

        public AddressModel GetAddressById(int id)
        {
            using (var dbContext = new MyPhoneBookContext())
            {
                var address = dbContext.Addresses.Where(a => a.Id == id && a.Status != (int)ContactStatus.Deleted).FirstOrDefault();

                if (address != null)
                {
                    return new AddressModel(address);
                }

                return null;
            }
        }

        public AddressModel UpdateAddressComplete(AddressModel updatedAddressModel)
        {
            using (var dbContext = new MyPhoneBookContext())
            {
                var oldAddress = dbContext.Addresses.Where(a => a.Id == updatedAddressModel.Id && a.Status == (int)ContactStatus.Deleted).FirstOrDefault();
                if (oldAddress != null)
                {
                    oldAddress.ContactId = updatedAddressModel.ContactId;
                    oldAddress.City = updatedAddressModel.City;
                    oldAddress.Street = updatedAddressModel.Street;
                    oldAddress.Building = updatedAddressModel.Building;
                    oldAddress.Appartment = updatedAddressModel.Appartment;

                    dbContext.SaveChanges();

                    return updatedAddressModel;
                }

                return null;
            }
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

        public bool DeleteAddress(int id)
        {
            using (var dbContext = new MyPhoneBookContext())
            {
                var address = dbContext.Addresses.Where(a => a.Id == id && a.Status != (int)ContactStatus.Deleted).FirstOrDefault();

                if (address != null && address.Status != (int)ContactStatus.Deleted)
                {
                    address.Status =(int)ContactStatus.Deleted;
                    dbContext.SaveChanges();

                    return true;
                }

            }
            return false;
        }
    }
}
