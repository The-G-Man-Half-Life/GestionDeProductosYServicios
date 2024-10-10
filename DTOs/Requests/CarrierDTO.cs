using System.ComponentModel.DataAnnotations;

namespace GestionDeProductosYServicios.DTOs.Requests;
public class CarrierDTO
{
        [Required]
        [MaxLength(255)]
        public string Carrier_name { get; set; }

        [Required]
        public string Carrier_description { get; set; }
}