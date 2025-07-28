using BussinessLayer.DTOs.BorrowRecord;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BussinessLayer.Services.Interface
{
    public interface IBorrowOrderService
    {
        // Checkout giỏ hàng và tạo BorrowOrder
        Task<BorrowOrderDto> CheckoutCartAsync(string studentCode);

        // Admin duyệt phiếu mượn
        Task ApproveBorrowOrderAsync(string orderId);

        // Trả sách
        Task ReturnBookAsync(string recordId);

        // Lấy danh sách đơn mượn của sinh viên
        Task<List<BorrowOrderDto>> GetOrdersByStudentAsync(string studentCode);
        Task<bool> CancelBorrowOrderAsync(string orderId);
    }
}
