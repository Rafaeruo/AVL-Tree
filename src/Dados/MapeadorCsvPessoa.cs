using ArvoreAvl.Csv;

namespace ArvoreAvl.Dados;

public class MapeadorCsvPessoa : IMapeadorCsv<Pessoa>
{
    private const char Separador = ';';
    public IEnumerable<Pessoa> Mapear(string[] linhasCsv)
    {
        var pessoas = new Pessoa[linhasCsv.Length];

        for (var i = 0; i < linhasCsv.Length; i++)
        {
            var colunas = linhasCsv[i].Split(Separador);
            var pessoa = new Pessoa
            {
                Cpf = colunas[0],
                Rg = colunas[1],
                Nome = colunas[2],
                DataNascimento = ObterData(colunas[3]),
                CidadeNascimento = colunas[4]
            };

            pessoas[i] = pessoa;
        }

        return pessoas;
    }

    private DateTime ObterData(string dataTexto)
    {
        var partes = dataTexto.Split("/");
        return new DateTime(int.Parse(partes[2]), int.Parse(partes[1]), int.Parse(partes[0]));
    }
}