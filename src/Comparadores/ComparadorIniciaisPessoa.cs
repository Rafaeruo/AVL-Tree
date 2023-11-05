using ArvoreAvl.Dados;

namespace ArvoreAvl.Comparadores;

public class ComparadorIniciaisPessoa : IComparer<Pessoa>
{
    private readonly ComparadorString comparadorString;

    public ComparadorIniciaisPessoa(ComparadorString comparadorString)
    {
        this.comparadorString = comparadorString;
    }

    public int Compare(Pessoa x, Pessoa y)
    {
        if (x.Nome.StartsWith(y.Nome))
        {
            return 0;
        }

        return comparadorString.Compare(x.Nome, y.Nome);   
    }
}