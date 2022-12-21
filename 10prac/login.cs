using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10prac
{
    internal class login
    {
        private static int pos = 2;
        private static string password = "";
        public static string username = "";
        private static int allright = 0;

        public static void enter()
        {
            Console.SetCursorPosition(20, 0);
            Console.WriteLine("ДОБРО ПОЖАЛОВАТЬ В МАГАЗИН 'Я УБЬЮСЬ С ЭТИМИ ПРАКТИЧЕСКИМИ'");
            Console.WriteLine("_______________________________________________________________________________________________");
            Console.WriteLine("  Введите ваш логин: ");
            Console.WriteLine("  Введите ваш пароль: ");
            Console.WriteLine("  Войти");
            Console.SetCursorPosition(0, 0);
            while (allright != 1)
            {
                if (y.key.Key == ConsoleKey.Enter & pos == 2)
                {
                    username_change();

                }
                else if (y.key.Key == ConsoleKey.Enter & pos == 3)
                {
                    password_change();
                }
                Console.SetCursorPosition(0, pos);
                Console.WriteLine("->");
                y.key = Console.ReadKey();
                if (y.key.Key == ConsoleKey.UpArrow)
                    goup_login();
                else if (y.key.Key == ConsoleKey.DownArrow)
                    godown_login();
                if (pos == 4 && y.key.Key == ConsoleKey.Enter)
                    checker();
            }
        }
        private static void goup_login()
        {
            Console.SetCursorPosition(0, pos);
            Console.Write("  ");
            pos--;
            if (pos < 2)
                pos = 2;
        }
        private static void godown_login()
        {
            Console.SetCursorPosition(0, pos);
            Console.Write("  ");
            pos++;
            if (pos > 4)
                pos = 4;
        }
        public static void clear(string stroka, int cursorpos)
        {
            Console.SetCursorPosition(cursorpos - 1, pos);
            Console.Write(" ");
            cursorpos--;
        }
        private static void password_change()
        {
            int position_password = 22;
            while (true)
            {
                if (y.key.Key == ConsoleKey.UpArrow || y.key.Key == ConsoleKey.DownArrow)
                {
                    break;
                }
                if (y.key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Remove(password.Length - 1);
                    clear(password, position_password);
                    position_password--;
                }
                else if (y.key.Key != ConsoleKey.Enter || y.key.Key == ConsoleKey.UpArrow || y.key.Key == ConsoleKey.DownArrow)
                {
                    Console.SetCursorPosition(position_password, 3);
                    Console.Write("*");
                    position_password++;
                    password += y.key.KeyChar;
                }
                Console.SetCursorPosition(position_password, 3);
                y.key = Console.ReadKey();
            }
        }
        private static void username_change()
        {
            int position_username = 21;
            while (true)
            {
                if (y.key.Key == ConsoleKey.UpArrow || y.key.Key == ConsoleKey.DownArrow)
                {
                    break;
                }
                if (y.key.Key == ConsoleKey.Backspace && username.Length > 0)
                {
                    username = username.Remove(username.Length - 1);
                    clear(username, position_username);
                    position_username--;
                }
                else if (y.key.Key != ConsoleKey.Enter || y.key.Key == ConsoleKey.UpArrow || y.key.Key == ConsoleKey.DownArrow)
                {
                    position_username++;
                    username += y.key.KeyChar;
                }
                Console.SetCursorPosition(position_username, 2);
                y.key = Console.ReadKey();
            }
        }
        private static void checker()
        {
            foreach (var a in y.admin_panel_workers)
            {
                if (a.username == username && a.password == password)
                {
                    allright = 1;
                    Console.WriteLine("Вы успешно вошли в систему!");
                    break;
                }
                else
                {
                    username = "";
                    password = "";
                    Console.WriteLine("Вы ввели неверный логин или пароль, попробуйте заново");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.WriteLine("ДОБРО ПОЖАЛОВАТЬ В МАГАЗИН 'Я УБЬЮСЬ С ЭТИМИ ПРАКТИЧЕСКИМИ'");
                    Console.WriteLine("_______________________________________________________________________________________________");
                    Console.WriteLine("  Введите ваш логин: ");
                    Console.WriteLine("  Введите ваш пароль: ");
                    Console.WriteLine("  Войти");
                }
            }
        }
    }
}
