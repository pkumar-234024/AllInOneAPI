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
