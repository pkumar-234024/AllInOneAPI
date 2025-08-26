
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllInOne.Core.Models;

namespace AllInOne.Core.Specification;
public class GetProductImageByProductIdSpec : Specification<ProductImages>
{
  public GetProductImageByProductIdSpec(int productId)
  {
    Query.Where(pi=> pi.Id == productId).OrderByDescending(productId => productId);
  }
}
