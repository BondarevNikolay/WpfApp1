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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //data_buffer.empls.Clear();
            data_buffer.empls.Add(new Emploer("Nick", "Gray", "First", "Administrator", 34, 10));
            data_buffer.empls.Add(new Emploer("Yan", "Green", "First", "Inspector", 26, 5));
            data_buffer.empls.Add(new Emploer("Anna", "Yellow", "Second", "Administrator", 29, 8));
            Load();
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
            empl_list.Items.Clear();
            Load();
        }
        
        private void btnAdd_Click_1(object sender, RoutedEventArgs e)
        {
            data_buffer.empls.Add(new Emploer(Convert.ToString(tbFirstName.Text), Convert.ToString(tbLastName.Text), Convert.ToString(tbDepartament.Text), Convert.ToString(tbPost.Text), Convert.ToInt32(tbAge.Text), Convert.ToInt32(tbExprience.Text)));

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is little WPF application without data binding.");
        }

        private void empl_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            data_buffer.selectedinex = empl_list.SelectedIndex;
            if (empl_list.SelectedIndex >= 0 && empl_list.SelectedIndex <= data_buffer.empls.Count)
            {
                tbAge.Text = data_buffer.empls[empl_list.SelectedIndex].Age.ToString();
                tbDepartament.Text = data_buffer.empls[empl_list.SelectedIndex].Departsment.ToString();
                tbExprience.Text = data_buffer.empls[empl_list.SelectedIndex].Xp.ToString();
                tbFirstName.Text = data_buffer.empls[empl_list.SelectedIndex].FirstName.ToString();
                tbLastName.Text = data_buffer.empls[empl_list.SelectedIndex].LastName.ToString();
                tbPost.Text = data_buffer.empls[empl_list.SelectedIndex].Post.ToString();
            }
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            data_buffer.empls[data_buffer.selectedinex] = new Emploer(Convert.ToString(tbFirstName.Text), Convert.ToString(tbLastName.Text), Convert.ToString(tbDepartament.Text), Convert.ToString(tbPost.Text), Convert.ToInt32(tbAge.Text), Convert.ToInt32(tbExprience.Text));
        }
    }
}
