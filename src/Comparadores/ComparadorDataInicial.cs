using ArvoreAvl.Dados;

namespace ArvoreAvl.Comparadores;

public class ComparadorDataIncicial : IComparer<Pessoa>
{
    public int Compare(Pessoa x, Pessoa y)
    {
        if (x.DataNascimento >= y.DataNascimento)
        {
            return 0;
        }

        return -1;
    }
}