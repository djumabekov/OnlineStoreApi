using OnlineStore.Model;
using OnlineStore.Repo.Interfaces;
using Services.Interfaces;

namespace Services.Impl {
  public class ManagerService : IManagerInterface {
    //private readonly IManagerRepository _managerRepository;

    //public ManagerService(IManagerRepository managerRepository) { 
    //  _managerRepository = managerRepository;
    //}
    public async Task<Manager> GetManager() {
      return new Manager() 
      {
        Id = 1,
        Firstname = "Ivan",
        Lastname = "Ivanov",
        Departament = "Computers"
      };
    }

    public async Task<List<Manager>> GetManagers() {
      throw new NotImplementedException();
      //return await _managerRepository.GetManagers();

    }
  }
}
