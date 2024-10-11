using System.ComponentModel.DataAnnotations;

namespace GestionDeProductosYServicios.DTOs.Requests;
public class Product_OrderDTO
{

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Product quantity must be greater than 0.")]
    public int Product_quantity { get; set; }

    [Required]
    public int Product_id { get; set; }

    [Required]
    public int Order_id { get; set; }

}