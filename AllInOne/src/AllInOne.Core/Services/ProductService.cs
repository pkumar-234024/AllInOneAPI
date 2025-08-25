using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AllInOne.Core.Interfaces;
using AllInOne.Core.Models;
using AllInOne.Core.Shared.InputDTO;
using AllInOne.Core.Shared.OutputDTO;
using AutoMapper;
using MediatR;

namespace AllInOne.Core.Services;
public class ProductService : IProductService
{
  private readonly IRepository<Products> _productRepository;
  private IMapper _mapper;
  public ProductService(IRepository<Products> productRepository, IMapper mapper)
  {
    _productRepository = productRepository;
    _mapper = mapper;
  }
  public async Task<ProductOutDto> CreateProductAsync(CreatProductDto product)
  {
    try
    {
      var ObjProduct = _mapper.Map<Products>(product);

      if (product.ImageFile == null || product.ImageFile!.Length == 0)
      {
        throw new Exception("Image is not Empty!");
      }
      var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

      if (!Directory.Exists(folderPath))
        Directory.CreateDirectory(folderPath);

      var filePath = Path.Combine(folderPath, product.ImageFile!.FileName);

      using (var stream = new FileStream(filePath, FileMode.Create))
      {
        await product.ImageFile!.CopyToAsync(stream);
      }

      // return relative path or URL
      var savedPath = $"/uploads/{product.ImageFile!.FileName}";
      ObjProduct.ImagePath = savedPath;
      ObjProduct.ImageName = product.ImageFile!.FileName;
      var result = await _productRepository.AddAsync(ObjProduct);
      return _mapper.Map<ProductOutDto>(result);
    }
    catch (Exception ex)
    {
      throw new Exception($"Message : {ex.Message}, StackTrace : {ex.StackTrace}");
    }
  }

  public async Task<bool> DeleteProductAsync(int id)
  {
    try
    {
      var result = await _productRepository.GetByIdAsync(id);
      if (result == null)
      {
        throw new Exception("Product not found");
      }
      await _productRepository.DeleteAsync(result);
      return true;
    }
    catch (Exception ex)
    {
      throw new Exception($"Message : {ex.Message}, StackTrace : {ex.StackTrace}");
    }
  }

  public async Task<List<ProductOutDto>> GetAllProductsAsync()
  {
    try
    {
      var result = await _productRepository.ListAsync();
      if (result == null || !result.Any())
      {
        throw new Exception("No products found");
      }
      var mappedResult = _mapper.Map<List<ProductOutDto>>(result);
      return mappedResult;
    }
    catch (Exception ex)
    {
      throw new Exception($"Message : {ex.Message}, StackTrace : {ex.StackTrace}");
    }
  }

  public async Task<ProductOutDto> GetProductByIdAsync(int id)
  {
    try
    {
      var result = await _productRepository.GetByIdAsync(id);
      if (result == null)
      {
        throw new Exception("Product not found");
      }
      var mappedResult = _mapper.Map<ProductOutDto>(result);
      return mappedResult;
    }
    catch (Exception ex)
    {
      throw new Exception($"Message : {ex.Message}, StackTrace : {ex.StackTrace}");
    }
  }

  public async Task<ProductOutDto> UpdateProductAsync(UpdateProductDto product)
  {
    try
    {

      if (product.ImageFile == null || product.ImageFile!.Length == 0)
      {
        throw new Exception("Image is not Empty!");
      }
      var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

      if (!Directory.Exists(folderPath))
        Directory.CreateDirectory(folderPath);

      var filePath = Path.Combine(folderPath, product.ImageFile!.FileName);

      using (var stream = new FileStream(filePath, FileMode.Create))
      {
        await product.ImageFile!.CopyToAsync(stream);
      }

      // return relative path or URL
      var savedPath = $"/uploads/{product.ImageFile!.FileName}";


      var existingProduct = await _productRepository.GetByIdAsync(product.Id);
      if (existingProduct == null)
      {
        throw new Exception("Product not found");
      }
      existingProduct = _mapper.Map(product, existingProduct);
      existingProduct.ImagePath = savedPath;
      existingProduct.ImageName = product.ImageFile!.FileName;
      await _productRepository.UpdateAsync(existingProduct);
      return _mapper.Map<ProductOutDto>(existingProduct);
    }
    catch (Exception ex)
    {
      throw new Exception($"Message : {ex.Message}, StackTrace : {ex.StackTrace}");
    }
  }
}
