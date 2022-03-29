using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

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
    public class EmployeeList
    {
        public ObservableCollection<Emploer> List { get; set; } = new ObservableCollection<Emploer>();
    }
    public class View
    {
        public EmployeeList EmployeeList { get; set; }
        
        public View()
        {
            EmployeeList = new EmployeeList() 
            { List = { new Emploer("Nick", "Gray", "First", "Administrator", 34, 10), 
                       new Emploer("Yan", "Green", "First", "Inspector", 26, 5),
                       new Emploer("Anna", "Yellow", "Second", "Administrator", 29, 8)} };
        }
    }
}
