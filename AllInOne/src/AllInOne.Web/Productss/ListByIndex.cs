using AllInOne.Core.Models;
using AllInOne.Core.Shared.InputDTO;
using AllInOne.Core.Shared.OutputDTO;
using AllInOne.UseCases.product.Create;
using AllInOne.UseCases.product.Get;
using AllInOne.UseCases.product.ListbyIndex;

namespace AllInOne.Web.Productss;

public class ListByIndex : Endpoint<GetProductPageIndexValue, Result<List<ProductOutDto>>>
{
  private readonly IMediator _mediator;
  public ListByIndex (IMediator mediator)
  {
    _mediator = mediator;
  }
  public override void Configure()
  {
    Get("/product/listbyindex");
    AllowAnonymous();
  }
  public override async Task HandleAsync(GetProductPageIndexValue request, CancellationToken cancellationToken)
  {
    var product = await _mediator.Send(new ListByIndexQuery(request.PageIndex));
    if (!product.IsSuccess)
    {
      await SendNotFoundAsync(cancellationToken);
    }
    Response = product.Value;
  }
}
