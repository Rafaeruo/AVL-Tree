namespace ArvoreAvl.Csv;

public interface IMapeadorCsv<T>
{
    IEnumerable<T> Mapear(string[] linhasCsv);
}