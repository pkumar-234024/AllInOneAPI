using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllInOne.Core.Shared.InputDTO;

namespace AllInOne.UseCases.ProductImageUseCaes.Create;
public record CreateProductImageCommand(CreateProductImageDto cretateImageProductDto) : ICommand<Result<bool>>;
