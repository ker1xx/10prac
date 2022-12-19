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
        public Person(string a, string b, int c, int d)
        {
            username = a;
            password = b;
            enum_job_title = c;
            id = d;
        }
        public string username;
        public string password;
        public int enum_job_title;
        public int id;
    }
}
