namespace jalgpall;

public class Stadium
{
    public Stadium(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public int Width { get; }

    public int Height { get; }

    public bool IsIn(double x, double y)//возращается тру или фалз зависит от того мяч внутри поля или снаружи 
    {
        return x >= 0 && x < Width && y >= 0 && y < Height;
    }
}