using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Model;
using Services.Interfaces;

namespace OnlineStoreApi.Controllers {
  [Authorize(AuthenticationSchemes = "Bearer", Roles = "clientsUser")]
  [Route("api/[controller]")]
  [ApiController]
  public class ProductController : ControllerBase 
   {
    private readonly IProductInterface _productService;
    private readonly OnlineStoreContext _onlineStoreContext;
    public ProductController(IProductInterface productService, OnlineStoreContext onlineStoreContext) {
      _productService = productService;
      _onlineStoreContext = onlineStoreContext;
    }
    [HttpGet("products")]
    public async Task<IActionResult> GetProducts() {
      //var result = await _productService.GetProducts();
      //return Ok(result);
      var result = _onlineStoreContext.Set<Product>().ToList();
      return Ok(result);
    }
    [HttpPut("createProduct")]
    public async Task<IActionResult> CreateProduct([FromBody] Product product){
      _onlineStoreContext.Add(product);
      _onlineStoreContext.SaveChanges();
      return Ok(product);
    }

    [HttpPost("updateProduct")]
    public async Task<IActionResult> UpdateProduct([FromBody] Product product) {
      var result = _onlineStoreContext.Set<Product>().Where(x=>x.Id == product.Id).FirstOrDefault();

      if (result != null)
      {
        result.Name = product.Name;
        result.Price = product.Price;
        result.Description = product.Description;
        _onlineStoreContext.SaveChanges();
        return Ok(result);
      }
      return NoContent();
    }

    [HttpPost("deleteProduct")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
      var result = _onlineStoreContext.Set<Product>().Where(x => x.Id == id).FirstOrDefault();

      if (result != null)
      {
        _onlineStoreContext.Remove(result);
        _onlineStoreContext.SaveChanges();
        return Ok(result);
      }
      return NoContent();
    }
  }
}
