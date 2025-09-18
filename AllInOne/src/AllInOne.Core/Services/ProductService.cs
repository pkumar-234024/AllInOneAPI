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
using Microsoft.AspNetCore.Http;

namespace AllInOne.Core.Services;
public class ProductService : IProductService
{
  private readonly IRepository<Products> _productRepository;
  private readonly IRepository<ProductImages> _productImages;
  private IMapper _mapper;
 
  public ProductService(IRepository<Products> productRepository, IMapper mapper, IRepository<ProductImages> productImages  )
  {
    _productRepository = productRepository;
    _mapper = mapper;
    _productImages = productImages;
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

      //master image for product
      var masterFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "masterImage");

      if (!Directory.Exists(masterFolderPath))
        Directory.CreateDirectory(masterFolderPath);

      var filePath = Path.Combine(masterFolderPath, product.ImageFile!.FileName);

      using (var stream = new FileStream(filePath, FileMode.Create))
      {
        await product.ImageFile!.CopyToAsync(stream);
      }

      

      // return relative path or URL
      var savedPath = $"/uploads/{product.ImageFile!.FileName}";
      ObjProduct.ImagePath = savedPath;
      ObjProduct.ImageName = product.ImageFile!.FileName;
      var result = await _productRepository.AddAsync(ObjProduct);
      //child productimages
      if (product.ProductiImagesChild != null && product.ProductiImagesChild.Count > 0)
      {
        var childImageresult = await UploadChildImages(product.ProductiImagesChild, result.Id);
        //var childFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "childImage");
        //if (!Directory.Exists(childFolderPath))
        //  Directory.CreateDirectory(childFolderPath);
        //foreach (var image in product.ProductiImagesChild)
        //{
        //  if (image != null && image.Length > 0)
        //  {
        //    var childFilePath = Path.Combine(childFolderPath, image.FileName);
        //    using (var stream = new FileStream(childFilePath, FileMode.Create))
        //    {
        //      await image.CopyToAsync(stream);
        //    }
        //    // Here you can also save the child image paths to the database if needed
        //  }
        //}
      }
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

      // Delete image from wwwroot if exists
      if (!string.IsNullOrEmpty(result.ImagePath))
      {
        var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
        var filePath = Path.Combine(folderPath, result.ImageName);
        if (File.Exists(filePath))
        {
          File.Delete(filePath);


        }
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

  public async Task<List<ProductOutDto>> GetAllProductsByIndexAsync(int index)
  {
    try
    {
      var productByIndexSpec = new Specification.GetProductByPagesIndexSpec(index, 10);
      var result = await _productRepository.ListAsync(productByIndexSpec);
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

  private async Task<bool> UploadChildImages(List<IFormFile> childImages, int productId)
  {
    try
    {
      var childFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "childImage");
      if (!Directory.Exists(childFolderPath))
        Directory.CreateDirectory(childFolderPath);
      foreach (var image in childImages)
      {
        if (image != null && image.Length > 0)
        {
          var childFilePath = Path.Combine(childFolderPath, image.FileName);
          using (var stream = new FileStream(childFilePath, FileMode.Create))
          {
            await image.CopyToAsync(stream);
          }
          // Here you can also save the child image paths to the database if needed
          var childImage = new ProductImages
          {
            ProductId = productId,
            ImageName = image.FileName,
            CreatedDate = DateTime.Now,
          };
          var result = await _productImages.AddAsync(childImage);
        }
       
      }
      return true;
    }
    catch
    {
      return false;
    }
  }
}
