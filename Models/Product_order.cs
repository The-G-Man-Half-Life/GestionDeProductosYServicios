using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionDeProductosYServicios.Models;

[Table("Products_orders")]
public class Product_order
{
    [Key]
    [Column("product_order_id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Product_order_id {get; set;}

    [Column("product_quantity")]
    public int Product_quantity {get; set;}

    [Column("product_id")]
    public int Product_id {get; set;}

    [ForeignKey(nameof(Product_id))]
    public Product? Product {get; set;}

    [Column("order_id")]
    public int Order_id {get; set;}

    [ForeignKey(nameof(Order_id))]
    public Order? Order {get; set;}

    public Product_order(int Product_quantity,int Product_id,int Order_id)
    {
        this.Product_quantity = Product_quantity;
        this.Product_id = Product_id;
        this.Order_id = Order_id;
    }
    public Product_order() {}
}