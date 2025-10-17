using System.ComponentModel.DataAnnotations;

namespace ProductosSA.Entities
{
    public class Products
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Description { get; set; } = string.Empty;

        public decimal Cost { get; set; }

        public decimal Price { get; set; }

        public bool State {  get; set; }

    }
}
