using BussinessLayer.DTOs.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Services.Interface
{
    public interface ICartService
    {
        Task<IEnumerable<CartItemDto>> GetCartItemsByStudentCodeAsync(string studentCode);
        Task<bool> AddToCartAsync(string studentCode, string bookId, int quantity);
        Task<bool> RemoveFromCartAsync(string studentCode, string bookId);
        Task<bool> UpdateQuantityAsync(string studentCode, string bookId, int quantity);
        Task<int> GetTotalQuantityAsync(string studentCode);
        Task<bool> ClearCartAsync(string studentCode);
    }
}
