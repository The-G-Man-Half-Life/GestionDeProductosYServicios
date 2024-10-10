using System.ComponentModel.DataAnnotations;

namespace GestionDeProductosYServicios.DTOs.Requests;
public class ClientDTO
{
        [Required]
        [MaxLength(255)]
        public string Client_name { get; set; }

        [Required]
        public string Client_address { get; set; }

        [Required]
        [MaxLength(50)] // Puedes ajustar este valor según tus necesidades
        public string Client_contact { get; set; }
}