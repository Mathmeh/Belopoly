using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belopoly
{
    class Board //только создаётся игровое поле
    {
        public Cell[] array = new Cell[18];
        public Board() 
        {
            //трыктож
            array[1] = new Street(1000, "Cвитанак", "Трыкатаж");
            array[2] = new Street(500, "Пинский трикотож", "Трыкатаж");
            array[3] = new Street(1500, "Знамя индустриализации", "Трыкатаж");

            //тяжпром
            array[6] = new Street(1500, "МТЗ", "Тяжпром");
            array[7] = new Street(1000, "БелАЗ", "Тяжпром");
            array[8] = new Street(500, "МАЗ", "Тяжпром");

            //химпром
            array[10] = new Street(800, "БеларусьКалий", "Химпром");
            array[11] = new Street(1000, "БелНафта", "Химпром");
            array[12] = new Street(500, "МозырьСоль", "Химпром");

            //Картофелеводческие хозяйства
            array[15] = new Street(1000, "КФХ «Диана»", "Картофелеводческие хозяйства");
            array[16] = new Street(800, "ФХ «Григорий и сыновья»", "Картофелеводческие хозяйства");
            array[17] = new Street(500, "ООО «БелТруфСмак»", "Картофелеводческие хозяйства");

            //cпецклетки
            array[0] = new Cell("СТАРТ");

            array[4] = new Chance("ШАНС");
            array[5] = new Fault("Снова цюрма!");
            
            array[9] = new Fault("Цюрма");

            array[13] = new Chance("ШАНС");
            array[14] = new Fault("Опять цюрма");
        }

       
        

        

    }
}
