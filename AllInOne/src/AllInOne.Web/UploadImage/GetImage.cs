using FastEndpoints;
using Microsoft.AspNetCore.Http;

namespace AllInOne.Web.UploadImage;

public class GetImage : EndpointWithoutRequest
{
  public override void Configure()
  {
    Get("/product/image/{fileName}");
    AllowAnonymous();
  }

  public override async Task HandleAsync(CancellationToken cancellationToken)
  {
    var fileName = Route<string>("fileName");
    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", fileName!);

    if (!System.IO.File.Exists(filePath))
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    var contentType = GetContentType(filePath);

    // read bytes manually so we can control headers
    var bytes = await System.IO.File.ReadAllBytesAsync(filePath, cancellationToken);

    HttpContext.Response.ContentType = contentType;
    HttpContext.Response.Headers.ContentDisposition = $"inline; filename=\"{fileName}\"";

    await HttpContext.Response.Body.WriteAsync(bytes, cancellationToken);
  }

  private static string GetContentType(string path)
  {
    var ext = Path.GetExtension(path).ToLowerInvariant();
    return ext switch
    {
      ".jpg" or ".jpeg" => "image/jpeg",
      ".png" => "image/png",
      ".gif" => "image/gif",
      _ => "application/octet-stream"
    };
  }
}
