using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllInOne.Core.Models;
using AllInOne.Core.Shared.OutputDTO;

namespace AllInOne.Core.Interfaces;
public interface IProductService
{
  Task<List<ProductOutDto>> GetAllProductsAsync();
  Task<ProductOutDto> GetProductByIdAsync(int id);
  Task<ProductOutDto> CreateProductAsync(Products product);
  Task<ProductOutDto> UpdateProductAsync(Products product);
  Task<bool> DeleteProductAsync(int id);

}
