using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Results> list = new List<Results>();
            while (true)
            {
                Typing typing = new Typing();
                Results result = new Results();
                Records records = new Records();
                Console.Clear();
                Console.WriteLine("Введите имя для таблицы рекордов:");
                result.name = Console.ReadLine();
                Console.Clear();
                int position = typing.Start();
                result.amountPerMin = position;
                result.amountPerSec = (float)position / 60;
                Console.Clear();
                records.RecordsList(result);
            }
        }
    }
}
