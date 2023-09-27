namespace ArvoreAvl;

public class Arvore
{
    public Arvore(int numero)
    {
        this.Valor = numero;
    }

    public int Valor { get; set; }
    public Arvore Esquerda { get; set; }
    public Arvore Direita { get; set; }
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
        Console.WriteLine(this);

        Esquerda?.ExibirTabulacao(profundidade + 1);
        Direita?.ExibirTabulacao(profundidade + 1);
    }
}