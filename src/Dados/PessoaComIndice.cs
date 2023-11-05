namespace ArvoreAvl.Dados;

public record PessoaComIndice : Pessoa
{
    public PessoaComIndice(Pessoa pessoa, int indice)
    {
        Cpf = pessoa.Cpf;
        Rg = pessoa.Rg;
        Nome = pessoa.Nome;
        DataNascimento = pessoa.DataNascimento;
        CidadeNascimento = pessoa.CidadeNascimento;
        Indice = indice;
    }

    public int Indice { get; set; }
}