using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllInOne.Core.Shared.InputDTO;
using AllInOne.Core.Shared.OutputDTO;

namespace AllInOne.UseCases.product.Get;
public record GetProductQuery(int id) : IQuery<Result<ProductOutDto>>;
