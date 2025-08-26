using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AllInOne.Core.Shared.OutputDTO;
public class ProductImageDto
{
  public string ImageFilePath { get; set; } = string.Empty;
  public string ImageName { get; set; } = string.Empty;
  public int ProductId { get; set; }
}
