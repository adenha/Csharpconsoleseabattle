using System;

namespace SeaBattle
{
    public class ComPlayer : Player
    {
        Random rng = new Random();
        public ComPlayer(Map map)
        {
            ships.Add(new Ship(2, new Point(0, 0, map), false));
            ships.Add(new Ship(3, new Point(1, 0, map), false));
            ships.Add(new Ship(4, new Point(2, 0, map), false));
        }
        public void ImportMap()
        {
            // Populate ships using json
        }

        public Point RandomPoint(Map map)
        {
            Point value;
            while (true)
            {
                int X = rng.Next(map.Width+1);
                int Y = rng.Next(map.Height+1);
                value = new Point(X, Y, map);
                if (!Firedpoints.Contains(value))
                {
                    break;
                }
            }
            return value;
        }
    }
}