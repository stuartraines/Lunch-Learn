using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Demo.Api.Configuration;
using Demo.Api.Models;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using static Dapper.SimpleCRUD;

namespace Demo.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IOptions<AppSettings> _appSettings;

        public ProductRepository(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings;
        }

        public async Task<int?> CreateAsync(string name, decimal price)
        {
            using (var connection = new MySqlConnection(_appSettings.Value.DBConnectionString))
            {
                SimpleCRUD.SetDialect(Dialect.MySQL);

                return await connection.InsertAsync(new Product { Name = name, Price = price });
            }
        }

        public async Task<Product> GetAsync(int productId)
        {
            using (var connection = new MySqlConnection(_appSettings.Value.DBConnectionString))
            {
                SimpleCRUD.SetDialect(Dialect.MySQL);

                return await connection.GetAsync<Product>(productId);
            }
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            using (var connection = new MySqlConnection(_appSettings.Value.DBConnectionString))
            {
                SimpleCRUD.SetDialect(Dialect.MySQL);

                return await connection.GetListAsync<Product>();
            }
        }
    }
}