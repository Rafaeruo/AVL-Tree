namespace ArvoreAvl;

public class Menu
{
    private Arvore arvore;
    private readonly Busca busca;
    private readonly Edicao edicao;
    private readonly Percorrer percorrer;

    public Menu(Busca busca, Edicao edicao, Percorrer percorrer) {
        this.busca = busca;
        this.edicao = edicao;
        this.percorrer = percorrer;
    }

    public void Iniciar()
    {
        InicializarArvore();
        while (true) {
            var opcao = PerguntarOpcao();

            if (opcao == 1) {
                arvore.ExibirTabulacao();
            } 
            else if (opcao == 2) {
                arvore = edicao.Inserir(arvore, ObterInteiroEntrada());
            }
            else if (opcao == 3) {
                arvore = edicao.Excluir(arvore, ObterInteiroEntrada());

                if (arvore is null)
                {
                    Console.WriteLine("Nodo raíz excluído, recriando a árvore de raíz."); // TODO ver todos os casos de exclusao de raiz p/ ver se ta ok
                    InicializarArvore();
                }
            }
            else if (opcao == 4) {
                var nodoEncontrado = busca.Buscar(arvore, ObterInteiroEntrada());
                Console.WriteLine(nodoEncontrado is null ? "Não há nenhum nodo com esse valor ná árvore" : "Há um nodo com esse valor na árvore");
            }
            else if (opcao == 5) {
                percorrer.PreOrdem(arvore);
                Console.WriteLine();
            }
            else if (opcao == 6) {
                percorrer.PosOrdem(arvore);
                Console.WriteLine();
            }
            else if (opcao == 7) {
                percorrer.EmOrdem(arvore);
                Console.WriteLine();
            }
            else if (opcao == 8) {
                break;
            }
            else {
                Console.WriteLine("Opção inválida");
            }
        }
    }

    private void InicializarArvore()
    {
        Console.WriteLine("Digite o valor inteiro do nodo raíz da árvore");
        var valorRaiz = ObterInteiroEntrada();
        arvore = new Arvore(valorRaiz);
    }

    public int PerguntarOpcao()
    {
        Console.WriteLine("Escolha uma opção: ");

        Console.WriteLine("1 - Exibir a árvore ");
        Console.WriteLine("2 - Inserir ");
        Console.WriteLine("3 - Excluir");
        Console.WriteLine("4 - Buscar");
        Console.WriteLine("5 - Encaminhamento pré-ordem");
        Console.WriteLine("6 - Encaminhamento pós-ordem");
        Console.WriteLine("7 - Encaminhamento em-ordem");
        Console.WriteLine("8 - Sair");

        return ObterInteiroEntrada();
    }

    private int ObterInteiroEntrada()
    {
        var entrada = Console.ReadLine();
        _ = int.TryParse(entrada, out var opcao);
        return opcao;
    }
}