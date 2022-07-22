using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OnlineStore.Model;
using OnlineStore.Repo.Interfaces;
using Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OnlineStoreApi.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class ManagerController : ControllerBase 
   {
    private readonly IManagerInterface _managerService;
    private readonly IManagerRepository _managerRepository;
    private readonly OnlineStoreContext _onlineStoreContext;
    public ManagerController(IManagerInterface managerService, OnlineStoreContext onlineStoreContext, IManagerRepository managerRepository) {
      _managerService = managerService;
      _onlineStoreContext = onlineStoreContext;
      _managerRepository = managerRepository;
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
      _onlineStoreContext.Add(manager);
      _onlineStoreContext.SaveChanges();
      return Ok(manager);
    }

    [HttpPost("updateManager")]
    public async Task<IActionResult> UpdateManager([FromBody] Manager manager) {
      var result = _onlineStoreContext.Set<Manager>().Where(x => x.Id == manager.Id).FirstOrDefault();

      if (result != null)
      {
        result.Firstname = manager.Firstname;
        result.Lastname = manager.Lastname;
        result.Departament = manager.Departament;
        result.UserName = manager.UserName;
        result.Password = manager.Password;
        _onlineStoreContext.SaveChanges();
        return Ok(result);
      }
      return NoContent();
    }

    [HttpPost("deleteManager")]
    public async Task<IActionResult> DeleteManager(int id)
    {
      var result = _onlineStoreContext.Set<Manager>().Where(x => x.Id == id).FirstOrDefault();

      if (result != null)
      {
        _onlineStoreContext.Remove(result);
        _onlineStoreContext.SaveChanges();
        return Ok(result);
      }
      return NoContent();
    }

    [HttpPost("managerLogin")]
    public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
    {
      var user = await _managerRepository.GetManagerByManagerName(loginModel.UserName);

      if (user.Password == loginModel.Password)
      {
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("HSFVBHASTGSHDVASDS"));
        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
    {
                new Claim("ManagerUserId", user.Id.ToString()),
                new Claim(ClaimTypes.Role, "clientsUser")
            };

        var tokeOptions = new JwtSecurityToken(
            "https://localhost:7125",
            "https://localhost:7125",
            claims,
            expires: DateTime.Now.AddDays(30),
            signingCredentials: signinCredentials
        );

        var token = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
        return Ok(token);
      }
      return BadRequest();
    }
  }
}
