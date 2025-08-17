using AllInOne.Core.Interfaces;
using AllInOne.Core.Models;
using AllInOne.Core.Shared.InputDTO;

namespace AllInOne.Core.Services;
public class ProductCategoryService : IProductCategoryService
{
  private readonly IRepository<ProductCategories> _productCategoryRepository;
  public ProductCategoryService(IRepository<ProductCategories> productCategoryRepository)
  {
    // Constructor logic if needed
    _productCategoryRepository = productCategoryRepository;
  }
  public async Task<ProductCategories> CreateProductCategoryAsync(CreateProductCategoryDto productCategory)
  {
    try
    {
      var newCategory = new ProductCategories();
      newCategory.CategoryName = productCategory.CategoryName ?? string.Empty;
      newCategory.CreatedDate = DateTime.UtcNow;
      var result = await _productCategoryRepository.AddAsync(newCategory);
      return result;

    }
    catch (Exception ex)
    {
      // Log the exception or handle it as needed
      throw new NotImplementedException("Method not implemented yet.", ex);
    }
  }

  public async Task<bool> DeleteProductCategoryAsync(int id)
  {
    try
    {
      var productCategory = await _productCategoryRepository.GetByIdAsync(id);
      if (productCategory == null)
      {
        throw new Exception("Product category not found");
      }
      await _productCategoryRepository.DeleteAsync(productCategory);
      return true;
    }
    catch (Exception ex)
    {
      // Log the exception or handle it as needed
      throw new NotImplementedException("Method not implemented yet.", ex);
    }
  }

  public async Task<List<ProductCategories>> GetAllProductCategoriesAsync()
  {
    try
    {
      var result = await _productCategoryRepository.ListAsync();
      return result ?? new List<ProductCategories>();
    }
    catch (Exception ex)
    {
      // Log the exception or handle it as needed
      throw new NotImplementedException("Method not implemented yet.", ex);
    }
  }

  public async Task<ProductCategories> GetProductCategoryByIdAsync(int id)
  {
    try
    {
      var result = await _productCategoryRepository.GetByIdAsync(id);
      if (result == null)
      {
        throw new Exception("Product category not found");
      }
      return result;
    }
    catch (Exception ex)
    {
      // Log the exception or handle it as needed
      throw new NotImplementedException("Method not implemented yet.", ex);
    }
  }

  public async Task<ProductCategories> UpdateProductCategoryAsync(ProductCategories productCategory)
  {
    try
    {
      var existingCategory = await _productCategoryRepository.GetByIdAsync(productCategory.Id);
      if (existingCategory == null)
      {
        throw new Exception("Product category not found");
      } 
      existingCategory.CategoryName = productCategory.CategoryName ?? existingCategory.CategoryName;
      existingCategory.UpdatedDate = DateTime.UtcNow;
      await _productCategoryRepository.UpdateAsync(existingCategory);
      return existingCategory;
    }
    catch (Exception ex)
    {
      // Log the exception or handle it as needed
      throw new NotImplementedException("Method not implemented yet.", ex);
    }
  }
}
