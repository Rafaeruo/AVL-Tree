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
    private Pessoa[] pessoasOrdenadasPorNome;
    private Pessoa[] pessoasOrdenadasPorDataNascimento;

    // dependências
    private readonly Busca<Pessoa> busca;
    private readonly Edicao<Pessoa> edicao;
    private readonly Percorrer<Pessoa> percorrer;
    private readonly LeitorCsv<Pessoa> leitorCsv;

    public Menu(
        Busca<Pessoa> busca, 
        Edicao<Pessoa> edicao, 
        Percorrer<Pessoa> percorrer, 
        LeitorCsv<Pessoa> leitorCsv)
    {
        this.busca = busca;
        this.edicao = edicao;
        this.percorrer = percorrer;
        this.leitorCsv = leitorCsv;
    }

    public void Iniciar()
    {
        InicializarArvores();
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
                var nodoIniciais = busca.Buscar(arvoreNome, new Pessoa { Nome = iniciaisNome }, new ComparadorIniciaisPessoa(new ComparadorString()));

                if (nodoIniciais is null)
                {
                    Console.WriteLine("Nenhuma pessoa com tais iniciais encontrada");
                    continue;
                }

                var indice = (nodoIniciais.Valor as PessoaComIndice).Indice;

                for (; indice < pessoasOrdenadasPorNome.Length; indice++)
                {
                    var pessoaAtual = pessoasOrdenadasPorNome[indice];
                    if (!pessoaAtual.Nome.StartsWith(iniciaisNome))
                    {
                        break;
                    }

                    Console.WriteLine($"Pessoa com iniciais informadas: {pessoaAtual}");
                }
            }
            else if (opcao == 3) {
                var dataInicial = ObterDataEntrada("Digite a data inicial (DD/MM/AAAA): ");
                var dataFinal = ObterDataEntrada("Digite a data final (DD/MM/AAAA): ");
                var nodoData = busca.Buscar(arvoreDataNascimento, new Pessoa { DataNascimento = dataInicial }, new ComparadorDataIncicial());
                var indice = (nodoData.Valor as PessoaComIndice).Indice;

                  if (nodoData is null)
                {
                    Console.WriteLine("Nenhuma pessoa com data de nascimento no intervalo encontrada");
                    continue;
                }

                for (; indice < pessoasOrdenadasPorDataNascimento.Length; indice++)
                {
                    var pessoaAtual = pessoasOrdenadasPorDataNascimento[indice];
                    if (pessoaAtual.DataNascimento > dataFinal)
                    {
                        break;
                    }

                    Console.WriteLine($"Pessoa com data no intervalo: {pessoaAtual}");
                }
            }
            else if (opcao == 4) {
                break;
            }
            else {
                Console.WriteLine("Opção inválida");
            }

            Console.WriteLine();
            Thread.Sleep(300);
        }
    }

    private void InicializarArvores()
    {
        var pessoas = leitorCsv.Ler().ToArray();

        if (!pessoas.Any())
        {
            // TODO talvez retornar bool indicando falha.
            Console.WriteLine("Nenhuma pessoa no arquivo CSV");
            return;
        }

        pessoasOrdenadasPorNome = pessoas.OrderBy(p => p.Nome)
            .Select((p, i) => new PessoaComIndice(p, i))
            .ToArray();

        pessoasOrdenadasPorDataNascimento = pessoas.OrderBy(p => p.DataNascimento)
            .Select((p, i) => new PessoaComIndice(p, i))
            .ToArray();

        var comparadorString = new ComparadorString();
        arvoreCpf = new Arvore<Pessoa>(pessoas.First(), new ComparadorCpfPessoa(comparadorString));
        arvoreNome = new Arvore<Pessoa>(pessoasOrdenadasPorNome.First(), new ComparadorNomePessoa(comparadorString));
        arvoreDataNascimento = new Arvore<Pessoa>(pessoasOrdenadasPorDataNascimento.First(), new ComparadorDataNascimentoPessoa(comparadorString));

        for (int i = 1; i < pessoas.Length; i++)
        {
            arvoreCpf = edicao.Inserir(arvoreCpf, pessoas[i]);
            arvoreNome = edicao.Inserir(arvoreNome, pessoasOrdenadasPorNome[i]);
            arvoreDataNascimento = edicao.Inserir(arvoreDataNascimento, pessoasOrdenadasPorDataNascimento[i]);
        }
    }

    public int PerguntarOpcao()
    {
        Console.WriteLine("Escolha uma opção: ");
        Console.WriteLine("1 - Consultar pessoa por CPF");
        Console.WriteLine("2 - Consultar pessoas por primeiras letras do nome ");
        Console.WriteLine("3 - Consultar pessoas por intervalo de datas de nascimento");
        Console.WriteLine("4 - Sair");

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
        var entrada = ObterTextoEntrada(pergunta);   
        var partes = entrada.Split("/");
        var data = new DateTime(int.Parse(partes[2]), int.Parse(partes[1]), int.Parse(partes[0]));
        return data;
    }

    private string ObterTextoEntrada(string pergunta)
    {
        Console.Write(pergunta);
        return Console.ReadLine();
    }
}