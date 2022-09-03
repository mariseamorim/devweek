namespace src.Models;

public class Contrato
{
    public Contrato(string tokenId, double valor)
    {
        this.DataCriacao = DateTime.Now;
        this.TokenId = tokenId;
        this.Valor = valor;
    }
    public Contrato()
    {
        this.DataCriacao = DateTime.Now;
        this.Valor = 0;
        this.TokenId = "000000";
        this.Pago = false;
    }

    public int Id { get; set; }
    public DateTime DataCriacao { get; set; }
    public string TokenId { get; set; }
    public double Valor { get; set; }
    public bool Pago { get; set; }
    public int PessoaId { get; set; }

}