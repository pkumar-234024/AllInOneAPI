using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllInOne.Core.Models;
using AllInOne.Core.Shared.InputDTO;
using AllInOne.Core.Shared.OutputDTO;
using AutoMapper;

namespace AllInOne.Core.mapper;
public class MapperProfile : Profile
{
  public MapperProfile()
  {
    CreateMap<Products, ProductOutDto>();
    CreateMap<CreatProductDto, Products>();
    CreateMap<UpdateProductDto, Products>();
    CreateMap<ProductImages, ProductImageDto>();
  }
}
