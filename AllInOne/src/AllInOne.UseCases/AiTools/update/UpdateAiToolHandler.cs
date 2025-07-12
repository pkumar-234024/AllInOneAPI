using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllInOne.Core.Interfaces;
using AllInOne.Core.Shared.OutputDTO;

namespace AllInOne.UseCases.AiTools.update;
public class UpdateAiToolHandler : ICommandHandler<UpdateAiToolCommand, Result<AiToolDtoOutWithId>>
{
  private readonly IAiToolService _aiToolService;
  public UpdateAiToolHandler(IAiToolService aiToolService )
  {
    _aiToolService = aiToolService;
    // Constructor logic if needed
  }
  public async Task<Result<AiToolDtoOutWithId>> Handle(UpdateAiToolCommand request, CancellationToken cancellationToken)
  {

    var result = await _aiToolService.UpdateAiToolById(request.aiToolUpdateDto);
    if (result == null)
    {
      return Result.Error("Failed to update AI tool. Please try again.");
    }
    return Result.Success( result);
  }
}
