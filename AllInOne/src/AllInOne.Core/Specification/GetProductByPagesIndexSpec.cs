using AllInOne.Core.Models;

namespace AllInOne.Core.Specification;
public class GetProductByPagesIndexSpec : Specification<Products>
{
  public GetProductByPagesIndexSpec(int index, int pageSize)
  {
    Query.Skip((index - 1) * pageSize).Take(pageSize).OrderByDescending(p => p.Id);
  }
}
