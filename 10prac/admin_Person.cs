using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10prac
{
    internal class admin_Person : ID
    {
        public admin_Person(string a, string b, int c, int d) : base(d)
        {
            username = a;
            password = b;
            enum_job_title = c;
            idi = d;
            ID id = new ID(idi);
        }
        public string username;
        public string password;
        public int enum_job_title;
        public int idi;
    }
}
