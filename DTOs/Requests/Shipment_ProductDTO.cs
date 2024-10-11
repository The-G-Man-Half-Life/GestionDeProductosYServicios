using System.ComponentModel.DataAnnotations;

namespace GestionDeProductosYServicios.DTOs.Requests;
public class Shipment_ProductDTO
{
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Product amount must be greater than 0.")]
    public int Product_amount { get; set; }

    [Required]
    public int Product_id { get; set; }

    [Required]
    public int Shipment_id { get; set; }
}