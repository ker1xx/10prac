using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _10prac
{
    internal class person_manager : admin
    {
        private static string search_string = "";
        private static int search_pos = 0;
        private static int pos = 4;
        private static int stolbec = 0;
        public override void Create()
        {
            try
            {
                pos = 4;
                stolbec = (int)admin_enum.name;
                y.key = new ConsoleKeyInfo((char)ConsoleKey.A, ConsoleKey.A, false, false, false);
                string newname = "";
                string newsurname = "";
                string newlastname = "";
                DateTime newbirthday = DateTime.Now;
                int newpassport = 0;
                int newjobtitle = 0;
                int newsalary = 0;
                int newname_length = 0;
                int newid = 0;
                int newsurname_length = 0;
                int newlastname_length = 0;
                int newbirthday_length = 0;
                int newpassport_length = 0;
                int newjobtitle_length = 0;
                int newsalary_length = 0;
                int newid_length = 0;
                Console.Clear();
                Person_manager_Person newperson_for_person_manager = new Person_manager_Person(newname, newsurname, newlastname, newbirthday, newpassport, newjobtitle, newsalary,newid);
                head();
                Console.SetCursorPosition(stolbec, pos);
                Console.Write("->");
                while (y.key.Key != ConsoleKey.S)
                {
                    Console.SetCursorPosition(70, 10);
                    Console.WriteLine("Для сохранения нажмите S");
                    Console.SetCursorPosition(stolbec, pos);
                    Console.Write("  ");
                    switch (y.key.Key)
                    {
                        case ConsoleKey.RightArrow:
                            {
                                if (stolbec == (int)person_manager_enum.job_title)
                                    stolbec = (int)person_manager_enum.salary;
                                else if (stolbec == (int)person_manager_enum.passport)
                                    stolbec = (int)person_manager_enum.job_title;
                                else if (stolbec == (int)person_manager_enum.birthday)
                                    stolbec = (int)person_manager_enum.passport;
                                else if (stolbec == (int)person_manager_enum.lastname)
                                    stolbec = (int)person_manager_enum.birthday;
                                else if (stolbec == (int)person_manager_enum.surname)
                                    stolbec = (int)person_manager_enum.lastname;
                                else if (stolbec == (int)person_manager_enum.name)
                                    stolbec = (int)person_manager_enum.surname;
                                break;
                            }
                        case ConsoleKey.LeftArrow:
                            {
                                if (stolbec == (int)person_manager_enum.surname)
                                    stolbec = (int)person_manager_enum.name;
                                else if (stolbec == (int)person_manager_enum.lastname)
                                    stolbec = (int)person_manager_enum.surname;
                                else if (stolbec == (int)person_manager_enum.birthday)
                                    stolbec = (int)person_manager_enum.lastname;
                                else if (stolbec == (int)person_manager_enum.passport)
                                    stolbec = (int)person_manager_enum.birthday;
                                else if (stolbec == (int)person_manager_enum.job_title)
                                    stolbec = (int)person_manager_enum.passport;
                                else if (stolbec == (int)person_manager_enum.salary)
                                    stolbec = (int)person_manager_enum.job_title;
                                break;
                            }
                    }


                    Console.SetCursorPosition(stolbec, pos);
                    Console.Write("->");
                    Console.SetCursorPosition(stolbec + 2, pos);
                    if (stolbec == (int)person_manager_enum.name)
                        newname = changing_string(newname, newname_length);
                    else if (stolbec == (int)person_manager_enum.surname)
                        newsurname = changing_string(newsurname, newsurname_length);
                    else if (stolbec == (int)person_manager_enum.lastname)
                        newlastname = changing_string(newlastname, newlastname_length);
                    else if (stolbec == (int)person_manager_enum.birthday)
                        newbirthday = Convert.ToDateTime(changing_string(newbirthday.ToString(), newbirthday_length));
                    else if (stolbec == (int)person_manager_enum.passport)
                        newpassport = Convert.ToInt32(changing_string(newpassport.ToString(), newpassport_length));
                    else if (stolbec == (int)person_manager_enum.job_title)
                        newjobtitle = Convert.ToInt32(changing_string(newjobtitle.ToString(), newjobtitle_length));
                    else if (stolbec == (int)person_manager_enum.salary)
                        newsalary = Convert.ToInt32(changing_string(newsalary.ToString(), newsalary_length));
                    else if (stolbec == (int)person_manager_enum.id)
                        newid = Convert.ToInt32(changing_string(newid.ToString(), newid_length));
                    y.key = Console.ReadKey();
                }
                y.person_manager_panel_workers.Add(newperson_for_person_manager);
                y.person_manager_serialize(y.admin_panel_workers, "person_manager_Person.json");
            }
            catch (Exception)
            {
                Console.WriteLine("Видимо, вы допустили ошибку. Попробуйте заново");
            }
        }
        public override void Read()
        {
            pos = 4;
            foreach (var a in y.person_manager_panel_workers)
            {
                Console.SetCursorPosition((int)person_manager_enum.name, pos);
                Console.Write("  " + a.name);
                Console.SetCursorPosition((int)person_manager_enum.surname, pos);
                Console.Write("  " + a.surname);
                Console.SetCursorPosition((int)person_manager_enum.lastname, pos);
                Console.Write("  " + a.lastname);
                Console.SetCursorPosition((int)person_manager_enum.birthday, pos);
                Console.Write("  " + a.birthday);
                Console.SetCursorPosition((int)person_manager_enum.passport, pos);
                Console.Write("  " + a.passport);
                Console.SetCursorPosition((int)person_manager_enum.job_title, pos);
                Console.Write("  " + a.enum_job_title);
                Console.SetCursorPosition((int)person_manager_enum.salary, pos);
                Console.Write("  " + a.salary);
                Console.SetCursorPosition((int)person_manager_enum.id, pos);
                Console.Write("  " + a.idi);
                pos++;
            }
            pos = 4;
            Console.SetCursorPosition((int)person_manager_enum.name, 4);
        }
        public override void Update()
        {
            y.key = new ConsoleKeyInfo((char)ConsoleKey.A, ConsoleKey.A, false, false, false);
            string change = "";
            int change_pos = 0;
            if (stolbec == (int)person_manager_enum.name)
            {
                try
                {
                    change = y.person_manager_panel_workers[pos - 4].name;
                    change_pos = change.Length + 1;
                    Console.SetCursorPosition(change.Length + 1, pos);
                    change = changing_string(change, change_pos);
                    y.person_manager_panel_workers[pos - 4].name = change;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            else if (stolbec == (int)person_manager_enum.surname)
            {
                try
                {
                    change = y.person_manager_panel_workers[pos - 4].surname;
                    Console.SetCursorPosition(change.Length + 2 + (int)person_manager_enum.surname, pos);
                    change_pos = change.Length + 1;
                    change = changing_string(change, change_pos);
                    y.person_manager_panel_workers[pos - 4].surname = change;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            else if (stolbec == (int)person_manager_enum.lastname)
            {
                try
                {
                    change = y.person_manager_panel_workers[pos - 4].lastname;
                    Console.SetCursorPosition(change.Length + 2 + (int)person_manager_enum.lastname, pos);
                    change_pos = change.Length + 1;
                    change = changing_string(change, change_pos);
                    y.person_manager_panel_workers[pos - 4].lastname = change;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            else if (stolbec == (int)person_manager_enum.birthday)
            {
                try
                {
                    change = Convert.ToString(y.person_manager_panel_workers[pos - 4].birthday);
                    Console.SetCursorPosition(change.Length + 2 + (int)person_manager_enum.birthday, pos);
                    change_pos = change.Length + 1;
                    change = changing_string(change, change_pos);
                    y.person_manager_panel_workers[pos - 4].birthday = Convert.ToDateTime(change);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            else if (stolbec == (int)person_manager_enum.passport)
            {
                try
                {
                    change = Convert.ToString(y.person_manager_panel_workers[pos - 4].passport);
                    Console.SetCursorPosition(change.Length + 2 + (int)person_manager_enum.passport, pos);
                    change_pos = change.Length + 1;
                    change = changing_string(change, change_pos);
                    y.person_manager_panel_workers[pos - 4].passport = Convert.ToInt32(change);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            else if (stolbec == (int)person_manager_enum.job_title)
            {
                try
                {
                    change = Convert.ToString(y.person_manager_panel_workers[pos - 4].enum_job_title);
                    Console.SetCursorPosition(change.Length + 2 + (int)person_manager_enum.job_title, pos);
                    change_pos = change.Length + 1;
                    change = changing_string(change, change_pos);
                    y.person_manager_panel_workers[pos - 4].enum_job_title = Convert.ToInt32(change);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            
            else if (stolbec == (int)person_manager_enum.id)
            {
                try
                {
                    change = Convert.ToString(y.person_manager_panel_workers[pos - 4].idi);
                    Console.SetCursorPosition(change.Length + 1 + (int)person_manager_enum.id, pos);
                    change_pos = change.Length + 1;
                    change = changing_string(change, change_pos);
                    y.person_manager_panel_workers[pos - 4].idi = Convert.ToInt32(change);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            else if (stolbec == (int)person_manager_enum.salary)
            {
                try
                {
                    change = Convert.ToString(y.person_manager_panel_workers[pos - 4].salary);
                    Console.SetCursorPosition(change.Length + 1 + (int)person_manager_enum.salary, pos);
                    change_pos = change.Length + 1;
                    change = changing_string(change, change_pos);
                    y.person_manager_panel_workers[pos - 4].salary = Convert.ToInt32(change);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            y.person_manager_serialize(y.person_manager_panel_workers, "person_manager_Person.json");
        }
        public override void Delete()
        {
            y.person_manager_panel_workers.Remove(y.person_manager_panel_workers[pos - 4]);
            Console.Clear();
            y.admin_serialize(y.person_manager_panel_workers, "person_manager_Person.json");
        }
        private static void search()
        {
            Console.SetCursorPosition(70, 10);
            Console.Clear();
            head();
            Console.SetCursorPosition(70, 8);
            Console.WriteLine("Для выхода нажмите Escape");
            Console.SetCursorPosition(70, 10);
            search_string = admin.changing_string(search_string, search_pos);

            while (y.key.Key != ConsoleKey.Escape)
            {
                show_search();
                y.key = Console.ReadKey();
            }
        }
        private static void show_search()
        {
            Console.Clear();
            head();
            foreach (var a in y.person_manager_panel_workers)
            {
                if (search_string == a.idi.ToString() || search_string == a.surname || search_string == a.enum_job_title.ToString() || search_string == a.birthday.ToString()
                    || search_string == a.passport.ToString() || search_string == a.salary.ToString())
                {
                    Console.SetCursorPosition((int)person_manager_enum.name, pos);
                    Console.Write("  " + a.name);
                    Console.SetCursorPosition((int)person_manager_enum.surname, pos);
                    Console.Write("  " + a.surname);
                    Console.SetCursorPosition((int)person_manager_enum.lastname, pos);
                    Console.Write("  " + a.lastname);
                    Console.SetCursorPosition((int)person_manager_enum.birthday, pos);
                    Console.Write("  " + a.birthday);
                    Console.SetCursorPosition((int)person_manager_enum.passport, pos);
                    Console.Write("  " + a.passport);
                    Console.SetCursorPosition((int)person_manager_enum.job_title, pos);
                    Console.Write("  " + a.enum_job_title);
                    Console.SetCursorPosition((int)person_manager_enum.salary, pos);
                    Console.Write("  " + a.salary);

                    Console.SetCursorPosition((int)person_manager_enum.id, pos);
                    Console.Write("  " + a.idi);
                    pos++;
                }
            }
        }
        private static void head()
        {
            Console.SetCursorPosition(20, 0);
            Console.WriteLine("МЕНЮ МЕНЕДЖЕРА ПЕРСОНАЛА " + login.username);
            Console.WriteLine("______________________________________________________________________________________________________________________");
            Console.SetCursorPosition((int)person_manager_enum.name, 2);
            Console.Write("Имя");
            Console.SetCursorPosition((int)person_manager_enum.surname, 2);
            Console.Write("Фамилия");
            Console.SetCursorPosition((int)person_manager_enum.lastname, 2);
            Console.Write("Отчество");
            Console.SetCursorPosition((int)person_manager_enum.birthday, 2);
            Console.Write("Дата рождения");
            Console.SetCursorPosition((int)person_manager_enum.passport, pos);
            Console.Write("Паспорт");
            Console.SetCursorPosition((int)person_manager_enum.job_title, pos);
            Console.Write("Должность");
            Console.SetCursorPosition((int)person_manager_enum.salary, pos);
            Console.Write("Зарплата");
            Console.SetCursorPosition((int)person_manager_enum.nickname, pos);
            Console.Write("Имя аккаунта");
            Console.SetCursorPosition((int)person_manager_enum.id, pos);
            Console.Write("ID");
            int i = 0;
            while (i != y.person_manager_panel_workers.Count() + 10)
            {
                Console.SetCursorPosition(130, i);
                Console.WriteLine("|");
                i++;
            }
        }
        private static void subhead()
        {
            Console.SetCursorPosition(70, 2);
            Console.WriteLine("Для создания нажмите F1");
            Console.SetCursorPosition(70, 3);
            Console.WriteLine("Для изменения нажмите F3");
            Console.SetCursorPosition(70, 4);
            Console.WriteLine("Для удаления нажмите Delete");
            Console.SetCursorPosition(70, 5);
            Console.WriteLine("Для поиска нажмите F2");
            Console.SetCursorPosition(70, 6);
            Console.WriteLine("При изменении, вводе или добавлении вам потребуется нажать Enter,");
            Console.SetCursorPosition(70, 7);
            Console.WriteLine("чтобы подтвердить ввод");
            Console.SetCursorPosition(70, 9);
            Console.WriteLine("Поиск: ");
        }
    }
}
