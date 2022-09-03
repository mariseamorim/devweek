using System.Collections.Generic;
namespace src.Models;

public class Pessoa
{
    public Pessoa()
    {
        this.Nome = "template";
        this.Idade = 0;
        this.Ativo = true;
    }

    public Pessoa(string nome, int idade, string cpf)
    {
        this.Nome = nome;
        this.Idade = idade;
        this.Cpf = cpf;
        this.Ativo = true;
        this.Contratos = new List<Contrato>();

    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public int Idade { get; set; }
    public string? Cpf { get; set; }
    public bool Ativo { get; set; }
    public List<Contrato> Contratos { get; set; }

}