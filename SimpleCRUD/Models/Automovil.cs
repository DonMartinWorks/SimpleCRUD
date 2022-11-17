using System.ComponentModel.DataAnnotations;

namespace SimpleCRUD.Models
{
    public class Automovil
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "El largo de la marca no puede mayor a 50")]
        [Display(Name = "Marca")]
        public string Brand { get; set; }

        [Required]
        [MaxLength(60, ErrorMessage = "El largo del modelo no puede mayor a 60")]
        [Display(Name = "Modelo")]
        public string Model { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [Display(Name = "Kilómetros")]
        public int Kilometers { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [Display(Name = "Precio")]
        public int Price{ get; set; }

    }
}
