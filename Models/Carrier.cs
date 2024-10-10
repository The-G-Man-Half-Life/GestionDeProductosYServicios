using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionDeProductosYServicios.Models;

[Table("Carriers")]
public class Carrier
{
    [Key]
    [Column("carrier_id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Carrier_id {get; set;}

    [Column("carrier_name")]
    public string Carrier_name {get; set;}

    [Column("carrier_description")]
    public string Carrier_description {get; set;}

    public Carrier(string Carrier_name,string Carrier_description)
    {
        this.Carrier_name = Carrier_name;
        this.Carrier_description = Carrier_description;
    }
    public Carrier() {}
}