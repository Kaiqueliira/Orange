using System.ComponentModel.DataAnnotations;

namespace Orange.Model
{
    public class Trail
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O titulo é obrigatório.")]
        public string Title { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Course>? Courses { get; set; }
    }
}
