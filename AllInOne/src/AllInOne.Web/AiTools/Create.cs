using AllInOne.Core.Shared.InputDTO;
using AllInOne.Core.Shared.OutputDTO;
using AllInOne.UseCases.AiTools.Create;

namespace AllInOne.Web.AiTools;

public class Create : Endpoint<AiToolCreateDto, AiToolDtoOutWithId>
{
    private readonly IMediator _mediator;
    public Create(IMediator mediator)
    {
        _mediator = mediator;
    }
    public override void Configure()
    {
        Post("/AiTools/create");
        AllowAnonymous();
    }
    public override async Task HandleAsync(AiToolCreateDto request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new CreateAiToolCommand(request), cancellationToken);

        // Fix for CS1501: Provide the required second argument to SendCreatedAtAsync
        Response = result.Value;
  }
}
