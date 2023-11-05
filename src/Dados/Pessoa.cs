namespace ArvoreAvl.Dados;

public record Pessoa
{
    public string Cpf { get; set; }
    public string Rg { get; set; }
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string CidadeNascimento { get; set; }
}