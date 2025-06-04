using System.ComponentModel.DataAnnotations;

namespace BlazorWASMWebApplication.Shared.Model
{
    public class Contact
    {
        [Key]
        public virtual int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        [Required]
        public DateOnly BirthDate { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public string SubCategory { get; set; }
        public virtual Category? Category { get; set; }
    }
}
