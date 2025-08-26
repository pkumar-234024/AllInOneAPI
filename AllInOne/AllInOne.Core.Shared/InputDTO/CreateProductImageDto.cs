using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AllInOne.Core.Shared.InputDTO;
public class CreateProductImageDto
{
  public IFormFile[] ImageFiles { get; set; } = [];
  public int ProductId {  get; set; }
}
