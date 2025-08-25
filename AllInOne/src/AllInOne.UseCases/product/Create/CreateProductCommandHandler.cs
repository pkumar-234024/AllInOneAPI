using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllInOne.Core.Interfaces;
using AllInOne.Core.Models;
using AllInOne.Core.Shared.OutputDTO;
using AutoMapper;

namespace AllInOne.UseCases.product.Create;
public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, Result<ProductOutDto>>
{
  private readonly IProductService _productService;
  private readonly IMapper _mapper;
  public CreateProductCommandHandler(IProductService productService, IMapper mapper)
  {
    _productService = productService;
    _mapper = mapper;
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
