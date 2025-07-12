
using AllInOne.Core.Interfaces;
using AllInOne.Core.Shared.OutputDTO;

namespace AllInOne.UseCases.AiTools.Create;
public class CreateAiToolHandler : ICommandHandler<CreateAiToolCommand, Result<AiToolDtoOutWithId>>
{
  private readonly IAiToolService _aiToolService;
  public CreateAiToolHandler(IAiToolService aiToolService)
  {
    // Constructor logic can be added here if needed
    _aiToolService = aiToolService;
  }
  public async Task<Result<AiToolDtoOutWithId>> Handle(CreateAiToolCommand request, CancellationToken cancellationToken)
  {
    // Implementation of the command handler logic goes here

    var result = await _aiToolService.CreateAiTool(request.aiToolCreateDto);

    if (result == null)
    {
      return Result.Error("No Ai Tool created !!!");
    }
    return Result.Success(result);
  }
}
