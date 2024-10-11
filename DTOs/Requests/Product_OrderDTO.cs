using System.ComponentModel.DataAnnotations;

namespace GestionDeProductosYServicios.DTOs.Requests;
public class Product_OrderDTO
{

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Product quantity must be greater than 0.")]
    public int ProductQuantity { get; set; }

    [Required]
    public int ProductId { get; set; }

    [Required]
    public int OrderId { get; set; }

}