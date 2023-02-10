using System.ComponentModel.DataAnnotations;

namespace Orange.Model
{
    public class Course
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O Titulo é obrigatório.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "O Tipo é Obrigatório.")]
        public string Type { get; set; }
        [Required(ErrorMessage = "A Url é Obrigatória.")]
        public String Link { get; set; }
        [Required(ErrorMessage = "O Autor é Obrigatório.")]
        public String Author { get; set; }
        public int? TrailId { get; set; }
        public Trail? Trail { get; set; }
    }
}
