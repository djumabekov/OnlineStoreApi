using Microsoft.EntityFrameworkCore;
using OnlineStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreApi {
  public class OnlineStoreContext : DbContext
  {
    DbSet<Product> Products { get; set; }
    DbSet<Manager> Managers { get; set; }
    public OnlineStoreContext(DbContextOptions<OnlineStoreContext> options) : base(options) { }
  }
}
