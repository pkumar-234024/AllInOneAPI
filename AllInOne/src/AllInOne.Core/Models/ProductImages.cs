using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInOne.Core.Models;
public class ProductImages : BaseClass
{
  public int ProductId { get; set; }
  public string ImageName { get; set; } = string.Empty;
}
