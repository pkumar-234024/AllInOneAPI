using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AllInOne.Core.Interfaces;
using AllInOne.Core.Models;
using AllInOne.Core.Shared.InputDTO;
using AllInOne.Core.Shared.OutputDTO;
using AllInOne.Core.Specification;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AllInOne.Core.Services;
public class ProductImageService : IProductImageService
{
  private readonly IRepository<ProductImages> _productImages;
  private readonly IMapper _mapper;
  public ProductImageService(IRepository<ProductImages> productImages, IMapper mapper)
  {
    _productImages = productImages;
    _mapper = mapper;

  }
  public async Task<bool> CreateProductImages(CreateProductImageDto productImageDto)
  {
    try
    {
      if (productImageDto.ImageFiles != null && productImageDto.ImageFiles.Any())
      {
        foreach(var imageFile in productImageDto.ImageFiles)
        {
          if (imageFile!.FileName == null || imageFile!.FileName.Length == 0)
          {
            throw new Exception("Image is not Empty!");
          }
          var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

          if (!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);

          var filePath = Path.Combine(folderPath, imageFile.FileName!);

          using (var stream = new FileStream(filePath, FileMode.Create))
          {
            await imageFile!.CopyToAsync(stream);
          }

          // return relative path or URL
          var savedPath = $"/uploads/{imageFile.FileName}";
          ProductImages productImage = new ProductImages();
          productImage.ProductId = productImageDto.ProductId;
          productImage.ImageName = imageFile.FileName!;
          await _productImages.AddAsync(productImage);
        }
      }
      return true;
    }
    catch (Exception ex)
    {
      throw new Exception($"{ex.Message}");
    }
  }

  public async Task<List<ProductImageDto>> ListImageByProductId(int productId)
  {
    try
    {
      var spec = new GetProductImageByProductIdSpec(productId);
      var result = await _productImages.ListAsync(spec);
      List<ProductImageDto> dto = new List<ProductImageDto>();
      foreach (var res in result) {
        dto.Add(_mapper.Map<ProductImageDto>(res)); 
      }
      return dto;
    }
    catch(Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }
}
