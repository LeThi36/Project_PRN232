using AutoMapper;
using BussinessLayer.DTOs.BorrowRecord;
using BussinessLayer.Services.Interface;
using DataLayer.Constants;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BussinessLayer.Services
{
    public class BorrowService : IBorrowService
    {
        private readonly ProjectPrn232Context _context;
        private readonly IMapper _mapper;

        public BorrowService(ProjectPrn232Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Student gửi yêu cầu mượn
        public async Task<BorrowRecordDto> RequestBorrowAsync(BorrowRequestDto dto)
        {
            var availableCopy = await _context.BookCopies
                .FirstOrDefaultAsync(b => b.BookId == dto.BookId && b.Status == "Available");

            if (availableCopy == null)
                throw new InvalidOperationException("No available copy.");

            var borrow = new BorrowRecord
            {
                UserId = dto.UserId,
                CopyId = availableCopy.Id,
                BorrowDate = DateTime.MinValue,  // dùng mặc định thay vì null
                DueDate = DateTime.MinValue,
                ReturnDate = null,
                ExtensionDateCount = 0,
                Fine = 0,
                Status = BorrowStatus.Pending
            };

            await _context.BorrowRecords.AddAsync(borrow);
            await _context.SaveChangesAsync();

            borrow = await _context.BorrowRecords
                .Include(b => b.Copy).ThenInclude(c => c.Book)
                .FirstAsync(b => b.Id == borrow.Id);

            return _mapper.Map<BorrowRecordDto>(borrow);
        }

        // Librarian xác nhận mượn
        public async Task<BorrowRecordDto> ApproveBorrowAsync(BorrowApprovalDto dto)
        {
            var record = await _context.BorrowRecords
                .Include(b => b.Copy).ThenInclude(c => c.Book)
                .FirstOrDefaultAsync(b => b.Id == dto.BorrowId);

            if (record == null || record.Status != BorrowStatus.Pending)
                throw new InvalidOperationException("Borrow request not found or already processed.");

            record.BorrowDate = DateTime.Now;
            record.DueDate = record.BorrowDate.AddDays(14);
            record.Status = BorrowStatus.Borrowing;

            // Cập nhật trạng thái bản sao
            record.Copy.Status = "Borrowed";

            await _context.SaveChangesAsync();

            return _mapper.Map<BorrowRecordDto>(record);
        }

        // Cập nhật quá hạn và tiền phạt
        public async Task UpdateOverdueStatusesAsync()
        {
            var records = await _context.BorrowRecords
                .Where(r => r.Status == BorrowStatus.Borrowing &&
                            r.DueDate < DateTime.Now &&
                            r.ReturnDate == null)
                .ToListAsync();

            foreach (var r in records)
            {
                var overdueDays = (DateTime.Now.Date - r.DueDate.Date).Days;
                r.Status = BorrowStatus.Overdue;
                r.Fine = overdueDays * 10_000;
            }

            await _context.SaveChangesAsync();
        }

        // Lấy tất cả borrow của user (và tự động cập nhật trạng thái quá hạn nếu cần)
        public async Task<IEnumerable<BorrowRecordDto>> GetByUserIdAsync(string userId)
        {
            await UpdateOverdueStatusesAsync();

            var records = await _context.BorrowRecords
                .Where(r => r.UserId == userId)
                .Include(r => r.Copy).ThenInclude(c => c.Book)
                .OrderByDescending(r => r.BorrowDate)
                .ToListAsync();

            return _mapper.Map<IEnumerable<BorrowRecordDto>>(records);
        }
        public async Task CancelBorrowRequestAsync(string borrowId, string userId)
        {
            var record = await _context.BorrowRecords
                .Include(b => b.Copy)
                .FirstOrDefaultAsync(b => b.Id == borrowId && b.UserId == userId);

            if (record == null)
                throw new InvalidOperationException("Borrow request not found.");

            if (record.Status != BorrowStatus.Pending)
                throw new InvalidOperationException("Only pending borrow requests can be canceled.");

            // Nếu muốn xóa khỏi DB:
            // _context.BorrowRecords.Remove(record);

            // này là giữ lại lịch sử
            record.Status = BorrowStatus.Canceled;

            // Trả lại trạng thái bản sao nếu cần (nếu đã set là Reserved chẳng hạn)
            record.Copy.Status = "Available";

            await _context.SaveChangesAsync();
        }
        // librarian tao ve muon
        public async Task<BorrowRecordDto> CreateBorrowByLibrarianAsync(BorrowCreateDto dto)
        {
            var availableCopy = await _context.BookCopies
                .FirstOrDefaultAsync(b => b.BookId == dto.BookId && b.Status == "Available");

            if (availableCopy == null)
                throw new InvalidOperationException("No available book copy.");

            var borrow = new BorrowRecord
            {
                UserId = dto.UserId,
                CopyId = availableCopy.Id,
                BorrowDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(14),
                ReturnDate = null,
                ExtensionDateCount = 0,
                Fine = 0,
                Status = BorrowStatus.Borrowing
            };

            availableCopy.Status = "Borrowed";

            await _context.BorrowRecords.AddAsync(borrow);
            await _context.SaveChangesAsync();

            borrow = await _context.BorrowRecords
                .Include(b => b.Copy).ThenInclude(c => c.Book)
                .Include(b => b.User)
                .FirstAsync(b => b.Id == borrow.Id);

            return _mapper.Map<BorrowRecordDto>(borrow);
        }
    }
}
