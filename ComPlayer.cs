using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace SeaBattle
{
    public class ComPlayer : Player
    {
        Random rng = new Random();
        public ComPlayer(Map map)
        {
            List<JsonShip> imported = ImportMap();
            foreach (JsonShip s in imported)
            {
                ships.Add(new Ship(s.Length, new Point(s.InitalXPosition, s.InitalYPosition, map), s.Orientation));
            }
        }
        public List<JsonShip> ImportMap()
        {
            var importShip = new List<JsonShip>();
            var serializer = new JsonSerializer();
            using (var reader = new StreamReader("map.json"))
            using (var jsonReader = new JsonTextReader(reader))
            {
                importShip = serializer.Deserialize<List<JsonShip>>(jsonReader);
            }
            return importShip;
        }
        public Point RandomPoint(Map map)
        {
            Point value;
            while (true)
            {
                int X = rng.Next(map.Width + 1);
                int Y = rng.Next(map.Height + 1);
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