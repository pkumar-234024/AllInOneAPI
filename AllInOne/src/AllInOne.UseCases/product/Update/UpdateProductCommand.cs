using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllInOne.Core.Models;
using AllInOne.Core.Shared.OutputDTO;

namespace AllInOne.UseCases.product.Update;
public record UpdateProductCommand(Products product) : ICommand<Result<ProductOutDto>>;
