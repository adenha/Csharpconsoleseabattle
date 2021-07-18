namespace SeaBattle
{
    public class Map
    {
        public readonly int Width;
        public readonly int Height;
        public Map(int w, int h)
        {
            Width = w;
            Height = h;
        }
        public bool OnMap(Point point)
        {
            return point.X >= 0 && point.X <= Width && point.Y >= 0 && point.Y <= Height;
        }
    }
}