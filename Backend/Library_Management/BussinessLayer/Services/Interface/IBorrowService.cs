using BussinessLayer.DTOs.BorrowRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Services.Interface
{
    public interface IBorrowService
    {
        // Student gửi yêu cầu mượn
        Task<BorrowRecordDto> RequestBorrowAsync(BorrowRequestDto dto);

        // Librarian xác nhận yêu cầu mượn
        Task<BorrowRecordDto> ApproveBorrowAsync(BorrowApprovalDto dto);

        // Cập nhật trạng thái quá hạn và tính tiền phạt (chạy nền hoặc thủ công)
        Task UpdateOverdueStatusesAsync();

        // Lấy danh sách mượn của 1 user (có kèm cập nhật trạng thái nếu quá hạn)
        Task<IEnumerable<BorrowRecordDto>> GetByUserIdAsync(string userId);

        Task CancelBorrowRequestAsync(string borrowId, string userId);

        // thu thu tao cho student
        Task<BorrowRecordDto> CreateBorrowByLibrarianAsync(BorrowCreateDto dto);

    }
}

