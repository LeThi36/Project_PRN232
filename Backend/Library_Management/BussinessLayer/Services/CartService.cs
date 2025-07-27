using AutoMapper;
using BussinessLayer.DTOs.Cart;
using BussinessLayer.Services.Interface;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace BussinessLayer.Services
{
    public class CartService : ICartService
    {
        private readonly ProjectPrn232Context _context;
        private readonly IMapper _mapper;

        public CartService(ProjectPrn232Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CartItemDto>> GetCartItemsByStudentCodeAsync(string studentCode)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.StudentCode == studentCode);
            if (user == null) return new List<CartItemDto>();

            var cart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == user.Id);
            if (cart == null) return new List<CartItemDto>();

            var cartItems = await _context.CartItems
                .Include(ci => ci.Book)
                    .ThenInclude(b => b.Author)
                .Where(ci => ci.CartId == cart.Id)
                .ToListAsync();

            return _mapper.Map<IEnumerable<CartItemDto>>(cartItems);
        }

        public async Task<bool> AddToCartAsync(string studentCode, string bookId, int quantity)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.StudentCode == studentCode);
            if (user == null) return false;

            var cart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == user.Id);
            if (cart == null)
            {
                cart = new Cart
                {
                    Id = Guid.NewGuid().ToString(),
                    UserId = user.Id,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };
                _context.Carts.Add(cart);
                await _context.SaveChangesAsync();
            }

            var existingItem = await _context.CartItems
                .FirstOrDefaultAsync(ci => ci.CartId == cart.Id && ci.BookId == bookId);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
                existingItem.UpdatedAt = DateTime.UtcNow;
            }
            else
            {
                var newItem = new CartItem
                {
                    Id = Guid.NewGuid().ToString(),
                    CartId = cart.Id,
                    BookId = bookId,
                    Quantity = quantity,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };
                _context.CartItems.Add(newItem);
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveFromCartAsync(string studentCode, string bookId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.StudentCode == studentCode);
            if (user == null) return false;

            var cart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == user.Id);
            if (cart == null) return false;

            var item = await _context.CartItems
                .FirstOrDefaultAsync(c => c.CartId == cart.Id && c.BookId == bookId);

            if (item == null) return false;

            _context.CartItems.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateQuantityAsync(string studentCode, string bookId, int quantity)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.StudentCode == studentCode);
            if (user == null) return false;

            var cart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == user.Id);
            if (cart == null) return false;

            var item = await _context.CartItems
                .FirstOrDefaultAsync(c => c.CartId == cart.Id && c.BookId == bookId);

            if (item == null) return false;

            if (quantity <= 0)
            {
                _context.CartItems.Remove(item);
            }
            else
            {
                item.Quantity = quantity;
                item.UpdatedAt = DateTime.UtcNow;
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<int> GetTotalQuantityAsync(string studentCode)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.StudentCode == studentCode);
            if (user == null) return 0;

            var cart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == user.Id);
            if (cart == null) return 0;

            return await _context.CartItems
                .Where(ci => ci.CartId == cart.Id)
                .SumAsync(ci => ci.Quantity);
        }

        public async Task<bool> ClearCartAsync(string studentCode)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.StudentCode == studentCode);
            if (user == null) return false;

            var cart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == user.Id);
            if (cart == null) return false;

            var items = _context.CartItems.Where(ci => ci.CartId == cart.Id);
            _context.CartItems.RemoveRange(items);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
