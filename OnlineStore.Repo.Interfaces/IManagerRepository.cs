using OnlineStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Repo.Interfaces {
  public interface IManagerRepository {
    Task<Manager> GetManagerById(int id);
    Task<List<Manager>> GetManagers(int? top = null);
    Task<int> InsertManager(Manager manager);
    Task UpdateManager(Manager manager);
    Task DeleteManager(int id);
  }
}
