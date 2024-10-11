using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionDeProductosYServicios.Models;

[Table("Shipments_Products")]
public class Shipment_Product
{
    [Key]
    [Column("Shipment_Product_id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Shipment_Product_id {get; set;}

    [Column("product_amount")]
    public int Product_amount {get; set;}

    [Column("product_id")]
    public int Product_id {get; set;}

    [ForeignKey(nameof(Product_id))]
    public Product? Product {get; set;}

    [Column("shipment_id")]
    public int Shipment_id {get; set;}

    [ForeignKey(nameof(Shipment_id))]
    public Shipment? Shipment {get; set;}

    public Shipment_Product(int Product_amount ,int Product_id ,int Shipment_id)
    {
        this.Product_amount =Product_amount;
        this.Product_id =Product_id;
        this.Shipment_id =Shipment_id;
    }
    public Shipment_Product() {}
}