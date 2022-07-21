using OnlineStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Repo.Interfaces {
  public interface IUserRepository {
    public Task<ApplicationUser> GetUserByUserName(string userName);
    public Task<ApplicationUser> GetUserByAppUserId(int id);
    public Task<int> InsertUser(ApplicationUser user);

  }
}
