using System;
using System.Collections.Generic;
using System.Linq;

namespace BussinessLayer.DTOs
{
    public class PaginationResult<T>
    {
        public IEnumerable<T> Items { get; set; } // Danh sách các mục trên trang hiện tại
        public int TotalCount { get; set; } // Tổng số mục (trên tất cả các trang)
        public int PageIndex { get; set; } // Chỉ số trang hiện tại (bắt đầu từ 1)
        public int PageSize { get; set; } // Kích thước trang

        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;

        public PaginationResult(IEnumerable<T> items, int totalCount, int pageIndex, int pageSize)
        {
            Items = items ?? new List<T>();
            TotalCount = totalCount;
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }
}