using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionDeProductosYServicios.Models;

[Table("Orders")]
public class Order
{
    [Key]
    [Column("order_id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Order_id {get; set;}

    [Column("order_creation_date")]
    public DateOnly? Order_creation_date {get; set;}

    [Column("order_delivery_date")]
    public DateOnly? Order_delivery_date {get; set;}

    [Column("client_id")]
    public int Client_id {get; set;}

    [ForeignKey(nameof(Client_id))]
    public Client? Client {get; set;}

    [Column("carrier_id")]
    public int Carrier_id {get; set;}

    [ForeignKey(nameof(Carrier_id))]
    public Carrier? Carrier {get; set;}

    public Order(DateOnly? Order_creation_date ,DateOnly? Order_delivery_date ,int Client_id ,int Carrier_id)
    {
        this.Order_creation_date = Order_creation_date;
        this.Order_delivery_date = Order_delivery_date;
        this.Client_id = Client_id;
        this.Carrier_id = Carrier_id;
    }
    public Order() {}
}