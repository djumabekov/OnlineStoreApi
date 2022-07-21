using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OnlineStore.Model;
using OnlineStore.Repo.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OnlineStoreApi.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase {
    private readonly IUserRepository _userRepository;
    public UsersController(IUserRepository userRepository) {
      _userRepository = userRepository;
    }
    [HttpGet("UserByUserName")]
    public async Task<IActionResult> UserByUserName(string userName) {
      var result = await _userRepository.GetUserByUserName(userName);
      if (result == null) {
        return NoContent();
      }
      return Ok(result);
    }
    [HttpPost("createUser")]
    public async Task<IActionResult> CreateUser(ApplicationUser applicationUser) {
      var result = await _userRepository.InsertUser(applicationUser);
      return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel loginModel) {
      var user = await _userRepository.GetUserByUserName(loginModel.UserName);

      if (user.Password == loginModel.Password) {
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("HSFVBHASTGSHDVASDS"));
        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
    {
                new Claim("applicationUserId", user.Id.ToString()),
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
