using InventoryAPI.DTOs;
using InventoryAPI.Models;

namespace InventoryAPI.Repositories
{
    public interface IProductGroupRepository
    {
        Task<IEnumerable<ProductGroup>> GetAllProductGroupsAsync();
        Task<ProductGroup?> GetProductGroupByIdAsync(int id);
        Task<int> CreateProductGroupAsync(ProductGroupDTO productGroup);
        Task<int> UpdateProductGroupAsync(ProductGroupDTO productGroup);
        Task<bool> DeleteProductGroupAsync(int id);
       

    }
}
