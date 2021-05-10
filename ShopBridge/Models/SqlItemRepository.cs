using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Models
{
    public class SqlItemRepository : IItemRepository
    {
        private readonly AppDbContext appDbContext;

        public SqlItemRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Item> AddItem(Item item)
        {
            await appDbContext.items.AddAsync(item);
            await appDbContext.SaveChangesAsync();
            return item;
        }

        public async Task<Item> DeleteItem(int id)
        {
            Item item = await appDbContext.items.FindAsync(id);
            if (item != null)
            {
                 appDbContext.items.Remove(item);
                await  appDbContext.SaveChangesAsync();
            }
            return item;
        }

        public async Task<IEnumerable<Item>> GetAll()
        {
            var result = await appDbContext.items.ToListAsync();
            return result.AsQueryable();
        }

        public async Task<Item> GetItem(int id)
        {
            Item item =  await appDbContext.items.FindAsync(id);
            return item;
        }

        public async Task<Item> UpdateItem(Item itemChanges)
        {
            var item = appDbContext.items.Attach(itemChanges);
            item.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await appDbContext.SaveChangesAsync();
            return itemChanges;
        }
    }
}
