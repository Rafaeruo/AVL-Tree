namespace ArvoreAvl.Operacoes;

public class Busca<T>
{
    public Arvore<T> Buscar(Arvore<T> arvore, T valor)
    {
        if (arvore is null)
        {
            return null;
        }

        if (arvore.IgualA(valor))
        {
            return arvore;
        }

        if (arvore.MenorQue(valor))
        {
            return Buscar(arvore.Direita, valor);
        }

        return Buscar(arvore.Esquerda, valor);
    }

    public Arvore<T> Buscar(Arvore<T> arvore, T valor, IComparer<T> comparador)
    {
        if (arvore is null)
        {
            return null;
        }

        var comparacao = comparador.Compare(arvore.Valor, valor);
        if (comparacao == 0)
        {
            return arvore;
        }

        if (comparacao < 0)
        {
            return Buscar(arvore.Direita, valor, comparador);
        }

        return Buscar(arvore.Esquerda, valor, comparador);
    }
}