using System.ComponentModel.DataAnnotations;

namespace ProductosSA.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Descripción { get; set; } = string.Empty;

        public decimal Costo { get; set; }

        public decimal Precio { get; set; }

        public int? Categoría { get; set; }

        public bool EstaActivo { get; set; }
    }
}
