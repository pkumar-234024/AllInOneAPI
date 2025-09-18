using AllInOne.Core.Interfaces;
using AllInOne.Core.Shared.OutputDTO;

namespace AllInOne.UseCases.product.ListbyIndex;
public class ListByIndexQueryHandler : IQueryHandler<ListByIndexQuery, Result<List<ProductOutDto>>>
{
  private readonly IProductService _productService;
  public ListByIndexQueryHandler(IProductService productService)
  {
    _productService = productService;
  }
  public async Task<Result<List<ProductOutDto>>> Handle(ListByIndexQuery request, CancellationToken cancellationToken)
  {
    var result = await _productService.GetAllProductsByIndexAsync(request.index);
    if (result.Count == 0) { 
      return Result.Error("No products found");
    }
    return Result.Success(result);
  }
}
