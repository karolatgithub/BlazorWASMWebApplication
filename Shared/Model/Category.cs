using System.ComponentModel.DataAnnotations;

namespace BlazorWASMWebApplication.Shared.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<SubCategory> SubCategories { get; set; }
    }
}
