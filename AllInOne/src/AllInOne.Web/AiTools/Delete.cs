using AllInOne.Core.Shared.InputDTO;
using AllInOne.UseCases.AiTools.Delete;


namespace AllInOne.Web.AiTools;

public class Delete : Endpoint<AiToolDeleteDto>
{
  private readonly IMediator _mediator;

  public Delete(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Delete("/AiTools/delete/{Id}");
    AllowAnonymous();
  }

  public override async Task HandleAsync(AiToolDeleteDto request, CancellationToken cancellationToken)
  {
    AiToolDeleteDto at = new AiToolDeleteDto();
    at.Id = 1;
    var result = await _mediator.Send(new DeleteAiToolCommand(request));
    await SendAsync(result);
  }
}
