namespace SeaBattle
{
    public class Point
    {
        public int X;
        public int Y;
        public readonly Map Map;
        public Point(int x, int y, Map map)
        {
            X = x;
            Y = y;
            Map = map;
            if (!map.OnMap(this))
            {
                throw new System.Exception();
            }
        }
    }
}