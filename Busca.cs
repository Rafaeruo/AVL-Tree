namespace ArvoreAvl;

public class Busca
{
    public Arvore Buscar(Arvore arvore, int numero)
    {
        if (arvore is null)
        {
            return null;
        }

        // Console.Write(arvore.Valor + " ");

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