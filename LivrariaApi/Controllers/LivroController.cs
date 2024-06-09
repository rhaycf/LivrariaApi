using LivrariaApi.Data;
using LivrariaApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace LivrariaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LivroController : ControllerBase
    {
        private static int id = 0;
        private LivroContext _context;

        public LivroController(LivroContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AdicionaLivro([FromBody] Livro livro)
        {
            livro.Id = id++;
            _context.Livros.Add(livro);
            _context.SaveChanges();

            return CreatedAtAction(nameof(BuscaLivrosPorId), new { id = livro.Id }, livro);

        }

        [HttpGet]
        public IEnumerable<Livro> BuscaLivros([FromQuery] int skip = 0, [FromQuery] int take = 30)
        {
            return _context.Livros.Skip(skip).Take(take);
        }

        [HttpGet("{id}")]
        public IActionResult BuscaLivrosPorId(int id)
        {
            var livro = _context.Livros.FirstOrDefault(livro => livro.Id == id);

            if (livro == null) return NotFound();

            return Ok(livro);
        }


        [HttpPut("{id}")]
        public IActionResult AtualizaLivro(int id, [FromBody] Livro livro)
        {
            var livroExistente = _context.Livros.FirstOrDefault(livro => livro.Id == id);

            if (livroExistente == null) return NotFound();

            livroExistente.Titulo = livro.Titulo;
            livroExistente.Autor = livro.Autor;
            livroExistente.AnoPublicacao = livro.AnoPublicacao;
            livroExistente.Genero = livro.Genero;
            livroExistente.Preco = livro.Preco;

            _context.SaveChanges();
            return NoContent();

        }

        [HttpPatch("{id}")]
        public IActionResult AtualizaLivroParcial(int id, [FromBody] JsonPatchDocument<Livro> patch)
        {
            var livroParaAtualizar = _context.Livros.FirstOrDefault(livro => livro.Id == id);

            if (livroParaAtualizar == null) return NotFound();
            
            patch.ApplyTo(livroParaAtualizar, ModelState);

            if(!TryValidateModel(livroParaAtualizar))
            {
                return ValidationProblem(ModelState);
            }

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaLivro(int id)
        {
            var livro = _context.Livros.FirstOrDefault(livro => livro.Id == id);

            if (livro == null) return NotFound();

            _context.Remove(livro);
            _context.SaveChanges();

            return NoContent();            
        }
    }
}
