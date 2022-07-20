using OnlineStore.Model;
using OnlineStore.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Repo.Impl {
  public class ProductRepository : IProductRepository {
    public async Task DeleteProduct(int id) {
      throw new NotImplementedException();
    }

    public async Task<Product> GetProductById(int id) {
      throw new NotImplementedException();
    }

    public async Task<List<Product>> GetProducts(int? top = null) {
      throw new NotImplementedException();
    }

    public async Task<int> InsertProduct(Product product) {
      throw new NotImplementedException();
    }

    public async Task UpdateProduct(Product product) {
      throw new NotImplementedException();
    }
  }
}
