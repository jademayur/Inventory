using InventoryAPI.DTOs;
using InventoryAPI.Models;
using InventoryAPI.Repositories;

namespace InventoryAPI.Services
{
    public class ProductGroupService : IProductGroupService
    {
        private readonly IProductGroupRepository _productGroupRepository;
        public ProductGroupService(IProductGroupRepository productGroupRepository)
        {
            _productGroupRepository = productGroupRepository;
        }
        public async Task<int> CreateProductGroupAsync(ProductGroupDTO productGroup)
        {           
            return await _productGroupRepository.CreateProductGroupAsync(productGroup);
        }

        public Task<bool> DeleteProductGroupAsync(int id)
        {
           return _productGroupRepository.DeleteProductGroupAsync(id);
        }

        public Task<IEnumerable<ProductGroup>> GetAllProductGroupsAsync()
        {
           return _productGroupRepository.GetAllProductGroupsAsync();
        }

        public Task<ProductGroup?> GetProductGroupByIdAsync(int id)
        {
            return _productGroupRepository.GetProductGroupByIdAsync(id);
        }

        public async Task<int> UpdateProductGroupAsync(ProductGroupDTO productGroup)
        {
              
            return await _productGroupRepository.UpdateProductGroupAsync(productGroup);
        }
    }
}
