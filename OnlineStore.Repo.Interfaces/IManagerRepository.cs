using OnlineStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Repo.Interfaces {
  public interface IManagerRepository {
    public Task<Manager> GetManagerById(int id);
    public Task<List<Manager>> GetManagers(int? top = null);
    public Task<Manager> GetManagerByManagerName(string userName);
    public Task<int> InsertManager(Manager manager);
    public Task UpdateManager(Manager manager);
    public Task DeleteManager(int id);
  }
}
