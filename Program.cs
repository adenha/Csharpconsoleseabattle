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
                        if (int.TryParse(X, out XInt) && int.TryParse(Y, out YInt) && XInt < 9 && XInt > 0 && YInt < 9 && YInt > 0)
                        {
                            try
                            {
                                Ship trys = new Ship(i, new Point((XInt - 1), (YInt - 1), map), orrientation);
                                foreach (Ship s in humanPlayer.ships)
                                {
                                    foreach (Point p in trys.Position)
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
                            catch (System.Exception)
                            {
                                Console.WriteLine("At that position your ship goes off the map. Pick another position");
                            }
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
                    if (int.TryParse(X, out XInt) && int.TryParse(Y, out YInt) && XInt < 9 && XInt > 0 && YInt < 9 && YInt > 0)
                    {
                        Point point = new Point((XInt - 1), (YInt - 1), map);
                        if (!humanPlayer.Firedpoints.Contains(point))
                        {
                            Console.WriteLine(humanPlayer.Shoot(point, comPlayer));
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
                            Console.WriteLine("You Already fired on that point please pick another point.");
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
                Console.WriteLine("Enter Y to save your map as a json any other key continue without saving");
                entry = Console.ReadLine();
                if (entry.ToLower() == "y" || entry.ToLower() == "yes" || entry.ToLower() == "save")
                {
                    Console.WriteLine("Enter the name you want your json to have");
                    entry = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(entry))
                    {
                        humanPlayer.ExportMap();
                    }
                    else
                    {
                        humanPlayer.ExportMap(entry);
                    }
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