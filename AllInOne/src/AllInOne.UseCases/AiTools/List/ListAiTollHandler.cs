using AllInOne.Core.Interfaces;
using AllInOne.Core.Shared.OutputDTO;

namespace AllInOne.UseCases.AiTools.List;
public class ListAiTollHandler : IQueryHandler<ListAiToolQuery, Result<IEnumerable<AiToolDtoOutWithId>>>
{
  private readonly IAiToolService _aiToolService;
  public ListAiTollHandler(IAiToolService aiToolService)
  {
    // Constructor logic if needed
    _aiToolService = aiToolService;
  }
  public async Task<Result<IEnumerable<AiToolDtoOutWithId>>> Handle(ListAiToolQuery request, CancellationToken cancellationToken)
  {
    var result = await _aiToolService.GetAiToolList();
    if (result == null || !result.Any())
    {
      return Result.NotFound("No AI Tool Found !!!");
    }
    else
    {
      // Explicitly convert List to IEnumerable to match the expected return type
      return Result.Success(result.AsEnumerable());
    }
  }
}
