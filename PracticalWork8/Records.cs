using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork8
{
    internal class Records
    {
        List<Results> list = new List<Results>();
        public void RecordsList(Results result)
        {
            if (File.Exists("C:\\Users\\Den\\Desktop\\Records.json"))
            {
                string Text = File.ReadAllText("C:\\Users\\Den\\Desktop\\Records.json");
                list = JsonConvert.DeserializeObject<List<Results>>(Text);
            }
            list.Add(result);
            string json = JsonConvert.SerializeObject(list);
            File.WriteAllText("C:\\Users\\Den\\Desktop\\Records.json", json);

            Console.WriteLine("Таблица рекордов:\n--------------");
            foreach (Results item in list)
            {
                Console.WriteLine(item.name + "    " + item.amountPerMin + " символов в минуту   " + item.amountPerSec + " символов в секунду");                
            }
            Console.WriteLine("Нажмите Enter для продолжения");
            Console.ReadLine();
        }
    }
}
