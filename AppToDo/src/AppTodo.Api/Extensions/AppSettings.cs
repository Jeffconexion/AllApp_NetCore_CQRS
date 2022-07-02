using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppTodo.Api.Extensions
{
  public class AppSettings
  {
    public string Secret { get; set; }
    public int ExpirationHoures { get; set; }
    public string Issuer { get; set; }
    public string ValidIn { get; set; }

  }
}
