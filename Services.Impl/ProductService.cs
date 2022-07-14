using OnlineStore.Model;
using Services.Interfaces;

namespace Services.Impl {
  public class ProductService : IProductInterface {
    public async Task<Product> GetProduct() {
      return new Product() 
      {
        Id = 1,
        Name = "Product 1",
        Price = 100,
        Description = "New Laptop1"
      };
    }

    public async Task<List<Product>> GetProducts() {
      return new List<Product>() 
      {
        new Product() 
        {
          Id = 1,
          Name = "Product 1",
          Price = 100,
          Description = "New Laptop1"
        },
        new Product() 
        {
          Id = 2,
          Name = "Product 2",
          Price = 200,
          Description = "New Laptop2"
        },
      };

    }
  }
}
