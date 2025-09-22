using InventoryAPI.Data;
using InventoryAPI.DTOs;
using InventoryAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace InventoryAPI.Repositories
{
    public class ProductGroupRepository : IProductGroupRepository
    {
        private readonly AppDbContext _context;

        public ProductGroupRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public async Task<int> CreateProductGroupAsync(ProductGroupDTO productGroup)
         {
            var parameters = new[]
            {
                new SqlParameter("@GroupName", productGroup.GroupName),
                new SqlParameter("@Result", System.Data.SqlDbType.Int)
                {
                    Direction = System.Data.ParameterDirection.Output
                }
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC CreateProductGroup @GroupName,@Result OUTPUT", parameters);

            return (int)parameters[1].Value;

        }

        public Task<bool> DeleteProductGroupAsync(int id)
        {
           var parameters = new SqlParameter("@Id", id);
            var rows =  _context.Database.ExecuteSqlRawAsync("EXEC DeleteProductGroup @Id", parameters);
             
            return rows.ContinueWith(t => t.Result > 0);    
        }

        public Task<IEnumerable<ProductGroup>> GetAllProductGroupsAsync()
        {
            return _context.ProductGroups.FromSqlRaw("EXEC GetAllProductGroups").ToListAsync().ContinueWith(t => t.Result.AsEnumerable());
        }

        public Task<ProductGroup?> GetProductGroupByIdAsync(int id)
        {
           var parameter = new SqlParameter("@Id", id);
           var productGroups =  _context.ProductGroups.FromSqlRaw("EXEC GetProductGroupById @Id", parameter).ToListAsync();
           return productGroups.ContinueWith(t => t.Result.FirstOrDefault());
        }

        public async Task<int> UpdateProductGroupAsync(ProductGroupDTO productGroup)
        {
           var parameters = new []
           {
                new SqlParameter("@Id", productGroup.Id),
                new SqlParameter("@GroupName", productGroup.GroupName),
                new SqlParameter("@Result", System.Data.SqlDbType.Int)
                {
                    Direction = System.Data.ParameterDirection.Output
                }
           };

           await _context.Database.ExecuteSqlRawAsync("EXEC UpdateProductGroup @Id, @GroupName, @Result", parameters);

           return (int)parameters[2].Value;

        }

      

    }
}
