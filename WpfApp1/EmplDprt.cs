using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{

    public class Emploer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Departsment { get; set; }
        public string Post { get; set; }
        public int Age { get; set; }
        public int Xp { get; set; }
        public Emploer(string fname, string lname, string depart, string post, int age, int xp)
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
        }

    }
}
