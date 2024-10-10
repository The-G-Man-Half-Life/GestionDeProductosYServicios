using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionDeProductosYServicios.Models;

[Table("Shipments")]
public class Shipments
{
    [Key]
    [Column("shipments_id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Shipments_id {get; set;}

    [Column("shipments_name")]
    public string Shipments_name {get; set;}

    [Column("shipments_description")]
    public string Shipments_description {get; set;}

    public Shipments(string Shipments_name,string Shipments_description)
    {
        this.Shipments_name = Shipments_name;
        this.Shipments_description = Shipments_description;
    }
    public Shipments() {}
}