using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Storage.Models;

namespace Storage.Services
{
    public class MockDataStore : IDataStore<StorageBox>
    {
        
        readonly List<StorageBox> items;

        public MockDataStore()
        {
            List<string> freshItemsList = new List<string>();
            freshItemsList.Add("mirror");
            freshItemsList.Add("dresser");

            items = new List<StorageBox>()
            {
                new StorageBox { Id = Guid.NewGuid().ToString(), BoxName = "First box", BoxLocation="Basement.", ItemsInBox = freshItemsList},
                new StorageBox { Id = Guid.NewGuid().ToString(), BoxName = "Second box", BoxLocation="Attic.", ItemsInBox = freshItemsList },
                new StorageBox { Id = Guid.NewGuid().ToString(), BoxName = "Third box", BoxLocation="Uhaul.", ItemsInBox = freshItemsList },
                new StorageBox { Id = Guid.NewGuid().ToString(), BoxName = "Fourth box", BoxLocation="Basement.", ItemsInBox = freshItemsList },
                new StorageBox { Id = Guid.NewGuid().ToString(), BoxName = "Fifth box", BoxLocation="Storage facility.", ItemsInBox = freshItemsList },
                new StorageBox { Id = Guid.NewGuid().ToString(), BoxName = "Sixth box", BoxLocation="Uhaul.", ItemsInBox = freshItemsList }
            };
        }

        public async Task<bool> AddItemAsync(StorageBox item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(StorageBox item)
        {
            var oldItem = items.Where((StorageBox arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((StorageBox arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<StorageBox> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<StorageBox>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
