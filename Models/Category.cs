using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionDeProductosYServicios.Models;

[Table("Categories")]
public class Category
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("category_id")]
    public int Category_id {get; set;}

    [Column("category_name")]
    public string Category_name {get; set;}

    [Column("category_description")]
    public string Category_description {get; set;}

    public Category(string Category_name,string Category_description)
    {
        this.Category_name = Category_name;
        this.Category_description = Category_description;
    }
}