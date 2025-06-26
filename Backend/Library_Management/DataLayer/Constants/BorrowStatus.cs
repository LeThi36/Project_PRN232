using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Constants
{
    public static class BorrowStatus
    {
        public const string Pending = "Pending";         // chờ duyệt
        public const string Borrowing = "Borrowing";     // đã duyệt, đang mượn
        public const string Overdue = "Overdue";         // quá hạn
        public const string Returned = "Returned";       // đã trả
        public const string Canceled = "Canceled";
    }
}
