﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belopoly
{
    class Player 
    {        
        private int[] Bonus = new int[6];
        public List<StreetAbstract> Property = new List<StreetAbstract>();
        public int Gold { get; set; }
        public string Name { get; set; }
        public int Position { get; set; }
        public int Skip { get; set; }
        public bool Free { get; set; }
        public Player Next { get; set; }
        public int CountBonus(int index) => Bonus[index];

        public Player(string name) 
        { 
            Name = name;
            Gold = 5000; 
            Position = 0; 
            Free = true; 
            Skip = 0;
            Next = null;
        }
        
        public void Buy(StreetAbstract room)
        {
            Property.Add(room);
            room.Owner = this;
            MinusGold(room.Cost);
        }

        public bool CanUpgrade(StreetAbstract street)
        {
            int count = 0;
            foreach (var i in Property)
            {
                if (i.StreetGroup == street.StreetGroup)
                {
                    count++;
                    if (street.Level > i.Level)
                    {
                        return false;
                    }
                }
            }
            if (count == 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HaveGold(int summa)
        {
            if (this.Gold < summa)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void PlusGold(int summa)
        {
            Gold += summa;
        }

        public void MinusGold(int summa)
        {
            Gold -= summa;
        }

        public void MinusCounter()
        {
            Skip--;
            if (Skip == 0)
            {
                Free = true;
            }
        }

        public void NotFree(int summa) //если два игрока в тюрьме, то первого выпускаем
        {
            Skip = summa;
            Free = false;
            Next.Skip = 0;
            Next.Free = true;
        }

        public void MovePosition(int move)
        {
            if (Position + move <= 17)
            { 
                Position += move;
            }
            else
            {
                Position += move - 18;
                PlusGold(400);
            }           
        }

        public void AddBonus(int index)
        {
            Bonus[index]++;
        }

        public void UseBonus(int index)
        {
            Bonus[index]--;
        }
    }
}
