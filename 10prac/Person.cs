using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10prac
{
    internal class Person
    {
        public Person(string a, int b, int c)
        {
            name = a;
            password = b;
            enum_job_title = c;
        }
        public string name;
        public int password;
        public int enum_job_title;
    }
}
