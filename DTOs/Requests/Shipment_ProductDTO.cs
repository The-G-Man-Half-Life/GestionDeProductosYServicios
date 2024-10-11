using System.ComponentModel.DataAnnotations;

namespace GestionDeProductosYServicios.DTOs.Requests;
public class Shipment_ProductDTO
{
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Product amount must be greater than 0.")]
    public int ProductAmount { get; set; }

    [Required]
    public int ProductId { get; set; }

    [Required]
    public int ShipmentId { get; set; }
}