using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Model
{
  public class Manager
  {
    [Key]
    public int Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Departament   { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }
  }
}
