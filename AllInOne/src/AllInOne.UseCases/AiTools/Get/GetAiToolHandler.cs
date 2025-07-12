using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllInOne.Core.Interfaces;
using AllInOne.Core.Shared.OutputDTO;

namespace AllInOne.UseCases.AiTools.Get;
public class GetAiToolHandler : IQueryHandler<GetAiToolQuery, Result<AiToolDtoOutWithId>>
{
  private readonly IAiToolService _aiToolService;
  public GetAiToolHandler(IAiToolService aiToolService)
  {
    // Constructor logic if needed
    _aiToolService = aiToolService;
  }
  public async Task<Result<AiToolDtoOutWithId>> Handle(GetAiToolQuery request, CancellationToken cancellationToken)
  {
    var result = await _aiToolService.GetAiToolById(request.aiToolGetDto.Id);
    if (result == null)
    {
      return Result.NotFound("No Ai Tool for this Id !!!");
    }
    return Result.Success(result);
  }
}
