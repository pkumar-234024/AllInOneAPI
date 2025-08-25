using AllInOne.Core.Models;
using AllInOne.Core.Shared.InputDTO;
using AllInOne.Core.Shared.OutputDTO;
using AllInOne.UseCases.product.Create;
using AllInOne.UseCases.product.Get;

namespace AllInOne.Web.Productss;

public class Create : Endpoint<CreatProductDto, Result<ProductOutDto>>
{
  private readonly IMediator _mediator;
  public Create(IMediator mediator)
  {
    _mediator = mediator;
  }
  public override void Configure()
  {
    Post("/product/create");
    AllowAnonymous();
    AllowFileUploads();
  }
  public override async Task HandleAsync(CreatProductDto request, CancellationToken cancellationToken)
  {
    var product = await _mediator.Send(new CreateProductCommand(request));
    if (!product.IsSuccess)
    {
      await SendNotFoundAsync(cancellationToken);
    }
    Response = product.Value;
  }
}
