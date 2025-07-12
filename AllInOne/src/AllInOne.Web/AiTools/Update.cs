using AllInOne.Core.Shared.InputDTO;
using AllInOne.Core.Shared.OutputDTO;
using AllInOne.UseCases.AiTools.update;

namespace AllInOne.Web.AiTools;

public class Update : Endpoint<AiToolUpdateDto, AiToolDtoOutWithId>
{
    private readonly IMediator _mediator;
    public Update(IMediator mediator)
    {
        _mediator = mediator;
    }
    public override void Configure()
    {
        Put("/AiTools/update");
        AllowAnonymous();
    }
    public override async Task HandleAsync(AiToolUpdateDto request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new UpdateAiToolCommand(request), cancellationToken);
        await SendOkAsync(result.Value, cancellationToken);
  }
}
