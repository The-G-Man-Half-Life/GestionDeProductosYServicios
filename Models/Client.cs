using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionDeProductosYServicios.Models;

[Table("Clients")]
public class Client
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("client_name")]
    public string Client_name  {get; set;}

    [Column("client_address")]
    public string Client_address  {get; set;}

    [Column("client_contact")]
    public string Client_contact  {get; set;}

    public Client(string Client_name ,string Client_address ,string Client_contact)
    {
        this.Client_name = Client_name;
        this.Client_address = Client_address;
        this.Client_contact = Client_contact;
    }
}