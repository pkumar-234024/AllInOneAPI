using System;
using AllInOne.Core.Models;
using AllInOne.Core.Shared.InputDTO;
using AllInOne.Core.Shared.OutputDTO;

namespace AllInOne.UseCases.product.Create;
public record
  CreateProductCommand(CreatProductDto productDto) : ICommand<Result<ProductOutDto>>;
