using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllInOne.Core.Interfaces;

namespace AllInOne.UseCases.AiTools.Delete;
public class DeleteAiToolHandler : ICommandHandler<DeleteAiToolCommand, Result<int>>
{
  private readonly IAiToolService _aiToolService;
  public DeleteAiToolHandler(IAiToolService aiToolService)
  {
    _aiToolService = aiToolService;
  }
  public async Task<Result<int>> Handle(DeleteAiToolCommand request, CancellationToken cancellationToken)
  {
    var result = await _aiToolService.DeleteAiToolById(request.aiToolDeleteDto);
    if (result <= 0)
    {
      return Result.Error("Failed to delete the AI tool.");
    }
    return Result.Success(result);
  }
}
