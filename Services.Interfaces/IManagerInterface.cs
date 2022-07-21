
using OnlineStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces {
  public interface IManagerInterface {
    Task<Manager> GetManager();
    Task<List<Manager>> GetManagers();
  }
}
