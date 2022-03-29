using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Emploer> EmployeeList = new ObservableCollection<Emploer>();
        public MainWindow()
        {
            InitializeComponent();

            EmployeeList.Clear();
            EmployeeList.Add(new Emploer("Nick", "Gray", "First", "Administrator", 34, 10));
            EmployeeList.Add(new Emploer("Yan", "Green", "First", "Inspector", 26, 5));
            EmployeeList.Add(new Emploer("Anna", "Yellow", "Second", "Administrator", 29, 8));

            empl_list.ItemsSource = EmployeeList;
            //DataContext = new View();
            
            /*Binding bind = new Binding();
            bind.ElementName = "";
            bind.Path = new PropertyPath("ItemSource");
            bind.Mode = BindingMode.OneWay;
            empl_list.SetBinding(ListView.ItemsSourceProperty, bind);*/

        }
        private void Load()
        {
            empl_list.Items.Clear();
            foreach (Emploer emp in data_buffer.empls)
            {
                empl_list.Items.Add(emp.ToString());
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            //empl_list.Items.Clear();
            //Load();
        }
        
        private void btnAdd_Click_1(object sender, RoutedEventArgs e)
        {

             EmployeeList.Add(new Emploer(Convert.ToString(tbFirstName.Text), Convert.ToString(tbLastName.Text), Convert.ToString(tbDepartament.Text), Convert.ToString(tbPost.Text), Convert.ToInt32(tbAge.Text), Convert.ToInt32(tbExprience.Text)));

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is little WPF application with ObservableCollection binding.");
        }

        private void empl_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            int indx = empl_list.SelectedIndex;

            //data_buffer.selectedinex = empl_list.SelectedIndex;
            if (indx >= 0 && indx <= EmployeeList.Count)
            {                
                tbAge.Text = EmployeeList[indx].Age.ToString();
                tbDepartament.Text = EmployeeList[indx].Departsment.ToString();
                tbExprience.Text = EmployeeList[indx].Xp.ToString();
                tbFirstName.Text = EmployeeList[indx].FirstName.ToString();
                tbLastName.Text = EmployeeList[indx].LastName.ToString();
                tbPost.Text = EmployeeList[indx].Post.ToString();
            }
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            int indx = empl_list.SelectedIndex;
            if (indx >= 0 && indx <= EmployeeList.Count)
            EmployeeList[empl_list.SelectedIndex] = new Emploer(Convert.ToString(tbFirstName.Text), Convert.ToString(tbLastName.Text), Convert.ToString(tbDepartament.Text), Convert.ToString(tbPost.Text), Convert.ToInt32(tbAge.Text), Convert.ToInt32(tbExprience.Text));
        }
    }
}
