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
        /* ADMIN////////////////////////////////////////////////////////////////////*/
        public static T admin_deserialize<T>( string FileName)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = "";
            if (File.Exists(desktop + "\\" + FileName))
                json = File.ReadAllText(desktop + "\\" + FileName);
            else
            {
                File.Create(desktop + "\\" + FileName);
                json = File.ReadAllText(desktop + "\\" + FileName);
            }
            T workers = JsonConvert.DeserializeObject<T>(json);
            return workers;
        }
        public static List<admin_Person> admin_panel_workers = y.admin_deserialize<List<admin_Person>>("admin_Person.json");
        public static void admin_serialize<T>( T workers, string FileName)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = JsonConvert.SerializeObject(workers);
            if (File.Exists(desktop + "\\" + FileName))
                File.WriteAllText(desktop + "\\" + FileName, json);
            else
            {
                File.Create(desktop + "\\" + FileName);
                File.WriteAllText(desktop + "\\" + FileName, json);
            }
        }
    }
}
