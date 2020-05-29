using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.Api.Models;

namespace Demo.Api.Repositories
{
    public interface IProductRepository
    {
        Task<int?> CreateAsync(string name, decimal price);
        Task<Product> GetAsync(int productId);
        Task<IEnumerable<Product>> ListAsync();
    }
}