using System.Collections.Generic;

namespace SeaBattle
{
    public class Ship
    {
        public readonly int Length;
        public bool Destroyed = false;
        public List<Point> Position = new List<Point>();
        public List<bool> Damaged = new List<bool>();
        public Ship(int length, Point position, bool orientation)
        {
            Length = length;
            Damaged.Add(false);

            Position.Add(position);
            if (orientation)
            {
                for (int i = 1; i < length; i++)
                {
                    Position.Add(new Point((position.X + i), position.Y, position.Map));
                    Damaged.Add(false);
                }
            }
            else
            {
                for (int i = 1; i < length; i++)
                {
                    Position.Add(new Point(position.X, (position.Y + i), position.Map));
                    Damaged.Add(false);
                }
            }
        }
    }
}