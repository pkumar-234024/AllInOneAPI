using AllInOne.Core.Shared.OutputDTO;

namespace AllInOne.UseCases.AiTools.List;
public record ListAiToolQuery : IQuery<Result<IEnumerable<AiToolDtoOutWithId>>>;
