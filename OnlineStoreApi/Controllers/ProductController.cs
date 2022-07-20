using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Model;
using Services.Interfaces;

namespace OnlineStoreApi.Controllers {
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
      throw new NotImplementedException();
    }

    [HttpPost("updateProduct")]
    public async Task<IActionResult> UpdateProduct([FromBody] Product product) {
      throw new NotImplementedException();
    }
  }
}
