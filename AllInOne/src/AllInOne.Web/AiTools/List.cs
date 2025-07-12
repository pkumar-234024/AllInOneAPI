using AllInOne.Core.Shared.OutputDTO;
using AllInOne.UseCases.AiTools.List;

namespace AllInOne.Web.AiTools;

public class List : EndpointWithoutRequest<IEnumerable<AiToolDtoOutWithId>>
{
  private readonly IMediator _mediator;
  public List(IMediator mediator)
  {
    _mediator = mediator;
  }
  public override void Configure()
  {
    Get("/AiTools/list");
    AllowAnonymous();
  }
  public override async Task HandleAsync(CancellationToken cancellationToken)
  {
    var tools = await _mediator.Send(new ListAiToolQuery());
    if(!tools.IsSuccess)
    {
      await SendNotFoundAsync(cancellationToken);
    }
    Response = tools.Value;
  }
}
