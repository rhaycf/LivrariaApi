using System.ComponentModel.DataAnnotations;

namespace LivrariaApi.Models
{
    public class Livro
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage ="O título do livro é obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O nome do(a) autor(a) é obrigatório")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "O ano da publicação é obrigatório")]
        public int AnoPublicacao { get; set; }

        [Required(ErrorMessage = "O gênero do livro é obrigatório")]
        [StringLength(50, ErrorMessage ="O tamanho do gênero não pode exceder 50 caracteres")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "O preço do livro é obrigatório")]
        public double Preco { get; set; }
        
    }
}
