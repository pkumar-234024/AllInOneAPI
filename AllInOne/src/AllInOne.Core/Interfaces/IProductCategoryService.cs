using AllInOne.Core.Models;
using AllInOne.Core.Shared.InputDTO;

namespace AllInOne.Core.Interfaces;
public interface IProductCategoryService 
{
    Task<ProductCategories> CreateProductCategoryAsync(CreateProductCategoryDto productCategory);
    Task<bool> DeleteProductCategoryAsync(int id);
    Task<List<ProductCategories>> GetAllProductCategoriesAsync();
    Task<ProductCategories> GetProductCategoryByIdAsync(int id);
    Task<ProductCategories> UpdateProductCategoryAsync(ProductCategories productCategory);
}
