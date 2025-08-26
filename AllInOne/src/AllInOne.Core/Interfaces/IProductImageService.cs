using AllInOne.Core.Shared.InputDTO;
using AllInOne.Core.Shared.OutputDTO;

namespace AllInOne.Core.Interfaces;
public interface IProductImageService
{
  Task<bool> CreateProductImages(CreateProductImageDto productImageDto);

  Task<List<ProductImageDto>> ListImageByProductId(int productId);
}
