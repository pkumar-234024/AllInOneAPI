using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AllInOne.Core.Models;
public class Products : BaseClass
{
  public string ProductName { get; set; } = string.Empty;
  public decimal Price { get; set; }
  public string Description { get; set; } = string.Empty;
  public string ImagePath { get; set; } = string.Empty;
  //public byte[]? Image { get; set; } // Nullable byte array for image data
  public int? CategoryId { get; set; }
  public int ProductRating { get; set; } // Assuming ProductRating is an integer value
  public int NumberOfReviews { get; set; } // Assuming NumberOfReviews is an integer value
  public string ProductFeatures { get; set; } = string.Empty; // Assuming ProductFeatures is a string containing features of the product
  public string PrintType { get; set; } = string.Empty; // Assuming PrintType is a string representing the type of print (e.g., "3D", "2D", etc.)
  public string PaperQuality { get; set; } = string.Empty; // Assuming PaperQuality is a string representing the quality of paper used for printing
  public int TurnaroudnTime { get; set; }  // Assuming TurnaroundTime is a string representing the time taken for printing and delivery
  public int MinimumOrderQuantity { get; set; } // Assuming MinimumOrderQuantity is an integer representing the minimum quantity that can be ordered

  public IFormFile? Image { get; set; }
}
