using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belopoly
{
    class Fault : Cell
    {
        public Fault(string fault) : base(fault) { }
        
        public void OnPrison(Player player)
        {
            Random cube = new Random();
            int time1 = cube.Next(1, 7);
            int time2 = cube.Next(1, 7);
            Console.WriteLine($"{player.Name} пытается сбежать: {time1}, {time2}");

            if (time1 == time2)
            {
                Console.WriteLine($"{player.Name}  сбегает");
            }
            else if (player.CountBonus(0) > 0)
            {
                player.UseBonus(0);
                Console.WriteLine($"Использована карта освобождения из цюрьмы: {player.Name} благополучно сбегает");
            }
            else if (player.HaveGold(200))
            {
                time1 = cube.Next(2);
                if (time1 == 1)
                {
                    Console.WriteLine($"{player.Name} платит 200 БР и благополучно сбегает");
                    player.MinusGold(200);

                }
                else
                {
                    Console.WriteLine($"{player.Name} не может сбежать: пропускает 3 хода");
                    player.NotFree(4);
                }
            }
            else
            {
                Console.WriteLine($"{player.Name} не может сбежать: пропускает 3 хода");
                player.NotFree(4);
            }
        }
    }
}
