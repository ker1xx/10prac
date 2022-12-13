using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10prac
{
    internal class arrows
    {
        public virtual void godown()
        {
            Console.SetCursorPosition(0,0);
            Console.Write("  ");
            /* taskamanager.pos++;*/
        }
        public virtual void goup()
        {
            Console.SetCursorPosition(0, /*taskamanager.pos*/0);
            Console.Write("  ");
            /*taskamanager.pos--;*/
            /*НУЖНО ИФЫ ПРОПИСАТь*/
        }
    }
}
