using ArvoreAvl.Dados;

namespace ArvoreAvl.Comparadores;

public class ComparadorNomePessoa : IComparer<Pessoa>
{
    private readonly ComparadorCpfPessoa comparadorCpfPessoa;
    private readonly ComparadorString comparadorString;

    public ComparadorNomePessoa(ComparadorCpfPessoa comparadorCpfPessoa, ComparadorString comparadorString)
    {
        this.comparadorCpfPessoa = comparadorCpfPessoa;
        this.comparadorString = comparadorString;
    }

    public int Compare(Pessoa x, Pessoa y)
    {
        var comparacaoNomes = comparadorString.Compare(x.Nome, y.Nome);

        if (comparacaoNomes == 0)
        {
            return comparadorCpfPessoa.Compare(x, y);
        }

        return comparacaoNomes;
    }
}