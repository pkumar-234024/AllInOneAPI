using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllInOne.Core.Interfaces;

namespace AllInOne.UseCases.product.Delete;
public class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand, Result<bool>>
{
  private readonly IProductService _productService;
  public DeleteProductCommandHandler(IProductService productService)
  {
    _productService = productService;
  }
  public async Task<Result<bool>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
  {
    var result = await _productService.DeleteProductAsync(request.id);
    if(result)
    {
      return Result.Error("Failed to delete the product ");
    }
    return Result.Success(true);
  }
}
