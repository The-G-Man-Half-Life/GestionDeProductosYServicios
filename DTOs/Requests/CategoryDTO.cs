using System.ComponentModel.DataAnnotations;

namespace GestionDeProductosYServicios.DTOs.Requests;
public class CategoryDTO
{
        [Required]
        [MaxLength(255)]
        public string Category_name { get; set; }

        [Required]
        public string Category_description { get; set; }
}