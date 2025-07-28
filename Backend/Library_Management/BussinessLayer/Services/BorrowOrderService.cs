using AutoMapper;
using BussinessLayer.DTOs.BorrowRecord;
using BussinessLayer.Services.Interface;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BussinessLayer.Services
{
    public class BorrowOrderService : IBorrowOrderService
    {
        private readonly ProjectPrn232Context _context;
        private readonly IMapper _mapper;

        public BorrowOrderService(ProjectPrn232Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BorrowOrderDto> CheckoutCartAsync(string studentCode)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.StudentCode == studentCode);

            if (user == null)
                throw new Exception("Student not found.");

            var cart = await _context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Book)
                .FirstOrDefaultAsync(c => c.UserId == user.Id);

            if (cart == null || !cart.CartItems.Any())
                throw new Exception("Cart is empty");

            var order = new BorrowOrder
            {
                UserId = user.Id,
                BorrowDate = DateTime.Now,
                DueDate = DateTime.Now,
                Status = "Pending"
            };

            foreach (var item in cart.CartItems)
            {
                var availableCopies = await _context.BookCopies
                    .Where(bc => bc.BookId == item.BookId && bc.Status == "Available")
                    .Take(item.Quantity)
                    .ToListAsync();

                if (availableCopies.Count < item.Quantity)
                    throw new Exception($"Not enough available copies for book: {item.Book.Title}");

                foreach (var copy in availableCopies)
                {
                    copy.Status = "Reserved";

                    order.BorrowRecords.Add(new BorrowRecord
                    {
                        UserId = user.Id,
                        CopyId = copy.Id,
                        BorrowDate = DateTime.Now,
                        DueDate = DateTime.Now,
                        Status = "Pending",
                        Fine = 0
                    });
                }
            }

            _context.BorrowOrders.Add(order);
            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync();

            return _mapper.Map<BorrowOrderDto>(order);
        }

        public async Task ApproveBorrowOrderAsync(string orderId)
        {
            var order = await _context.BorrowOrders
                .Include(o => o.BorrowRecords)
                .ThenInclude(r => r.Copy)
                .FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null || order.Status != "Pending")
                throw new Exception("Invalid or already approved order.");

            var now = DateTime.Now;
            var due = now.AddDays(15);

            order.Status = "Approved";
            order.BorrowDate = now;
            order.DueDate = due;

            foreach (var record in order.BorrowRecords)
            {
                record.BorrowDate = now;
                record.DueDate = due;
                record.Status = "Borrowed";

                record.Copy.Status = "Borrowed";
            }

            await _context.SaveChangesAsync();
        }

        public async Task ReturnBookAsync(string recordId)
        {
            var record = await _context.BorrowRecords
                .Include(r => r.BorrowOrder)
                .Include(r => r.Copy)
                .FirstOrDefaultAsync(r => r.Id == recordId);

            if (record == null)
                throw new Exception("Record not found.");

            if (record.Status != "Borrowed")
                throw new Exception("This book is not currently borrowed.");

            var returnDate = DateTime.Now;
            record.ReturnDate = returnDate;
            record.Status = "Returned";

            record.Copy.Status = "Available";

            if (returnDate > record.DueDate)
            {
                var daysLate = (returnDate - record.DueDate).Days;
                record.Fine = daysLate * 10000;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<List<BorrowOrderDto>> GetOrdersByStudentAsync(string studentCode)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.StudentCode == studentCode);

            if (user == null)
                throw new Exception("Student not found.");

            var orders = await _context.BorrowOrders
                .Where(o => o.UserId == user.Id)
                .Include(o => o.BorrowRecords)
                    .ThenInclude(r => r.Copy) // Include Copy
                        .ThenInclude(c => c.Book) // Include Book from Copy
                .ToListAsync();

            return _mapper.Map<List<BorrowOrderDto>>(orders);
        }

        public async Task<bool> CancelBorrowOrderAsync(string orderId)
        {
            var order = await _context.BorrowOrders
                .Include(o => o.BorrowRecords)
                .ThenInclude(r => r.Copy)
                .FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null || order.Status != "Pending") return false;

            order.Status = "Cancelled";

            foreach (var record in order.BorrowRecords)
            {
                record.Copy.Status = "Available";
                record.Status = "Cancelled"; // Optional
            }

            await _context.SaveChangesAsync();
            return true;
        }



    }
}