using System.ComponentModel.DataAnnotations;

namespace GestionDeProductosYServicios.DTOs.Requests;
public class ShipmentDTO
{

    [Required]
    public double Shipment_weight_kg {get; set;}

    [Required]
    public double Shipment_price_usa {get; set;}

    [Required]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode = true)]
    public DateOnly? Shipment_order_date {get; set;}

    [Required]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode = true)]
    public DateOnly? Shipment_arrival_date {get; set;}

    [Required]
    public int Carrier_id {get; set;}

}