using AllInOne.Core.Models;
using AllInOne.Core.Shared.OutputDTO;
using AllInOne.UseCases.product.Create;
using AllInOne.UseCases.product.Update;

namespace AllInOne.Web.Productss;

public class Update : Endpoint<Products,Result<ProductOutDto> >
{
  private readonly IMediator _mediator;
  public Update(IMediator mediator)
  {
    _mediator = mediator;
  }
  public override void Configure()
  {
    Patch("/product/update");
    AllowAnonymous();
  }
  public override async Task HandleAsync(Products request, CancellationToken cancellationToken)
  {
    var product = await _mediator.Send(new UpdateProductCommand(request));
    if (!product.IsSuccess)
    {
      await SendNotFoundAsync(cancellationToken);
    }
    Response = product.Value;
  }
}
