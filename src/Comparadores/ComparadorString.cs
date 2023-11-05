namespace ArvoreAvl.Comparadores;

public class ComparadorString : IComparer<string>
{
    public int Compare(string x, string y)
    {
        return string.Compare(x, y, comparisonType: StringComparison.OrdinalIgnoreCase);
    }
}