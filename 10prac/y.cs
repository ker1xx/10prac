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
        public static T admin_deserialize<T>(this string FileName)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = File.ReadAllText(desktop + "\\" + FileName);
            T workers = JsonConvert.DeserializeObject<T>(json);
            return workers;
        }
        public static List<admin_Person> admin_panel_workers = y.admin_deserialize<List<admin_Person>>("admin_Person.json");
        public static void admin_serialize<T>( this T workers, string FileName)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = JsonConvert.SerializeObject(workers);
            File.WriteAllText(desktop + "\\" + FileName, json);
        }

        /* PERSON MANAGER//////////////////////////////////////////////////////////////////*/

        public static T person_manager_deserialize<T>(this string FileName)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = File.ReadAllText(desktop + "\\" + FileName);
            T workers = JsonConvert.DeserializeObject<T>(json);
            return workers;
        }
        public static List<Person_manager_Person> person_manager_panel_workers = y.person_manager_deserialize<List<Person_manager_Person>>("person_manager_Person.json");
        public static void person_manager_serialize<T>(this T workers, string FileName)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = JsonConvert.SerializeObject(workers);
            File.WriteAllText(desktop + "\\" + FileName, json);
        }

        /* ID ////////////////////////////////////////// */
        public static T ID_deserialize<T>(this string FileName)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = File.ReadAllText(desktop + "\\" + FileName);
            T workers = JsonConvert.DeserializeObject<T>(json);
            return workers;
        }
        public static List<ID> ID_list = y.ID_deserialize<List<ID>>("ID.json");
        public static void ID_serialize<T>(this T workers, string FileName)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = JsonConvert.SerializeObject(workers);
            File.WriteAllText(desktop + "\\" + FileName, json);
        }
    }
}
