using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Models
{
    public interface IItemRepository
    {
        Task<Item> GetItem(int id);
        Task<IEnumerable<Item>> GetAll();
        Task<Item> AddItem(Item item);
        Task<Item> UpdateItem(Item itemChanges);
        Task<Item> DeleteItem(int id);
    }
}
