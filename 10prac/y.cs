using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace _10prac
{
    internal static class y
    {
        public static ConsoleKeyInfo key = new ConsoleKeyInfo((char)ConsoleKey.A, ConsoleKey.A, false, false, false);
        public static T deserialize<T>(this string FileName)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = File.ReadAllText(desktop + "\\" + FileName);
            T workers = JsonConvert.DeserializeObject<T>(json);
            return workers;
        }
        public static List<Person> workers = y.deserialize<List<Person>>("Person.json");
        public static void serialize<T>( this T workers, string FileName)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = JsonConvert.SerializeObject(workers);
            File.WriteAllText(desktop + "\\" + FileName, json);
        }
    }
}
