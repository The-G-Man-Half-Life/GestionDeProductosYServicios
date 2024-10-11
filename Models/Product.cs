using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionDeProductosYServicios.Models;

[Table("Products")]
public class Product
{
    [Key]
    [Column("product_id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Product_id {get; set;}

    [Column("product_name")]
    public string? Product_name {get; set;}

    [Column("product_price")]
    public double Product_price {get; set;}

    [Column("product_description")]
    public string? Product_description {get; set;}

    [Column("category_id")]
    public int Category_id {get; set;}

    [ForeignKey(nameof(Category_id))]
    public Category? Category {get; set;}


    public Product(string? Product_name ,double Product_price ,string? Product_description ,int Category_id)
    {
        this.Product_name = Product_name; 
        this.Product_price = Product_price; 
        this.Product_description = Product_description; 
        this.Category_id = Category_id; 
    }
    public Product() {}
}