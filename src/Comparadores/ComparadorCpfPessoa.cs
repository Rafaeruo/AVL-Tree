using ArvoreAvl.Dados;

namespace ArvoreAvl.Comparadores;

public class ComparadorCpfPessoa : IComparer<Pessoa>
{
    private readonly ComparadorString comparadorString;

    public ComparadorCpfPessoa(ComparadorString comparadorString)
    {
        this.comparadorString = comparadorString;
    }

    public int Compare(Pessoa x, Pessoa y)
    {
        return comparadorString.Compare(x.Cpf, y.Cpf);
    }
}