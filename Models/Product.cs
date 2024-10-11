using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionDeProductosYServicios.Models;

[Table("Products")]
public class Products
{
    [Key]
    [Column("product_id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Product_id {get; set;}

    [Column("product_amount")]
    public int Product_amount {get; set;}

    [Column("product_id")]
    public int Product_id {get; set;}

    [ForeignKey(nameof(Product_id))]
    public Product? Carrier {get; set;}

    public Shipment(double Shipment_weight_kg ,double Shipment_price_usa ,DateOnly? Shipment_order_date ,DateOnly? Shipment_arrival_date ,int Carrier_id)
    {
        this.Shipment_weight_k = Shipment_weight_kg;
        this.Shipment_price_usa = Shipment_price_usa;
        this.Shipment_order_date = Shipment_order_date;
        this.Shipment_arrival_date = Shipment_arrival_date;
        this.Carrier_id = Carrier_id;
    }
    public Shipment() {}
}