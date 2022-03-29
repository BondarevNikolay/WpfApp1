using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2_binding
{
    internal class Employer
    {
        public string FirstName { get; set; } = "None";
        public string LastName { get; set; } = "None";
        public string Departsment { get; set; } = "None";
        public string Post { get; set; } = "None";
        public int Age { get; set; } = 0;
        public int Xp { get; set; } = 0;
        /*public Employer(string fname, string lname, string depart, string post, int age, int xp)
        {
            FirstName = fname;
            LastName = lname;
            Departsment = depart;
            Post = post;
            Age = age;
            Xp = xp;
        }
        public override string ToString()
        {
            return $"{FirstName}\t{LastName}\t{Age}\t{Departsment}\t{Post}\t{Xp}";
        }*/

    }
}
