using ArvoreAvl.Dados;

namespace ArvoreAvl.Comparadores;

public class ComparadorDataNascimentoPessoa : IComparer<Pessoa>
{
    private readonly ComparadorCpfPessoa comparadorCpfPessoa;

    public ComparadorDataNascimentoPessoa(ComparadorCpfPessoa comparadorCpfPessoa)
    {
        this.comparadorCpfPessoa = comparadorCpfPessoa;
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

        return comparadorCpfPessoa.Compare(x, y);
    }
}