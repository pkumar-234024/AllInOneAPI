using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllInOne.Core.Interfaces;
using AllInOne.Core.Shared.OutputDTO;

namespace AllInOne.UseCases.product.Create;
public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, Result<ProductOutDto>>
{
  private readonly IProductService _productService;
  public CreateProductCommandHandler(IProductService productService)
  {
    _productService = productService;
  }
  public async Task<Result<ProductOutDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
  {
    var result = await _productService.CreateProductAsync(request.productDto);
    if (result == null)
    {
      return Result.Error("Unable to creaate Prduct");
    }
    return Result.Success(result);
  }
}
