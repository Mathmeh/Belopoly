using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Belopoly
{
    class Program 
    {
        static void OutputToScreen(Player pl1, Player pl2)
        {
            Console.Write("имя");
            Console.SetCursorPosition(35, 0);
            Console.Write(pl1.Name);
            Console.SetCursorPosition(pl1.Name.Length + 50, 0);
            Console.WriteLine(pl2.Name);

            Console.Write("БР");
            Console.SetCursorPosition(35, 1);
            Console.Write(pl1.Gold);
            Console.SetCursorPosition(pl1.Name.Length + 50, 1);
            Console.WriteLine(pl2.Gold);

            Console.Write("карт сбежать из тюрьмы");
            Console.SetCursorPosition(35, 2);
            Console.Write(pl1.CountBonus(0));
            Console.SetCursorPosition(pl1.Name.Length + 50, 2);
            Console.WriteLine(pl2.CountBonus(0));

            //Console.Write("не заплатить сопернику за пребывание на его территории");
            //Console.SetCursorPosition(75, 3);
            //Console.Write(cat1.CountBonus(2));
            //Console.SetCursorPosition(cat1.Name.Length + 80, 3);
            //Console.WriteLine(cat2.CountBonus(2));

            ////Console.Write("заставить соперника заплатить двойную цену за нахождение на территории");
            ////Console.SetCursorPosition(75, 4);
            ////Console.Write(cat1.CountBonus(3));
            ////Console.SetCursorPosition(cat1.Name.Length + 80, 4);
            ////Console.WriteLine(cat2.CountBonus(3));

            //Console.Write("шагов пропустить");
            //Console.SetCursorPosition(75, 5);
            //Console.Write(cat1.Skip);
            //Console.SetCursorPosition(cat1.Name.Length + 80, 5);
            //Console.WriteLine(cat2.Skip);

            Console.SetCursorPosition((pl2.Name.Length + 30) / 2, 7);
        }
            
        static void Main(string[] args)
        {
            Board board = new Board();
            Random cube = new Random();

            Player player1 = new Player("Рыгор");           
            Player player2 = new Player("Аляксандр");

            //для проверки декораторов
            player1.Buy((Street)board.array[1]);
            player1.Buy((Street)board.array[2]);
            player1.Buy((Street)board.array[3]);

            //player1.Buy((Street)board.array[10]);
            //player1.Buy((Street)board.array[11]);
            //player1.Buy((Street)board.array[12]);

            //player1.Buy((Street)board.array[6]);
            //player1.Buy((Street)board.array[7]);
            //player1.Buy((Street)board.array[8]);

            //player1.Buy((Street)board.array[15]);
            //player1.Buy((Street)board.array[16]);
            //player1.Buy((Street)board.array[17]);

            //player1.PlusGold(20000);
            //player2.PlusGold(10000);


            player1.Next = player2;
            player2.Next = player1;
            Player current = player1;

            int index;
            while (player1.HaveGold(0) && player2.HaveGold(0))
            {
                OutputToScreen(player1, player2);
                Console.WriteLine("Ходит " + current.Name);

                #region движение по доске
                int move = cube.Next(1,7);
                current.MovePosition(move);

                index = current.Position;
                Cell somecell = board.array[index];

                //старт
                if (index == 0)
                {
                    Console.WriteLine($"{current.Name} приходит в  {somecell.Name}");
                }
                //шанс
                else if (index == 4 || index == 13)
                {
                    Console.WriteLine($"{current.Name} получает {somecell.Name}");
                    ((Chance)somecell).OnChance(current);
                }
                //тюрьма
                else if (index == 5 || index == 14||index == 9)
                {
                    Console.WriteLine($"{current.Name} попадает у цюрьму!: {somecell.Name}");
                    ((Fault)somecell).OnPrison(current);
                }
                
                //улицы
                else
                {
                    Console.WriteLine($"{current.Name} попадает на {somecell.Name}");

                    if (((StreetAbstract)somecell).Owner != null && ((StreetAbstract)somecell).Owner != current)
                    {
                        Console.WriteLine(((StreetAbstract)somecell).Name + " принадлежит " + ((StreetAbstract)somecell).Owner.Name);
                            Console.WriteLine($"{current.Name} платит {current.Next.Name} {((StreetAbstract)somecell).GetRent()}");
                            current.MinusGold(((StreetAbstract)somecell).GetRent());
                            current.Next.PlusGold(((StreetAbstract)somecell).GetRent());
                                               
                    }
                    //покупка
                    else if (((StreetAbstract)board.array[index]).Owner == null)
                    {
                        Console.WriteLine($"{((StreetAbstract)somecell).Name} никому не принадлежит");
                        if (current.HaveGold(((StreetAbstract)somecell).Cost))
                        {
                            Console.WriteLine($"{current.Name} покупает {((StreetAbstract)somecell).Name } " +
                                $"за {((StreetAbstract)somecell).Cost} БР");
                            current.Buy((StreetAbstract)somecell);
                        }
                        else
                        {
                            Console.WriteLine($"{current.Name} имеет недостаточно средств " +
                                $"на покупку {((StreetAbstract)somecell).Name} за {((StreetAbstract)somecell).Cost} БР");
                        }                        
                    }
                    //декоратор
                    else
                    {
                        Console.WriteLine(((StreetAbstract)somecell).Name + " принадлежит " + ((StreetAbstract)somecell).Owner.Name);
                        if (current.CanUpgrade(((StreetAbstract)somecell)))
                        {
                            StreetAbstract ra = new Street(((StreetAbstract)somecell).Cost, 
                                ((StreetAbstract)somecell).Name, ((StreetAbstract)somecell).Street); 
                            if (((StreetAbstract)somecell).Level == 0)
                            {
                                ra = new FirstUpgrade(((StreetAbstract)somecell));
                            }
                            else if (((StreetAbstract)somecell).Level == 1)
                            {
                                ra = new SecondUpgrade(((StreetAbstract)somecell));
                            }
                            else if (((StreetAbstract)somecell).Level == 2)
                            {
                                ra = new ThirdUpgrade(((StreetAbstract)somecell));
                            }
                            else if (((StreetAbstract)somecell).Level == 3)
                            {
                                ra = new Hotel(((StreetAbstract)somecell));
                            }
                                
                            Console.WriteLine(current.Name + "улучшает "
                                + ((StreetAbstract)somecell).Name + " до " + ra.Name);
                            current.Property.Remove((StreetAbstract)somecell);
                            current.Property.Add(ra);
                            board.array[index] = ra;

                        }

                    }
                }
                #endregion


                #region проверка смены ходящего

                if (current.Next.Free)
                {
                    current = current.Next;
                }

                if (!player1.Free)
                {
                    player1.MinusCounter();
                }
                if (!player2.Free)
                {
                    player2.MinusCounter();
                }
                #endregion

                Thread.Sleep(1000);
                Console.Clear();

            }

            Console.WriteLine("Игра окончена!");
            if (player1.HaveGold(0))
            {                
                Console.WriteLine($"{player1.Name} выигрывает!");
            }
            else
            {
                Console.WriteLine($"{player2.Name} выигрывает!");
            }
           
            Console.ReadKey();


        }
    }
}
