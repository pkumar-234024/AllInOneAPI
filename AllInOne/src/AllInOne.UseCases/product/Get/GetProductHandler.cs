using AllInOne.Core.Interfaces;
using AllInOne.Core.Shared.OutputDTO;

namespace AllInOne.UseCases.product.Get;
public class GetProductHandler : IQueryHandler<GetProductQuery, Result<ProductOutDto>>
{
  private readonly IProductService _productService;
  public GetProductHandler(IProductService productService)
  {
    _productService = productService;
  }
  public async Task<Result<ProductOutDto>> Handle(GetProductQuery request, CancellationToken cancellationToken)
  {
    var result = await _productService.GetProductByIdAsync(request.id);
    if (result == null)
    {
      return Result.NotFound("No Ai Tool for this Id !!!");
    }
    return Result.Success(result);
  }
}
