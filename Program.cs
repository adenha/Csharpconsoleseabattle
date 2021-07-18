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
                int XInt;
                int YInt;
                bool orrientation = true;
                bool playerwin = true;
                for (int i = 2; i < 5; i++)
                {
                    while (true)
                    {
                        bool pointunoccupied = true;
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
                        if (int.TryParse(X, out XInt) && int.TryParse(Y, out YInt))
                        {
                            foreach (Ship s in humanPlayer.ships)
                            {
                                foreach (Point p in new Ship(i, new Point((XInt - 1), (YInt - 1), map), orrientation).Position)
                                {
                                    if (s.Position.Contains(p))
                                    {
                                        pointunoccupied = false;
                                        break;
                                    }
                                }
                                if (!pointunoccupied)
                                {
                                    break;
                                }
                            }
                            if (map.OnMap(new Point((XInt - 1), (YInt - 1), map)) && pointunoccupied)
                            {
                                break;
                            }
                            Console.WriteLine("Your Ship location overlaps one of your ships");
                        }
                        else
                        {
                            Console.WriteLine("The X and Y coordinates need to be numbers between 1-8");
                        }
                    }
                    humanPlayer.ships.Add(new Ship(i, new Point((XInt - 1), (YInt - 1), map), orrientation));
                }
                while (true)
                {
                    Console.WriteLine("Set target X coordinate 1-8");
                    entry = Console.ReadLine();
                    X = entry;
                    Console.WriteLine("Set target Y coordinate 1-8");
                    entry = Console.ReadLine();
                    Y = entry;
                    if (int.TryParse(X, out XInt) && int.TryParse(Y, out YInt))
                    {
                        Console.WriteLine(humanPlayer.Shoot(new Point((XInt - 1), (YInt - 1), map), comPlayer));
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
                    else
                    {
                        Console.WriteLine("The X and Y coordinates need to be numbers between 1-8");
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