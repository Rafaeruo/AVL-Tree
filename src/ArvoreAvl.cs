namespace ArvoreAvl;

public class Arvore<T>
{
    public Arvore(T valor, IComparer<T> comparador)
    {
        Valor = valor;
        Comparador = comparador;
    }

    public IComparer<T> Comparador;

    public T Valor { get; set; }
    public Arvore<T> Esquerda { get; set; }
    public Arvore<T> Direita { get; set; }
    public int Altura { get; set; }
    public int FatorBalanceamento()
    {
        var esquerda = Esquerda is null ? 0 : Esquerda.Altura + 1;
        var direita = Direita is null ? 0 : Direita.Altura + 1;

        return esquerda - direita;
    }

    public bool Balanceada() => FatorBalanceamento() >= -1 && FatorBalanceamento() <= 1;

    public void RecalcularAltura()
    {
        if (!PossuiAlgumFilho())
        {
            Altura = 0;
            return;
        }

        Altura = Math.Max(Esquerda?.Altura ?? 0, Direita?.Altura ?? 0) + 1;
    }

    public bool PossuiAlgumFilho() => Direita is not null || Esquerda is not null;
    public bool PossuiAmbosOsFilhos() => Direita is not null && Esquerda is not null;

    public override string ToString()
    {
        return Valor.ToString();
    }

    public void ExibirTabulacao(int profundidade = 0)
    {
        for (int i = 0; i < profundidade; i++)
        {
            Console.Write(" ");
        }
        Console.WriteLine("- " + this);

        Esquerda?.ExibirTabulacao(profundidade + 1);
        Direita?.ExibirTabulacao(profundidade + 1);
    }

    private int Comparar(T valor)
    {
        return Comparador.Compare(Valor, valor);
    }

    public bool MenorQue(T valor)
    {
        return Comparar(valor) < 0;
    }

    public bool IgualA(T valor)
    {
        return Comparar(valor) == 0;
    }

    public bool MaiorQue(T valor)
    {
        return Comparar(valor) > 0;
    }
}