using AllInOne.Core.Shared.InputDTO;
using AllInOne.Core.Shared.OutputDTO;

namespace AllInOne.UseCases.product.Update;
public record UpdateProductCommand(UpdateProductDto product) : ICommand<Result<ProductOutDto>>;
