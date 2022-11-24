using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PracticalWork8
{
    internal class Typing
    {
        private string[] texts =
        {"2300 лет назад в малоазийском греческом городе Галикарнас был царь Мавсол. Перед смертью он решил построить себе храм-усыпальницу. Для этого царь нанял лучших архитекторов и скульпторов. Архитекторы Пифей и Сатир предложили наиболее оригенальное решение. По имени Мавсола его усыпальница и была названа мавзолеем. Галикарнасские археологические находки можно увидеть в Британском музее в Лондоне.",
            "В начале третьего века нашей эры на маленьком острове Фарос около Александрии был построен самый высокий маяк в мире высотой 120 метров. Его пректировали греческие учёные, а строителем был архитектор Сострат. Сострат начал с того, что построил огромный мол - морскую дамбу, которая соединяла Александрию с островом. По этой дамбе подвозили строительный материал. И через 5 лет маяк удалось построить."
                
        };
        string textSelected;
        Random random = new Random();
        ConsoleKeyInfo key;
        int position;
        Thread thread = new Thread(() =>
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Restart();
            while (true)
            {
                Console.SetCursorPosition(0, 10);
                Console.WriteLine(stopwatch.ElapsedMilliseconds / 1000 + "/60");
                Thread.Sleep(1000);
            }
        });

        public int Start()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            textSelected = texts[random.Next(texts.Length)];
            Console.WriteLine(textSelected + "\n--------------------\nКогда будете готовы нажмите Enter");
            Console.ReadLine();
            thread.Start();
            while (thread.IsAlive && stopwatch.ElapsedMilliseconds < 60000)
            {
                Console.SetCursorPosition(0, 11);
                Console.Write("        ");
                Console.SetCursorPosition(0, 11);
                key = Console.ReadKey();
                if (textSelected[position] == key.KeyChar)
                {
                    Console.SetCursorPosition(position - (position/120)*120, position/120);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(textSelected[position]);
                    Console.ResetColor();
                    position++;

                }
            }
            thread.Suspend();
            Console.SetCursorPosition(0, 10);
            Console.WriteLine("Stop");
            Thread.Sleep(3000);
            return position;
        }
    }
}
