using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllInOne.Core.Shared.OutputDTO;

namespace AllInOne.UseCases.ProductImageUseCaes.List;
public record ListProductImageQuery(int productId) : IQuery<Result<List<ProductImageDto>>>;
