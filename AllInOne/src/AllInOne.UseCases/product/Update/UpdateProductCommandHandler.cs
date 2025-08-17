using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllInOne.Core.Interfaces;
using AllInOne.Core.Shared.OutputDTO;

namespace AllInOne.UseCases.product.Update;
public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, Result<ProductOutDto>>
{
  private readonly IProductService _productService;
  public UpdateProductCommandHandler(IProductService productService)
  {
    _productService = productService;
  }
  public async Task<Result<ProductOutDto>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
  {
    var result = await _productService.UpdateProductAsync(request.product);
    if (result == null)
    {
      return Result.Error("Failed to upload product");
    }
    return Result.Success(result);
  }
}
