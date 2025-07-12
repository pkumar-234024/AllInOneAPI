using AllInOne.Core.Shared.InputDTO;
using AllInOne.Core.Shared.OutputDTO;

namespace AllInOne.UseCases.AiTools.update;
public record UpdateAiToolCommand(AiToolUpdateDto aiToolUpdateDto) : ICommand<Result<AiToolDtoOutWithId>>;
