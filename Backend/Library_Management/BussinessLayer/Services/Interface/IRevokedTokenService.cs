using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Services.Interface
{
    public interface IRevokedTokenService
    {
        Task AddRevokedTokenAsync(string token, DateTime expiryDate);
        Task<bool> IsTokenRevokedAsync(string token);
    }
}
