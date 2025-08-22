using AllInOne.Core.Models;
using AllInOne.Core.Shared.InputDTO;
using AllInOne.UseCases.product.Create;
using AllInOne.UseCases.product.Delete;

namespace AllInOne.Web.Productss;

public class Delete : Endpoint<ProductWithId>
{
  private readonly IMediator _mediator;
  public Delete(IMediator mediator)
  {
    _mediator = mediator;
  }
  public override void Configure()
  {
    Delete("/product/delete/{Id}");
    AllowAnonymous();
  }
  public override async Task HandleAsync(ProductWithId request, CancellationToken cancellationToken)
  {
    var product = await _mediator.Send(new DeleteProductCommand(request.Id));
    if (!product.IsSuccess)
    {
      await SendNotFoundAsync(cancellationToken);
    }
    Response = product.Value;
  }
}
