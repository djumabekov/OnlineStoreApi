using OnlineStore.Model;
using OnlineStore.Repo.Interfaces;
using OnlineStoreApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Repo.Impl {
  public class ProductRepository : IProductRepository {

    private readonly OnlineStoreContext _context;

    public ProductRepository(OnlineStoreContext context) {
      _context = context;
    }
    public async Task DeleteProduct(int id) {
      throw new NotImplementedException();
    }

    public async Task<Product> GetProductById(int id) {
      var product = _context.Set<Product>().FirstOrDefault(x => x.Id == id);
      return product;
    }

    public async Task<List<Product>> GetProducts(int? top = null) {
      if (top != null) {
        return _context.Set<Product>().Take((int)top).ToList();
      }
      return _context.Set<Product>().ToList();
    }

    public async Task<int> InsertProduct(Product product) {
      throw new NotImplementedException();
    }

    public async Task UpdateProduct(Product product) {
      throw new NotImplementedException();
    }
  }
}
