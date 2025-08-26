using AllInOne.Core.Shared.InputDTO;
using AllInOne.Core.Shared.OutputDTO;
using AllInOne.UseCases.product.Get;
using AllInOne.UseCases.ProductImageUseCaes.List;

namespace AllInOne.Web.ProductImageApi;

public class GetById : Endpoint<ProductWithId, Result<List<ProductImageDto>>>
{
  private readonly IMediator _mediator;
  public GetById(IMediator mediator)
  {
    _mediator = mediator;
  }
  public override void Configure()
  {
    Get("/productimage/get");
    AllowAnonymous();
  }
  public override async Task HandleAsync(ProductWithId request, CancellationToken cancellationToken)
  {
    var productImages = await _mediator.Send(new ListProductImageQuery(request.Id));
    if (!productImages.IsSuccess)
    {
      await SendNotFoundAsync(cancellationToken);
    }
    Response = productImages.Value;
  }
}
