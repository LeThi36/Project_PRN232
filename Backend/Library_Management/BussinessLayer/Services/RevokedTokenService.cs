using BussinessLayer.Services.Interface;
using DataLayer.Entities;
using DataLayer.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Services
{
    public class RevokedTokenService : IRevokedTokenService
    {
        private readonly IGenericRepository<RevokedToken> _revokedTokenRepository;

        public RevokedTokenService(IGenericRepository<RevokedToken> revokedTokenRepository)
        {
            _revokedTokenRepository = revokedTokenRepository;
        }

        public async Task AddRevokedTokenAsync(string token, DateTime expiryDate)
        {
            var revokedToken = new RevokedToken
            {
                Token = token,
                ExpiryDate = expiryDate
            };
            await _revokedTokenRepository.CreateAsync(revokedToken);
        }

        public async Task<bool> IsTokenRevokedAsync(string token)
        {
            // Kiểm tra xem token có trong danh sách thu hồi và chưa hết hạn không
            var revoked = await _revokedTokenRepository.GetAsync(
                rt => rt.Token == token && rt.ExpiryDate > DateTime.Now
            );
            return revoked != null;
        }
    }
}
