using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFOGame.Classes
{
    public class UFOInterface
    {
        public void Run()
        {
            Console.WriteLine("You are the captain of an alien spaceship!");
            Console.WriteLine("How many crew members will you take with you to Earth?");

            int crewSize = int.Parse(Console.ReadLine());
            UFO ship = new UFO(crewSize);

            while (!ship.Destroyed && ship.AbductionQuota > ship.CowsAbducted)
            {
                MakeNextMove(ship);
            }
            if (ship.Destroyed)
            {
                Console.WriteLine("You've been shot down! Looks like you will never make it home...");
            }
            else
            {
                Console.WriteLine("You can head for home! The alien king congratulates you for collecting so many cows!");
            }
        }

        private static void MakeNextMove(UFO ship)
        {
            Console.WriteLine("You'll need to abduct " + (ship.AbductionQuota - ship.CowsAbducted) + " cows before you can head home.");
            Console.WriteLine("Where do you want to look for cows? The FIELD, FOREST, QUARRY, CITY, or MOUNTAIN?");

            Dictionary<string, Action> places = new Dictionary<string, Action>()
            {
                {"field", () => ship.AbductionEvent(10, 5) },
                {"forest", () => ship.AbductionEvent(6, 8) },
                {"city", () => ship.AbductionEvent(4, 3) },
                {"quarry", () => ship.AbductionEvent(4, 10) },
                {"mountain", () => ship.AbductionEvent(2, 15) },
            };

            string command = Console.ReadLine().ToLower();
            if (places.ContainsKey(command))
            {
                places[command].Invoke();
                Console.WriteLine("You've found "+ ship.NumberAbducted + " cows!");
            }
            else
            {
                Console.WriteLine("There's no place like that around here");
            }
            
            while (ship.EngagedInCombat)
            {
                CombatEvent(ship);
            }
        }

        private static void CombatEvent(UFO ship)
        {
            Console.WriteLine("Dang, they've brought a tank!");

            while (!ship.Destroyed && ship.EngagedInCombat)
            {
                Console.WriteLine("Will you use the LASERS or the CANNON ?");
                switch (Console.ReadLine().ToLower())
                {
                    case "cannon":
                        ship.Attack(3);
                        break;

                    case "lasers":
                        ship.Attack(1, 5);
                        Console.Beep();
                        break;

                    default:
                        Console.WriteLine("You don't have a weapon like that!");
                        continue;
                }

                if (ship.TankHealth > 0)
                {
                    ship.TakeDamage();
                    Console.WriteLine("The tank shot you back!");
                    if (ship.ShipHealth == 7) Console.WriteLine("You're losing your armor!");
                    if (ship.ShipHealth == 4) Console.WriteLine("The ship isn't looking good!");
                    if (ship.ShipHealth == 1) Console.WriteLine("One more hit and you're done for!");
                }
                else
                {
                    Console.WriteLine("You've destroyed the tank! Time to move on!");
                    ship.destroyHumans();
                }
            }
        }
    }
}
