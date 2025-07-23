using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;

namespace DataLayer.Repositories.Abstraction
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<bool> ExistsByNameAsync(string name);
    }
}
