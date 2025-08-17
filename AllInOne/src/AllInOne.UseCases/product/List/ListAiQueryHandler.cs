using AllInOne.Core.Interfaces;
using AllInOne.Core.Shared.OutputDTO;

namespace AllInOne.UseCases.product.List;
public class ListAiQueryHandler : IQueryHandler<ListProductQuery, Result<List<ProductOutDto>>>
{
  private readonly IProductService _productService;
  public ListAiQueryHandler(IProductService productService)
  {
    // Constructor logic if needed
    _productService = productService;
  }
  public async Task<Result<List<ProductOutDto>>> Handle(ListProductQuery request, CancellationToken cancellationToken)
  {
    try
    {
      var result = await _productService.GetAllProductsAsync();
      return result != null && result.Any()
        ? Result.Success(result)
        : Result.NotFound("No Products Found !!!");
    }
    catch (Exception ex)
    {
      // Log the exception if necessary
      return Result.Error($"An error occurred: {ex.Message} : {ex.StackTrace}");
    }
  }
}
