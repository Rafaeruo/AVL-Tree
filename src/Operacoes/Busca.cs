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
}