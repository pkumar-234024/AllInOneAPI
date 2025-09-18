using AllInOne.Core.Shared.OutputDTO;

namespace AllInOne.UseCases.product.ListbyIndex;
public record ListByIndexQuery(int index): IQuery<Result<List<ProductOutDto>>>;
