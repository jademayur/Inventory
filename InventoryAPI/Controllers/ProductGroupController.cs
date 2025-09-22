using InventoryAPI.DTOs;
using InventoryAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductGroupController : ControllerBase
    {
        private readonly IProductGroupService _productGroupService;
        public ProductGroupController(IProductGroupService productGroupService)
        {
            _productGroupService = productGroupService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProductGroups()
        {
            var productGroups = await _productGroupService.GetAllProductGroupsAsync();
            return Ok(productGroups);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductGroupById(int id)
        {
            var productGroup = await _productGroupService.GetProductGroupByIdAsync(id);
            if (productGroup == null)
            {
                return NotFound();
            }
            return Ok(productGroup);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductGroup([FromBody] ProductGroupDTO productGroup)
        {
            try
            {
                await _productGroupService.CreateProductGroupAsync(productGroup);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductGroup(int id, [FromBody] ProductGroupDTO productGroup)
        {
            if (id != productGroup.Id)
            {
                return BadRequest("ID mismatch");
            }
            try
            {
                await _productGroupService.UpdateProductGroupAsync(productGroup);
                
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductGroup(int id)
        {
            var deleted = await _productGroupService.DeleteProductGroupAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
