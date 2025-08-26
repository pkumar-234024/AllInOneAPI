using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllInOne.Core.Interfaces;

namespace AllInOne.UseCases.ProductImageUseCaes.Create;
public class CreateProductImageCommandHandler : ICommandHandler<CreateProductImageCommand, Result<bool>>
{
  private readonly IProductImageService _productImageService;
  public CreateProductImageCommandHandler(IProductImageService productImageService)
  {
    _productImageService = productImageService;
  }
  public async Task<Result<bool>> Handle(CreateProductImageCommand request, CancellationToken cancellationToken)
  {
    var result = await _productImageService.CreateProductImages(request.cretateImageProductDto);
    if(!result)
    {
      return Result.Error("unable to add Product Images");
    }
    return Result.Success(result);
  }
}
