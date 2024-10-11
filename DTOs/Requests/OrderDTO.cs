using System.ComponentModel.DataAnnotations;

namespace GestionDeProductosYServicios.DTOs.Requests;
public class OrderDTO
{
    [Required]
    public DateOnly? OrderCreationDate { get; set; }

    [Required]
    public DateOnly? OrderDeliveryDate { get; set; }

    [Required]
    public int ClientId { get; set; }

    [Required]
    public int CarrierId { get; set; }
}