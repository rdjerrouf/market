using System.Threading.Tasks;
using market.Data;
using market.Models;
using Microsoft.EntityFrameworkCore;

namespace market.Services
{
    public class UserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var existingItem = await _context.Items.Include(i => i.User).FirstOrDefaultAsync(i => i.Id == item.Id);
            if (existingItem == null)
            {
                return false;
            }

            existingItem.Name = item.Name;
            existingItem.Description = item.Description;
            existingItem.Price = item.Price;
            existingItem.User = item.User; // Update the User object

            _context.Items.Update(existingItem);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}