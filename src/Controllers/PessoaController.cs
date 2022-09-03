using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

using src.Models;
using src.Persitence;


namespace src.Controllers;

[ApiController]
[Route("[controller]")]
public class PessoaController : ControllerBase
{
    private DataBaseContext _context { get; set; }

    public PessoaController(DataBaseContext context)
    {
        this._context = context;
    }

    [HttpGet]
    public ActionResult<List<Pessoa>> GetAllPessoas()
    {
        var result = _context.Pessoas.Include(p => p.Contratos).ToList();
        if (!result.Any())
            return NoContent();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public ActionResult<Pessoa> GetPessoaId([FromRoute] int id)
    {
        var result = _context.Pessoas.Where(b => b.Id == id).Include(p => p.Contratos).First();
        if (result is null) return NoContent();
        return Ok(result);
    }

    [HttpPost]
    public ActionResult<Pessoa> Post(Pessoa pessoa)
    {
        try
        {
            _context.Add(pessoa);
            _context.SaveChanges();
        }
        catch (System.Exception)
        {
            return BadRequest();
        }

        return Created("Criado: ", pessoa);
    }

    [HttpPut("{id}")]
    public ActionResult<Object> Update([FromRoute] int id, [FromBody] Pessoa pessoa)
    {
        var result = _context.Pessoas.SingleOrDefault(p => p.Id == id);

        if (result is null) return BadRequest(new
        {
            msg = "Registro não encontrado",
            status = HttpStatusCode.NotFound
        });
        try
        {
            _context.Pessoas.Update(pessoa);
            _context.SaveChanges();

        }
        catch
        {
            return BadRequest(new
            {
                msg = $"Ocorreu um erro de atualização para o id {id}",
                status = HttpStatusCode.BadRequest
            });
        }

        return Ok(new
        {
            msg = $"Dados do id {id} atualizados",
            status = HttpStatusCode.OK,
        });
    }

    [HttpDelete("{id}")]
    public ActionResult<Object> Delete([FromRoute] int id)
    {
        var result = _context.Pessoas.SingleOrDefault(p => p.Id == id);

        if (result is null) return BadRequest(new
        {
            msg = "Conteúdo inexistente, solicitação inválida",
            status = HttpStatusCode.BadRequest
        });

        _context.Pessoas.Remove(result);
        _context.SaveChanges();

        return Ok(new
        {
            msg = $"Deletado pessoa Id {id}",
            status = HttpStatusCode.OK
        });
    }
}