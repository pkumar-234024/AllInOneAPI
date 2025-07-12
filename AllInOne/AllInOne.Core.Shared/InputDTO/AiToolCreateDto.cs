using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInOne.Core.Shared.InputDTO;
public class AiToolCreateDto
{
  public string Name { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public byte[]? Image { get; set; }
  public string ImagePath { get; set; } = string.Empty;
  public string ToolUrl { get; set; } = string.Empty;
}
