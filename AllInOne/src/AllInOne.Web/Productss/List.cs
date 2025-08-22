using AllInOne.Core.Shared.OutputDTO;
using AllInOne.UseCases.AiTools.List;
using AllInOne.UseCases.product.List;

namespace AllInOne.Web.Productss;

public class List : EndpointWithoutRequest<Result<List<ProductOutDto>>>
{
  private readonly IMediator _mediator;
  public List(IMediator mediator)
  {
    _mediator = mediator;
  }
  public override void Configure()
  {
    Get("/product/list");
    AllowAnonymous();
  }
  public override async Task HandleAsync(CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new ListProductQuery());
    if (!result.IsSuccess)
    {
      await SendNotFoundAsync(cancellationToken);
    }
    Response = result.Value;
  }
}
