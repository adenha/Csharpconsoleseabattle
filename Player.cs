using System.Collections.Generic;
using System.Linq;

namespace SeaBattle
{
    public abstract class Player
    {
        public List<Point> Firedpoints = new List<Point>();
        public List<Ship> ships = new List<Ship>();
        public bool Lost { get { return ships.All(d => d.Destroyed = true); } }
        public string Shoot(Point target, Player enemy)
        {
            if (Firedpoints.Contains(target))
            {
                throw new System.Exception();
            }
            var message = "miss";
            Firedpoints.Add(target);
            foreach (Ship s in enemy.ships)
            {
                if (s.Position.Contains(target))
                {
                    s.Sink(target);
                    message = "Hit";
                    break;
                }
            }
            return message;
        }
    }
}