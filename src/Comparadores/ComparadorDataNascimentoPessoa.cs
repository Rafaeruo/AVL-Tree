using ArvoreAvl.Dados;

namespace ArvoreAvl.Comparadores;

public class ComparadorDataNascimentoPessoa : IComparer<Pessoa>
{
    private readonly ComparadorString comparadorString;

    public ComparadorDataNascimentoPessoa(ComparadorString comparadorString)
    {
        this.comparadorString = comparadorString;
    }

    public int Compare(Pessoa x, Pessoa y)
    {
        if (x.DataNascimento > y.DataNascimento)
        {
            return 1;
        }

        if (x.DataNascimento < y.DataNascimento)
        {
            return -1;
        }

        return 0;
    }
}