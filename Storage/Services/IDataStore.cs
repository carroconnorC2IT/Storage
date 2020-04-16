using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Storage.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T storageBox);
        Task<bool> UpdateItemAsync(T storageBox);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
