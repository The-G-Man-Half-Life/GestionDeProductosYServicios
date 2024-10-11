using System.ComponentModel.DataAnnotations;

namespace GestionDeProductosYServicios.DTOs.Requests;
public class OrderDTO
{
    [Required]
    public DateOnly? Order_creation_date { get; set; }

    [Required]
    public DateOnly? Order_delivery_date { get; set; }

    [Required]
    public int Client_id { get; set; }

    [Required]
    public int Carrier_id { get; set; }
}