
using System.ComponentModel.DataAnnotations;

namespace AllInOne.Core.Shared.OutputDTO;
public  class ProductOutDto
{
  public int Id { get; set; } // Assuming Id is an integer
  public string ProductName { get; set; } = string.Empty;
  public decimal Price { get; set; }
  public string Description { get; set; } = string.Empty;
  public string ImageName { get; set; } = string.Empty;
  public int CategoryId { get; set; }
  public int ProductRating { get; set; } // Assuming ProductRating is an integer value
  public int NumberOfReviews { get; set; } // Assuming NumberOfReviews is an integer value
  public string[] ProductFeatures { get; set; } = []; // Assuming ProductFeatures is a string containing features of the product
  public string PrintType { get; set; } = string.Empty; // Assuming PrintType is a string representing the type of print (e.g., "3D", "2D", etc.)
  public string PaperQuality { get; set; } = string.Empty; // Assuming PaperQuality is a string representing the quality of paper used for printing
  public int TurnaroudnTime { get; set; }  // Assuming TurnaroundTime is a string representing the time taken for printing and delivery
  public int MinimumOrderQuantity { get; set; } // Assuming MinimumOrderQuantity is an integer representing the minimum quantity that can be ordere
  public string DesignSupport { get; set; } = string.Empty;
  public string Delivery { get; set; } = string.Empty;
  public bool InStock { get; set; } = true;
}
