using System.ComponentModel.DataAnnotations;

namespace ProductosSA.Entities
{
    public class Categories
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public List<Products> Products { get; set; } = new List<Products> { };
    }
}
