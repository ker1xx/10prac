using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _10prac
{
    internal class login
    {
        private int pos = 2;
        public void enter()
        {
            string password = "";
            string login = "";
            int i = 2;
            Console.WriteLine("ДОБРО ПОЖАЛОВАТЬ В МАГАЗИН 'Я УБЬЮСЬ С ЭТИМИ ПРАКТИЧЕСКИМИ'");
            Console.WriteLine("_______________________________________________________________________________________________");
            Console.WriteLine("  Введите ваш логин: ");
            Console.WriteLine("  Введите ваш пароль: ");
            while ((y.key.Key != ConsoleKey.Enter)&& (pos != 4))
            {
                Console.SetCursorPosition(0, pos);
                Console.WriteLine("->");
                if ((y.key.Key == ConsoleKey.Enter) && (pos == 2))
                {
                    while (y.key.Key != ConsoleKey.UpArrow ||  y.key.Key != ConsoleKey.DownArrow)
                    {
/*                        Console.SetCursorPosition(21, 2);*/
                        y.key = Console.ReadKey();
                        login += y.key.KeyChar;
                        i++;
                    }
                }
               /* y.key = Console.ReadKey();
                Console.SetCursorPosition(i, 3);
                Console.Write("*");
                password += y.key.KeyChar;
                i++;*/

            }
        }
        private void goup_login()
        {
            pos--;
            Console.SetCursorPosition(0, pos);
            Console.Write("  ");
            if (pos > 4)
                pos = 4;
        }
        private void godown_login()
        {
            Console.SetCursorPosition(0, pos);
            Console.Write("  ");
            if (pos < 2)
                pos = 2;
        }
    }
}
