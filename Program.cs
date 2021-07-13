using System;
using System.Collections.Generic;
using System.Linq;

namespace SeaBattle
{
    class Program
    {
        public static void Main()
        {
            while (true)
            {
                Map map = new Map(7, 7);
                HumanPlayer humanPlayer = new HumanPlayer();
                ComPlayer comPlayer = new ComPlayer(map);
                string entry;
                string X = "1";
                string Y = "1";
                bool orrientation = true;
                bool playerwin = true;
                for (int i = 2; i < 5; i++)
                {
                    Console.WriteLine("Set Ship X coordinate 1-8");
                    entry = Console.ReadLine();
                    X = entry;
                    Console.WriteLine("Set Ship Y coordinate 1-8");
                    entry = Console.ReadLine();
                    Y = entry;
                    Console.WriteLine("Set Ship orrientation H for horizontal V for vertical");
                    entry = Console.ReadLine();
                    if (entry.ToLower() == "h" || entry.ToLower() == "horizontal")
                    {
                        orrientation = true;
                    }
                    else if (entry.ToLower() == "v" || entry.ToLower() == "vertical")
                    {
                        orrientation = false;
                    }
                    humanPlayer.ships.Add(new Ship(i, new Point((int.Parse(X) - 1), (int.Parse(Y) - 1), map), orrientation));
                }
                while (true)
                {
                    Console.WriteLine("Set target X coordinate 1-8");
                    entry = Console.ReadLine();
                    X = entry;
                    Console.WriteLine("Set target Y coordinate 1-8");
                    entry = Console.ReadLine();
                    Y = entry;
                    Console.WriteLine(humanPlayer.Shoot(new Point((int.Parse(X) - 1), (int.Parse(Y) - 1), map), comPlayer));
                    if (comPlayer.Lost)
                    {
                        playerwin = true;
                        break;
                    }
                    comPlayer.Shoot(comPlayer.RandomPoint(map), humanPlayer);
                    if (humanPlayer.Lost)
                    {
                        playerwin = false;
                        break;
                    }
                }
                if (playerwin)
                {
                    Console.WriteLine("You Win");
                }
                else
                {
                    Console.WriteLine("You Lose");
                }
                Console.WriteLine("Enter Q to quit enter any other key to continue");
                entry = Console.ReadLine();
                if (entry.ToLower() == "q" || entry.ToLower() == "quit")
                {
                    break;
                }
            }
        }
    }
}