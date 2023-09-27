namespace ArvoreAvl;

public class Busca
{
    public Arvore Buscar(Arvore arvore, int numero)
    {
        if (arvore is null)
        {
            return null;
        }

        if (arvore.Valor == numero)
        {
            return arvore;
        }

        if (numero > arvore.Valor)
        {
            return Buscar(arvore.Direita, numero);
        }

        return Buscar(arvore.Esquerda, numero);
    }
}