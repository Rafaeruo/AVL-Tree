using ArvoreAvl.Dados;

namespace ArvoreAvl.Comparadores;

public class ComparadorNomePessoa : IComparer<Pessoa>
{
    private readonly ComparadorString comparadorString;

    public ComparadorNomePessoa(ComparadorString comparadorString)
    {
        this.comparadorString = comparadorString;
    }

    public int Compare(Pessoa x, Pessoa y)
    {
        return comparadorString.Compare(x.Nome, y.Nome);
    }
}