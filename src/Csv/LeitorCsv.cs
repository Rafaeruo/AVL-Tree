namespace ArvoreAvl.Csv;

public class LeitorCsv<T>
{
    private readonly IMapeadorCsv<T> _mapeador;
    private const string CaminhoArquivo = "./Arquivos/pessoas.csv";
    public LeitorCsv(IMapeadorCsv<T> mapeador)
    {
        _mapeador = mapeador;
    }

    public IEnumerable<T> Ler()
    {
        var linhas = LerLinhas();
        return _mapeador.Mapear(linhas);
    }

    private string[] LerLinhas()
    {
        return File.ReadAllLines(CaminhoArquivo);
    }
}