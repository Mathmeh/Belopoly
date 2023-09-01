using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belopoly
{
    class Chance : Cell
    {
        
        public Chance(string bonus) : base(bonus) { }
        
        public void OnChance(Player player)
        {
            Random cube = new Random();
            int time = cube.Next(4);
            Console.WriteLine($"{player.Name} может получить 600 БР");
            if (time == 1) //получить 600 БР
            {
                player.PlusGold(600);
            }
            else if (time == 2||time == 3) //отобрать 300 БР у урага
            {
                Console.WriteLine($"{player.Name} может отобрать 300 БР у урага");
                player.PlusGold(300);
                player.Next.MinusGold(300);
            }
            
            else
            {
                player.AddBonus(0);
            }
        }
    }
}
