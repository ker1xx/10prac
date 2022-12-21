using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10prac
{
    internal class Person_manager_Person : ID
    {
        public Person_manager_Person( string a, string b, string c, DateTime d, int e, int f, int g,int k) : base(k)
        {
            idi = k;
            ID id = new ID(idi);
            name = a;
            surname = b;
            lastname = c;
            birthday = d;
            passport = e;
            enum_job_title = f;
            salary = g;
        }
        public string name;
        public string surname;
        public string lastname;
        public DateTime birthday;
        public int passport;
        public int enum_job_title;
        public int salary;
        public int idi;
    }
}
