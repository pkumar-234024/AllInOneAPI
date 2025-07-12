using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInOne.Core.Models;
public class BaseClass : EntityBase, IAggregateRoot
{
  public DateTime CreatedDate {  get; set; }
  public DateTime UpdatedDate { get; set; }
  public string CreatedBy { get; set; } = string.Empty;
  public string UpdatedBy { get; set;} = string.Empty;
}
