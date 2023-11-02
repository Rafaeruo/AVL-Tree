namespace ArvoreAvl.Operacoes;

public class Percorrer<T>
{
    public void PreOrdem(Arvore<T> arvore)
    {
        if (arvore is null)
        {
            return;
        }

        Console.Write(arvore.Valor + " ");

        PreOrdem(arvore.Esquerda);
        PreOrdem(arvore.Direita);
    }

    public void PosOrdem(Arvore<T> arvore)
    {
        if (arvore is null)
        {
            return;
        }

        PosOrdem(arvore.Esquerda);
        PosOrdem(arvore.Direita);

        Console.Write(arvore.Valor + " ");
    }

    public void EmOrdem(Arvore<T> arvore)
    {
        if (arvore is null)
        {
            return;
        }

        EmOrdem(arvore.Esquerda);
        Console.Write(arvore.Valor + " ");
        EmOrdem(arvore.Direita);
    }
}