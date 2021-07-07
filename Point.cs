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
        public override string ToString()
        {
            return X + "," + Y;
        }
        
        public override bool Equals(object obj)
        {
            if(!(obj is Point))
            {
                return false;
            }
            
            Point that = obj as Point;
            
            return this.X == that.X && this.Y == that.Y;
        }
        
        public override int GetHashCode()
        {
            return X.GetHashCode() * 37 + Y.GetHashCode();
        }
    }
}