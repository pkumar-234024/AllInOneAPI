using AllInOne.Core.Shared.InputDTO;
using AllInOne.Core.Shared.OutputDTO;
using AllInOne.UseCases.AiTools.List;
using AllInOne.UseCases.product.Get;

namespace AllInOne.Web.Productss;

public class GetById : Endpoint<ProductWithId, Result<ProductOutDto>>
{
  private readonly IMediator _mediator;
  public GetById(IMediator mediator)
  {
    _mediator = mediator;
  }
  public override void Configure()
  {
    Get("/product/get");
    AllowAnonymous();
  }
  public override async Task HandleAsync(ProductWithId request, CancellationToken cancellationToken)
  {
    var product = await _mediator.Send(new GetProductQuery(request.Id));
    if (!product.IsSuccess)
    {
      await SendNotFoundAsync(cancellationToken);
    }
    Response = product.Value;
  }
}
