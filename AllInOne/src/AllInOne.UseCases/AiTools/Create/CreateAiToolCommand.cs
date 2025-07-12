
using AllInOne.Core.Shared.InputDTO;
using AllInOne.Core.Shared.OutputDTO;

namespace AllInOne.UseCases.AiTools.Create;
public record CreateAiToolCommand(AiToolCreateDto aiToolCreateDto) : ICommand<Result<AiToolDtoOutWithId>>;

