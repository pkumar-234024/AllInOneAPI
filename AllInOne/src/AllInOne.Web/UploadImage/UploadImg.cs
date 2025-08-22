using AllInOne.Core.Shared.OutputDTO;
using FastEndpoints;
using MediatR;

namespace AllInOne.Web.UploadImage;

public class UploadImg : Endpoint<ImageUploadFile, Result<string>>
{
  private readonly IMediator _mediator;

  public UploadImg(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Post("/product/upload");
    AllowAnonymous();
    AllowFileUploads(); // Enables file binding
  }

  public override async Task HandleAsync(ImageUploadFile request, CancellationToken cancellationToken)
  {
    if (request == null || request.FileImage!.Length == 0)
    {
      await SendErrorsAsync();
      return;
    }

    try
    {
      var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

      if (!Directory.Exists(folderPath))
        Directory.CreateDirectory(folderPath);

      var filePath = Path.Combine(folderPath, request.FileImage!.FileName);

      using (var stream = new FileStream(filePath, FileMode.Create))
      {
        await request.FileImage!.CopyToAsync(stream, cancellationToken);
      }

      // return relative path or URL
      var savedPath = $"/uploads/{request.FileImage!.FileName}";
      Response = Result<string>.Success(savedPath);
    }
    catch (Exception ex)
    {
      Response = Result<string>.Error($"File upload failed: {ex.Message}");
    }
  }
}
public class ImageUploadFile
{
  public IFormFile? FileImage { get; set; }
}
