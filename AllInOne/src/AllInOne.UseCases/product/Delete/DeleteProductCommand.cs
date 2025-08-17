
namespace AllInOne.UseCases.product.Delete;
public record DeleteProductCommand(int id) : ICommand<Result<bool>>;
