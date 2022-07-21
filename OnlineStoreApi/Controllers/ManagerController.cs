using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Model;
using Services.Interfaces;

namespace OnlineStoreApi.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class ManagerController : ControllerBase 
   {
    private readonly IManagerInterface _managerService;
    private readonly OnlineStoreContext _onlineStoreContext;
    public ManagerController(IManagerInterface managerService, OnlineStoreContext onlineStoreContext) {
      _managerService = managerService;
      _onlineStoreContext = onlineStoreContext;
    }
    [HttpGet("managers")]
    public async Task<IActionResult> GetManagers() {
      //var result = await _managerService.GetManagers();
      //return Ok(result);
      var result = _onlineStoreContext.Set<Manager>().ToList();
      return Ok(result);
    }
    [HttpPut("createManager")]
    public async Task<IActionResult> CreateManager([FromBody] Manager manager)
    {
      throw new NotImplementedException();
    }

    [HttpPost("updateManager")]
    public async Task<IActionResult> UpdateManager([FromBody] Manager manager) {
      throw new NotImplementedException();
    }
  }
}
