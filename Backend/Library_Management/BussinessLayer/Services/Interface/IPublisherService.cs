using BussinessLayer.DTOs.Publisher;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Services.Interface
{
    public interface IPublisherService
    {
        Task<Publisher> AddPublisher(PublisherCreateDto publisherDto);
        Task<IEnumerable<Publisher>> GetAllPublisher();
        Task<Publisher> GetPublisherById(string id);
        Task UpdatePublisher(string id, PublisherUpdateDto publisherDto);
        Task RemovePublisher(string id);

        Task<(IEnumerable<Publisher> Data, int TotalCount, int PageIndex, int PageSize)>
    GetPagedPublishersAsync(string? search, int pageIndex, int pageSize);

    }
}
