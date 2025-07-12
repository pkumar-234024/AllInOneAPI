using AllInOne.Core.Shared.InputDTO;
using AllInOne.Core.Shared.OutputDTO;
using AllInOne.UseCases.AiTools.Get;

namespace AllInOne.Web.AiTools;

public class Get : Endpoint<AiToolGetDto, AiToolDtoOutWithId>
{
  private readonly IMediator _mediator;
  public Get(IMediator mediator)
  {
    _mediator = mediator;
  }
  public override void Configure()
  {
    Get("/AiTools/get");
    AllowAnonymous();
  }
  public override async Task HandleAsync(AiToolGetDto req, CancellationToken ct)
  {
    var result = await _mediator.Send(new GetAiToolQuery(req));
    await SendOkAsync(result.Value, ct);
  }
}
