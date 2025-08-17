using System;
using AllInOne.Core.Models;
using AllInOne.Core.Shared.OutputDTO;

namespace AllInOne.UseCases.product.Create;
public record
  CreateProductCommand(Products productDto) : ICommand<Result<ProductOutDto>>;
