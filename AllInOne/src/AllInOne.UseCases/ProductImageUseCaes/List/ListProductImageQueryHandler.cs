using AllInOne.Core.Interfaces;
using AllInOne.Core.Shared.OutputDTO;
using MediatR;

namespace AllInOne.UseCases.ProductImageUseCaes.List;
public class ListProductImageQueryHandler : IQueryHandler<ListProductImageQuery, Result<List<ProductImageDto>>>
{
  private readonly IProductImageService _productImageService;
  public ListProductImageQueryHandler(IProductImageService productImageService)
  {
    _productImageService = productImageService;
  }
  public async Task<Result<List<ProductImageDto>>> Handle(ListProductImageQuery request, CancellationToken cancellationToken)
  {
    var result = await _productImageService.ListImageByProductId(request.productId);
    if(result == null)
    {
      return Result.Error("Not ");
    }
    return Result.Success(result);
  }
}
