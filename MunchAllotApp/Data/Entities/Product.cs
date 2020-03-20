using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunchAllotApp.Data.Entities
{
  public class Product
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public string Size { get; set; }
    public decimal Price { get; set; }

  }
}
