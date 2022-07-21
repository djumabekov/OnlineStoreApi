using OnlineStore.Model;
using OnlineStore.Repo.Interfaces;
using OnlineStoreApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Repo.Impl {
  public class ManagerRepository : IManagerRepository
  {

    private readonly OnlineStoreContext _context;

    public ManagerRepository(OnlineStoreContext context) {
      _context = context;
    }
    public async Task DeleteManager(int id) {
      throw new NotImplementedException();
    }

    public async Task<Manager> GetManagerById(int id) {
      var manager = _context.Set<Manager>().FirstOrDefault(x => x.Id == id);
      return manager;
    }

    public async Task<List<Manager>> GetManagers(int? top = null) {
      if (top != null) {
        return _context.Set<Manager>().Take((int)top).ToList();
      }
      return _context.Set<Manager>().ToList();
    }

    public async Task<int> InsertManager(Manager manager) {
      throw new NotImplementedException();
    }

    public async Task UpdateManager(Manager manager) {
      throw new NotImplementedException();
    }
  }
}
