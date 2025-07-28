using BussinessLayer.DTOs.Publisher;
using BussinessLayer.Services.Interface;
using DataLayer.Entities;
using DataLayer.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Services
{
        public class PublisherService : IPublisherService
    {
            private readonly IGenericRepository<Publisher> _publisherRepository;
        private readonly ProjectPrn232Context _context;

        public PublisherService(IGenericRepository<Publisher> publisherRepository, ProjectPrn232Context context)
            {
                _publisherRepository = publisherRepository;
            _context = context;
        }

            public async Task<Publisher> AddPublisher(PublisherCreateDto publisherDto)
            {
                if (publisherDto == null)
                {
                    throw new ArgumentNullException(nameof(publisherDto), "Publisher data cannot be null.");
                }

                var publisher = new Publisher
                {
                    PublisherName = publisherDto.PublisherName,
                    Address = publisherDto.Address,
                    PhoneNumber = publisherDto.PhoneNumber
                    // Id, CreatedAt handled by BaseEntity
                };

                await _publisherRepository.CreateAsync(publisher);
                return publisher;
            }

            public async Task<IEnumerable<Publisher>> GetAllPublisher()
            {
                return await _publisherRepository.GetAllAsync();
            }

            public async Task<Publisher> GetPublisherById(string id)
            {
                if (string.IsNullOrEmpty(id))
                {
                    throw new ArgumentNullException(nameof(id), "Publisher ID cannot be null or empty.");
                }

                var publisher = await _publisherRepository.GetAsync(p => p.Id == id);
                if (publisher == null)
                {
                    throw new KeyNotFoundException($"Publisher with ID {id} not found.");
                }

                return publisher;
            }

            public async Task UpdatePublisher(string id, PublisherUpdateDto publisherDto)
            {
                if (string.IsNullOrEmpty(id))
                {
                    throw new ArgumentNullException(nameof(id), "Publisher ID cannot be null or empty.");
                }

                if (publisherDto == null)
                {
                    throw new ArgumentNullException(nameof(publisherDto), "Publisher data cannot be null.");
                }

                var publisherToUpdate = await _publisherRepository.GetAsync(p => p.Id == id);
                if (publisherToUpdate == null)
                {
                    throw new KeyNotFoundException($"Publisher with ID {id} not found.");
                }

                publisherToUpdate.PublisherName = publisherDto.PublisherName;
                publisherToUpdate.Address = publisherDto.Address;
                publisherToUpdate.PhoneNumber = publisherDto.PhoneNumber;
                publisherToUpdate.UpdatedAt = DateTime.Now;

                await _publisherRepository.UpdateAsync(publisherToUpdate);
            }

            public async Task RemovePublisher(string id)
            {
                if (string.IsNullOrEmpty(id))
                {
                    throw new ArgumentNullException(nameof(id), "Publisher ID cannot be null or empty.");
                }

                var publisherToRemove = await _publisherRepository.GetAsync(p => p.Id == id);
                if (publisherToRemove == null)
                {
                    throw new KeyNotFoundException($"Publisher with ID {id} not found.");
                }

                await _publisherRepository.RemoveAsync(publisherToRemove);
            }

        public async Task<(IEnumerable<Publisher> Data, int TotalCount, int PageIndex, int PageSize)>
    GetPagedPublishersAsync(string? search, int pageIndex, int pageSize)
        {
            var query = _context.Publishers.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToLower();
                query = query.Where(p =>
                    p.PublisherName.ToLower().Contains(search) ||
                    p.Id.ToLower().Contains(search));
            }

            var totalCount = await query.CountAsync();

            var data = await query
                .OrderByDescending(p => p.CreatedAt)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (data, totalCount, pageIndex, pageSize);
        }

    }
}

