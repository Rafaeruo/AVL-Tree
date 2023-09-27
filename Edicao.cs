using System.ComponentModel;

namespace ArvoreAvl;

public class Edicao
{
    private readonly Busca busca;
    public Edicao(Busca busca)
    {
        this.busca = busca;
    }
    public Arvore Inserir(Arvore arvore, int numero)
    {
        if (arvore is null)
        {
            return arvore;
        }

        var nodoExistente = busca.Buscar(arvore, numero);

        if (nodoExistente is not null)
        {
            return arvore;
        }

        return InserirDeFato(arvore, numero);
    }

    private Arvore InserirDeFato(Arvore arvore, int numero)
    {
        if (numero > arvore.Valor)
        {
            if (arvore.Direita is null)
            {
                arvore.Direita = new Arvore(numero);
            }
            else
            {
                arvore.Direita = InserirDeFato(arvore.Direita, numero);
            }
        }
        else
        {
            if (arvore.Esquerda is null)
            {
                arvore.Esquerda = new Arvore(numero);
            }
            else
            {   
                arvore.Esquerda = InserirDeFato(arvore.Esquerda, numero);
            }
        }

        arvore.RecalcularAltura();
        if (!arvore.Balanceada())
        {
            return Balancear(arvore);
        }

        return arvore;
    }

    private Arvore Balancear(Arvore arvore)
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

    private Arvore BalancearSimples(Arvore arvore)
    {
        Arvore root;
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

    private Arvore BalancearDuplo(Arvore arvore)
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

    public Arvore Excluir(Arvore arvore, int numero)
    {
        if (arvore is null)
        {
            return arvore;
        }

        var nodoExistente = busca.Buscar(arvore, numero);

        if (nodoExistente is null)
        {
            return arvore;
        }

        return ExcluirDeFato(arvore, numero);
    }

    private Arvore ExcluirDeFato(Arvore arvore, int numero)
    {
        if (numero == arvore.Valor)
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
        else if (numero > arvore.Valor)
        {
            arvore.Direita = ExcluirDeFato(arvore.Direita, numero);
        }
        else
        {
            arvore.Esquerda = ExcluirDeFato(arvore.Esquerda, numero);
        }

        arvore.RecalcularAltura();
        if (!arvore.Balanceada())
        {
            return Balancear(arvore);
        }

        return arvore;
    }

    private Arvore ExclusaoPorCopia(Arvore arvore)
    {
        var maiorAEsquerda = MaiorNodoNaSubarvore(arvore: arvore.Esquerda);
        arvore.Valor = maiorAEsquerda.Valor;
        arvore.Esquerda = ExcluirDeFato(arvore.Esquerda, maiorAEsquerda.Valor);

        return arvore;
    }

    private Arvore MaiorNodoNaSubarvore(Arvore arvore)
    {
        while (arvore.Direita != null)
        {
            arvore = arvore.Direita;
        }
        return arvore;
    }
}