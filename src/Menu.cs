using ArvoreAvl.Comparadores;
using ArvoreAvl.Csv;
using ArvoreAvl.Dados;
using ArvoreAvl.Operacoes;

namespace ArvoreAvl;

public class Menu
{
    // dados
    private Arvore<Pessoa> arvoreCpf;
    private Arvore<Pessoa> arvoreNome;
    private Arvore<Pessoa> arvoreDataNascimento;

    // dependências
    private readonly Busca<Pessoa> busca;
    private readonly Edicao<Pessoa> edicao;
    private readonly LeitorCsv<Pessoa> leitorCsv;

    public Menu(
        Busca<Pessoa> busca, 
        Edicao<Pessoa> edicao, 
        LeitorCsv<Pessoa> leitorCsv)
    {
        this.busca = busca;
        this.edicao = edicao;
        this.leitorCsv = leitorCsv;
    }

    public void Iniciar()
    {
        var arvoresInicializadas = InicializarArvores();
        
        if (!arvoresInicializadas)
        {
            return;
        }
        while (true) {
            var opcao = PerguntarOpcao();

            if (opcao == 1) {
                var cpf = ObterTextoEntrada("Digite o CPF: ");
                var nodoCpf = busca.Buscar(arvoreCpf, new Pessoa { Cpf = cpf });

                if (nodoCpf is null)
                {
                    Console.WriteLine("Nenhuma pessoa com tal CPF encontrada");
                    continue;
                }

                Console.WriteLine($"Pessoa encontrada: {nodoCpf.Valor}");
            } 
            else if (opcao == 2) {
                var iniciaisNome = ObterTextoEntrada("Digite as primeiras letras do nome: ");
                var pessoas = new List<Pessoa>();
                PercorrerIniciasNome(arvoreNome, iniciaisNome, pessoas);
                ExibirPessoas(pessoas);
            }
            else if (opcao == 3) {
                var dataInicial = ObterDataEntrada("Digite a data inicial (DD/MM/AAAA): ");
                var dataFinal = ObterDataEntrada("Digite a data final (DD/MM/AAAA): ");
                var pessoas = new List<Pessoa>();
                PercorrerIntervaloDatas(arvoreDataNascimento, dataInicial, dataFinal, pessoas);
                ExibirPessoas(pessoas);
            }
            else if (opcao == 4) {
                arvoreCpf.ExibirTabulacao();
            }
            else if (opcao == 5) {
                arvoreNome.ExibirTabulacao();
            }
            else if (opcao == 6) {
                arvoreDataNascimento.ExibirTabulacao();
            }
            else if (opcao == 7) {
                break;
            }
            else {
                Console.WriteLine("Opção inválida");
            }

            Console.WriteLine();
            Thread.Sleep(300);
        }
    }

    public void ExibirPessoas(IEnumerable<Pessoa> pessoas)
    {
        if (!pessoas.Any())
        {
            Console.WriteLine("Nenhuma pessoa foi encontrada");
        }

        foreach (var pessoa in pessoas)
        {
            Console.WriteLine(pessoa);
        }
    }

    public void PercorrerIntervaloDatas(Arvore<Pessoa> arvore, DateTime dataInicial, DateTime dataFinal, List<Pessoa> pessoas)
    {
        if (arvore is null)
        {
            return;
        }

        if (arvore.Valor.DataNascimento >= dataInicial)
        {
            PercorrerIntervaloDatas(arvore.Esquerda, dataInicial, dataFinal, pessoas);    
        }

        if (arvore.Valor.DataNascimento >= dataInicial && arvore.Valor.DataNascimento <= dataFinal)
        {
            pessoas.Add(arvore.Valor);

        }
        
        PercorrerIntervaloDatas(arvore.Direita, dataInicial, dataFinal, pessoas);
    }

     public void PercorrerIniciasNome(Arvore<Pessoa> arvore, string iniciaisNome, List<Pessoa> pessoas)
    {
        if (arvore is null)
        {
            return;
        }

        if (arvore.Valor.Nome.StartsWith(iniciaisNome, StringComparison.OrdinalIgnoreCase))
        {
            PercorrerIniciasNome(arvore.Esquerda, iniciaisNome, pessoas);
            pessoas.Add(arvore.Valor);    
        }
        else if (new ComparadorString().Compare(iniciaisNome, arvore.Valor.Nome) < 0)
        {
            PercorrerIniciasNome(arvore.Esquerda, iniciaisNome, pessoas);
        }
        
        PercorrerIniciasNome(arvore.Direita, iniciaisNome, pessoas);
    }

    private bool InicializarArvores()
    {
        var pessoas = leitorCsv.Ler().ToArray();

        if (!pessoas.Any())
        {
            Console.WriteLine("Nenhuma pessoa no arquivo CSV");
            return false;
        }

        var comparadorString = new ComparadorString();
        var comparadorCpfPessoa = new ComparadorCpfPessoa(comparadorString);
        arvoreCpf = new Arvore<Pessoa>(pessoas.First(), comparadorCpfPessoa);
        arvoreNome = new Arvore<Pessoa>(pessoas.First(), new ComparadorNomePessoa(comparadorCpfPessoa, comparadorString));
        arvoreDataNascimento = new Arvore<Pessoa>(pessoas.First(), new ComparadorDataNascimentoPessoa(comparadorCpfPessoa));

        for (var i = 1; i < pessoas.Length; i++)
        {
            arvoreCpf = edicao.Inserir(arvoreCpf, pessoas[i]);
            arvoreNome = edicao.Inserir(arvoreNome, pessoas[i]);
            arvoreDataNascimento = edicao.Inserir(arvoreDataNascimento, pessoas[i]);
        }

        return true;
    }

    public int PerguntarOpcao()
    {
        Console.WriteLine("Escolha uma opção: ");
        Console.WriteLine("1 - Consultar pessoa por CPF");
        Console.WriteLine("2 - Consultar pessoas por primeiras letras do nome ");
        Console.WriteLine("3 - Consultar pessoas por intervalo de datas de nascimento");
        Console.WriteLine("4 - Exibir árvore (CPF)");
        Console.WriteLine("5 - Exibir árvore (Nome)");
        Console.WriteLine("6 - Exibir árvore (Data de nascimento)");
        Console.WriteLine("7 - Sair");

        return ObterInteiroEntrada("Opção: ");
    }

    private int ObterInteiroEntrada(string pergunta)
    {
        var entrada = ObterTextoEntrada(pergunta);
        _ = int.TryParse(entrada, out var opcao);
        return opcao;
    }

    private DateTime ObterDataEntrada(string pergunta)
    {
        var entradaValida = false;
        DateTime data = DateTime.MinValue;

        while (!entradaValida)
        {
            var entrada = ObterTextoEntrada(pergunta);   
            entradaValida = DateTime.TryParseExact(entrada, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out data);

            if (!entradaValida)
            {
                Console.WriteLine("Data inválida");
            }
        }
        
        return data;
    }

    private string ObterTextoEntrada(string pergunta)
    {
        Console.Write(pergunta);
        return Console.ReadLine();
    }
}