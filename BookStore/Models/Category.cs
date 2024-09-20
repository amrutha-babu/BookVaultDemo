using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Order Name should have atleast 3 characters")]
        [MaxLength(30, ErrorMessage ="Name should contain Maximum 30 characters")]
        [DisplayName("Category Name")]
        public string? Name { get; set; }

        [DisplayName("Display Order")]
        [Range(1,100, ErrorMessage="Display Order range must be in between 1 to 100")]
        public int DisplayOrder { get; set; }
    }
}
