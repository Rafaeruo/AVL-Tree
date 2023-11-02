using System.ComponentModel;

namespace ArvoreAvl;

public class Edicao<T>
{
    private readonly Busca<T> busca;
    public Edicao(Busca<T> busca)
    {
        this.busca = busca;
    }
    public Arvore<T> Inserir(Arvore<T> arvore, T valor)
    {
        if (arvore is null)
        {
            return arvore;
        }

        var nodoExistente = busca.Buscar(arvore, valor);

        if (nodoExistente is not null)
        {
            return arvore;
        }

        return InserirDeFato(arvore, valor);
    }

    private Arvore<T> InserirDeFato(Arvore<T> arvore, T valor)
    {
        if (arvore.MenorQue(valor))
        {
            if (arvore.Direita is null)
            {
                arvore.Direita = new Arvore<T>(valor, arvore.Comparador);
            }
            else
            {
                arvore.Direita = InserirDeFato(arvore.Direita, valor);
            }
        }
        else
        {
            if (arvore.Esquerda is null)
            {
                arvore.Esquerda = new Arvore<T>(valor, arvore.Comparador);
            }
            else
            {   
                arvore.Esquerda = InserirDeFato(arvore.Esquerda, valor);
            }
        }

        arvore.RecalcularAltura();
        if (!arvore.Balanceada())
        {
            return Balancear(arvore);
        }

        return arvore;
    }

    private Arvore<T> Balancear(Arvore<T> arvore)
    {
        if ((arvore.FatorBalanceamento() > 0 && arvore.Esquerda is not null && arvore.Esquerda.FatorBalanceamento() >= 0)
            || (arvore.FatorBalanceamento() < 0 && arvore.Direita is not null && arvore.Direita.FatorBalanceamento() <= 0))
        {
            return BalancearSimples(arvore);
        }
        else
        {
            return BalancearDuplo(arvore);
        }
    }

    private Arvore<T> BalancearSimples(Arvore<T> arvore)
    {
        Arvore<T> root;
        var aDireita = arvore.FatorBalanceamento() > 0;
        if (aDireita)
        {
            root = arvore.Esquerda;
            var tempDir = root.Direita;
            root.Direita = arvore;
            arvore.Esquerda = tempDir;
        }
        else
        {
            root = arvore.Direita;
            var tempEsq = root.Esquerda;
            root.Esquerda = arvore;
            arvore.Direita = tempEsq;
        }

        arvore.RecalcularAltura();
        root.RecalcularAltura();
        return root;
    }

    private Arvore<T> BalancearDuplo(Arvore<T> arvore)
    {
        var aDireita = arvore.FatorBalanceamento() > 0;
        if (aDireita)
        {
            arvore.Esquerda = BalancearSimples(arvore.Esquerda);
            return BalancearSimples(arvore);
        }
        else
        {
            arvore.Direita = BalancearSimples(arvore.Direita);
            return BalancearSimples(arvore);
        }
    }

    public Arvore<T> Excluir(Arvore<T> arvore, T valor)
    {
        if (arvore is null)
        {
            return arvore;
        }

        var nodoExistente = busca.Buscar(arvore, valor);

        if (nodoExistente is null)
        {
            return arvore;
        }

        return ExcluirDeFato(arvore, valor);
    }

    private Arvore<T> ExcluirDeFato(Arvore<T> arvore, T valor)
    {
        if (arvore.IgualA(valor))
        {
            if (!arvore.PossuiAlgumFilho())
            {
                arvore = null;
            }
            else if (arvore.PossuiAmbosOsFilhos())
            {
                arvore = ExclusaoPorCopia(arvore);
            }
            else if (arvore.Esquerda is not null)
            {
                arvore = arvore.Esquerda;
            }
            else
            {
                arvore = arvore.Direita;
            }
            
            return arvore;
        }
        else if (arvore.MenorQue(valor))
        {
            arvore.Direita = ExcluirDeFato(arvore.Direita, valor);
        }
        else
        {
            arvore.Esquerda = ExcluirDeFato(arvore.Esquerda, valor);
        }

        arvore.RecalcularAltura();
        if (!arvore.Balanceada())
        {
            return Balancear(arvore);
        }

        return arvore;
    }

    private Arvore<T> ExclusaoPorCopia(Arvore<T> arvore)
    {
        var maiorAEsquerda = MaiorNodoNaSubarvore(arvore: arvore.Esquerda);
        arvore.Valor = maiorAEsquerda.Valor;
        arvore.Esquerda = ExcluirDeFato(arvore.Esquerda, maiorAEsquerda.Valor);

        return arvore;
    }

    private Arvore<T> MaiorNodoNaSubarvore(Arvore<T> arvore)
    {
        while (arvore.Direita != null)
        {
            arvore = arvore.Direita;
        }
        return arvore;
    }
}