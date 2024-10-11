using System.ComponentModel.DataAnnotations;

namespace GestionDeProductosYServicios.DTOs.Requests;
public class ProductDTO
{
    [Required]
    [StringLength(255)]
    public string? Product_name { get; set; }

    [Required]
    [Range(0.01, double.MaxValue)]
    public double Product_price { get; set; }

    [Required]
    public string? Product_description { get; set; }

    [Required]
    public int Category_id { get; set; }
}