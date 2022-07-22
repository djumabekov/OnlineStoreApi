using Dapper;
using OnlineStore.Model;
using OnlineStore.Repo.Interfaces;
//using OnlineStoreApi;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Repo.Impl {
  public class ManagerRepository : IManagerRepository
  {
    private const string connectionString = "Server=LAPTOP-66IDD8T0\\SQLEXPRESS;Database=OnlineStoreDb;Trusted_Connection=True;TrustServerCertificate=True";


    //private readonly OnlineStoreContext _context;

    //public ManagerRepository(OnlineStoreContext context) {
    //  _context = context;
    //}
    public async Task DeleteManager(int id) {
      throw new NotImplementedException();
    }

    public async Task<Manager> GetManagerByManagerName(string userName) {
      var query = @"select top 1 * from Managers where UserName = @userName";
      using var db = new SqlConnection(connectionString);
      var result = await db.QueryFirstOrDefaultAsync<Manager>(query, new { userName });
      return result;
    }
    public async Task<Manager> GetManagerById(int id) {
      var query = @"select top 1 * from Managers where Id = @id";
      using var db = new SqlConnection(connectionString);
      var result = await db.QueryFirstOrDefaultAsync<Manager>(query, new { id });
      return result;

    }

    public async Task<List<Manager>> GetManagers(int? top = null) {
      //if (top != null) {
      //return _context.Set<Manager>().Take((int)top).ToList();
      //}
      //return _context.Set<Manager>().ToList();
      throw new NotImplementedException();

    }

    public async Task<int> InsertManager(Manager user) {
      var query = @"
                INSERT INTO [dbo].[Managers]
                           ([Firstname]
                           ,[Lastname]
                           ,[Departament]
                           ,[Password]
                           ,[UserName]
                           )
                     VALUES
                           (@FirstName
                           ,@LastName
                           ,@Departament
                           ,@Password
                           ,@UserName)";
      var param = new DynamicParameters();
      param.Add("@FirstName", user.Firstname);
      param.Add("@LastName", user.Lastname);
      param.Add("@Departament", user.Departament);
      param.Add("@UserName", user.UserName);
      param.Add("@Password", user.Password);

      using var db = new SqlConnection(connectionString);
      var userId = await db.ExecuteAsync(query, param);
      return userId;
    }

    public async Task UpdateManager(Manager manager) {
      throw new NotImplementedException();
    }
  }
}
