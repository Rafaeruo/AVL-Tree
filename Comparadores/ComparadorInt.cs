namespace ArvoreAvl.Comparadores;

public class ComparadorInt : IComparer<int>
{
    public int Compare(int x, int y)
    {
        if (x > y)
        {
            return 1;
        }

        if (x < y)
        {
            return -1;
        }

        return 0;
    }
}