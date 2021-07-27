using System.Collections.Generic;
using System.Linq;

namespace SeaBattle
{
    public class Ship
    {
        public readonly int Length;
        public Point InitalPosition;
        public bool Orientation;
        public bool Destroyed = false;
        public List<Point> Position = new List<Point>();
        public List<bool> Damaged = new List<bool>();
        public Ship(int length, Point position, bool orientation)
        {
            Length = length;
            InitalPosition = position;
            Orientation = orientation;
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
        public void Sink(Point target)
        {
            Damaged[Position.IndexOf(target)] = true;
            if(Damaged.All(d => d == true))
            {
                Destroyed = true;
                System.Console.WriteLine("Ship Sunk");
            }
        }
    }
}