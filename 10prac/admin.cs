using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _10prac
{
    internal class admin : ICrud
    {
        private static string search_string = "";
        private static int search_pos = 0;
        private static int pos = 4;
        private static int stolbec = 0;

        public void Admin_menu()
        {
            Console.SetCursorPosition((int)admin_enum.name, 4);
            while (y.key.Key != ConsoleKey.F10)
            {
                y.workers = y.deserialize<List<Person>>("Person.json");
                Console.Clear();
                head();
                Read();
                arrows();
                Console.SetCursorPosition(stolbec, pos);
                if (y.key.Key == ConsoleKey.F1)
                    Create();
                else if (y.key.Key == ConsoleKey.F3)
                    Update();
                else if (y.key.Key == ConsoleKey.Delete)
                    Delete();
                else if (y.key.Key == ConsoleKey.S)
                    search();
                Console.WriteLine("->");
                y.key = Console.ReadKey();

            }
        }
        private static void search()
        {
            search_string = changing_string(search_string, search_pos);
            show_search();
        }
        private static void show_search()
        {
            pos = 0;
            foreach (var a in y.workers)
            {
                if (search_string == a.id.ToString() || search_string == a.username || search_string == a.enum_job_title.ToString())
                {
                    Console.SetCursorPosition((int)admin_enum.name, pos);
                    Console.Write("  " + a.username);
                    Console.SetCursorPosition((int)admin_enum.password, pos);
                    Console.Write("  " + a.password);
                    Console.SetCursorPosition((int)admin_enum.id, pos);
                    Console.Write("  " + a.id);
                    Console.SetCursorPosition((int)admin_enum.job_title, pos);
                    Console.Write("  " + a.enum_job_title);
                    pos++;
                }
            }
        }

        public void Create()
        {
            try
            {
                y.key = new ConsoleKeyInfo((char)ConsoleKey.A, ConsoleKey.A, false, false, false);
                string newname = "";
                string newpassword = "";
                int newid = 0;
                int newjobtitle = 0;
                Console.Clear();
                head();
                while (y.key.Key != ConsoleKey.F1)
                {
                    if (y.key.Key == ConsoleKey.RightArrow)
                    {
                        if (stolbec == (int)admin_enum.name)
                            stolbec = (int)admin_enum.password;
                        if (stolbec == (int)admin_enum.password)
                            stolbec = (int)admin_enum.id;
                        if (stolbec == (int)admin_enum.id)
                            stolbec = (int)admin_enum.job_title;
                    }
                    if (y.key.Key == ConsoleKey.LeftArrow)
                    {
                        if (stolbec == (int)admin_enum.name)
                            stolbec = (int)admin_enum.name;
                        if (stolbec == (int)admin_enum.password)
                            stolbec = (int)admin_enum.name;
                        if (stolbec == (int)admin_enum.id)
                            stolbec = (int)admin_enum.password;
                        if (stolbec == (int)admin_enum.job_title)
                            stolbec = (int)admin_enum.id;
                    }
                    if (stolbec == (int)admin_enum.name)
                        newname = changing_string(newname, 0);
                    else if (stolbec == (int)admin_enum.password)
                        newpassword = changing_string(newpassword, 0);
                    else if (stolbec == (int)admin_enum.id)
                        newid = Convert.ToInt32(changing_string(newid.ToString(), 0));
                    else if (stolbec == (int)admin_enum.job_title)
                        newjobtitle = Convert.ToInt32(changing_string(newjobtitle.ToString(), 0));
                    Person newperson = new Person(newname, newpassword, newid, newjobtitle);
                    y.workers.Add(newperson);
                }
                y.serialize(y.workers, "Person.json");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Видимо, вы допустили ошибку: " + ex + " Попробуйте заново");
                return;
            }
        }

        public void Read()
        {
            foreach (var a in y.workers)
            {
                Console.SetCursorPosition((int)admin_enum.name, pos);
                Console.Write("  " + a.username);
                Console.SetCursorPosition((int)admin_enum.password, pos);
                Console.Write("  " + a.password);
                Console.SetCursorPosition((int)admin_enum.id, pos);
                Console.Write("  " + a.id);
                Console.SetCursorPosition((int)admin_enum.job_title, pos);
                Console.Write("  " + a.enum_job_title);
                pos++;
            }
            pos = 4;
            Console.SetCursorPosition((int)admin_enum.name, 4);
        }

        public void Update() /* F3*/
        {
            y.key = new ConsoleKeyInfo((char)ConsoleKey.A, ConsoleKey.A, false, false, false);
            string change = "";
            int change_pos = 0;
            if (stolbec == (int)admin_enum.name)
            {
                change = y.workers[pos - 4].username;
                change = changing_string(change, change_pos);
                y.workers[pos - 4].username = change;
            }
            else if (stolbec == (int)admin_enum.password)
            {
                change = Convert.ToString(y.workers[pos - 4].password);
                change = changing_string(change, change_pos);
                y.workers[pos - 4].password = change;
            }
            else if (stolbec == (int)admin_enum.id)
            {
                change = Convert.ToString(y.workers[pos - 4].id);
                change = changing_string(change, change_pos);
                y.workers[pos - 4].id = Convert.ToInt32(change);
            }
            else if (stolbec == (int)admin_enum.job_title)
            {
                change = Convert.ToString(y.workers[pos - 4].enum_job_title);
                change = changing_string(change, change_pos);
                y.workers[pos - 4].enum_job_title = Convert.ToInt32(change);
            }
            y.serialize(y.workers, "Person.json");
        }

        public void Delete() /* delete */
        {
            y.workers.Remove(y.workers[pos - 4]);
            Console.Clear();
            y.serialize(y.workers, "Person.json");
        }
        private static void head()
        {
            Console.SetCursorPosition(20, 0);
            Console.WriteLine("МЕНЮ АДМИНИСТРАТОРА " + login.username);
            Console.WriteLine("________________________________________________________");
            Console.SetCursorPosition((int)admin_enum.name, 2);
            Console.Write("Имя пользователя");
            Console.SetCursorPosition((int)admin_enum.password, 2);
            Console.Write("Пароль");
            Console.SetCursorPosition((int)admin_enum.id, 2);
            Console.Write("ID");
            Console.SetCursorPosition((int)admin_enum.job_title, 2);
            Console.Write("Должность");
        }
        private static void arrows()
        {
            switch (y.key.Key)
            {
                case ConsoleKey.DownArrow:
                    {
                        Console.Write("  ");
                        pos++;
                        if (pos >= (y.workers.Count() + 3))
                            pos = (y.workers.Count() + 3);
                        break;
                    }
                case ConsoleKey.UpArrow:
                    {
                        Console.Write("  ");
                        pos--;
                        if (pos < 4)
                            pos = 4;
                        break;
                    }
                case ConsoleKey.RightArrow:
                    {
                        Console.Write("  ");
                        if (stolbec == (int)admin_enum.name)
                            stolbec = (int)admin_enum.password;
                        else if (stolbec == (int)admin_enum.password)
                            stolbec = (int)admin_enum.id;
                        else if (stolbec == (int)admin_enum.id)
                            stolbec = (int)admin_enum.job_title;
                        break;
                    }
                case ConsoleKey.LeftArrow:
                    {
                        Console.Write("  ");
                        if (stolbec == (int)admin_enum.password)
                            stolbec = (int)admin_enum.name;
                        else if (stolbec == (int)admin_enum.id)
                            stolbec = (int)admin_enum.password;
                        else if (stolbec == (int)admin_enum.job_title)
                            stolbec = (int)admin_enum.id;
                        break;
                    }
            }

        }
        private static string changing_string(string change_string, int change_string_pos)
        {
            y.key = new ConsoleKeyInfo((char)ConsoleKey.A, ConsoleKey.A, false, false, false);
            while (y.key.Key != ConsoleKey.Enter)
            {
                if (y.key.Key == ConsoleKey.UpArrow || y.key.Key == ConsoleKey.DownArrow)
                {
                    break;
                }
                if (y.key.Key == ConsoleKey.Backspace && change_string.Length > 0)
                {
                    change_string = change_string.Remove(change_string.Length - 1);
                    login.clear(change_string, change_string_pos);
                    change_string_pos--;
                }
                else if (y.key.Key != ConsoleKey.Enter || y.key.Key == ConsoleKey.UpArrow || y.key.Key == ConsoleKey.DownArrow)
                {
                    change_string_pos++;
                    change_string += y.key.KeyChar;
                }
                y.key = Console.ReadKey();
            }
            return change_string;
        }
    }
}
