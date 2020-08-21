using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressBook.Models;

namespace AddressBook.DataAccessLayer.AddressRepository
{
    public interface IAddressRepository
    {
        public Task<List<AddressItem>> GetAllItems();
        public Task<AddressItem> GetItemById(int id);
        public Task AddNewItem(AddressItem addressItem);
        public Task EditItem(AddressItem addressItem);
        public Task DeleteItem(int id);
        public Task<List<AddressItem>> SearchItem(SearchModel model);
    }
}
