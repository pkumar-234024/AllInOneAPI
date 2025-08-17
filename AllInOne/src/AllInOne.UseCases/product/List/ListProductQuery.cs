using AllInOne.Core.Shared.OutputDTO;

namespace AllInOne.UseCases.product.List;
public record ListProductQuery :IQuery<Result<List<ProductOutDto>>>; // Assuming ProductDtoOutWithId is defined elsewhere in your project
