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
using System.Data.SqlClient;


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
            Load();
            


        }
        private void Load()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Draugort\source\repos\WpfApp1\WpfApp1\db\EmployeeDB.mdf;Integrated Security=True";
            //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|AppData\db\EmployeeDB.mdf;Integrated Security=True"; //providerName=System.Data.SqlClient"; // Пробовал относительные пути, но что-то не сработало =(
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Employers", connection);
                //SqlCommand del = new SqlCommand("Delete From Employers Where fName_nvc50='Anna'", connection);
                //SqlCommand update = new SqlCommand("Update Employers Set fName_nvc50='Anny' Where fName_nvc50='Anna'", connection);
                //SqlCommand add = new SqlCommand("Insert Into Employers(fName_nvc50, lName_nvc50, Departament_nvc50, Post_nvc50, Age_int, XP_int) Values ('','','','','' ... )", connection);

                SqlDataReader reader = command.ExecuteReader();

                EmployeeList.Clear();
                while (reader.Read())
                {
                    EmployeeList.Add(new Emploer((string)reader["fName_nvc50"], (string)reader["lName_nvc50"], (string)reader["Departament_nvc50"], (string)reader["Post_nvc50"], (int)reader["Age_int"], (int)reader["XP_int"], (int)reader["id"]));
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { connection.Close(); }


            empl_list.ItemsSource = EmployeeList;
            /*empl_list.Items.Clear();
            foreach (Emploer emp in data_buffer.empls)
            {
                empl_list.Items.Add(emp.ToString());
            }*/
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
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Draugort\source\repos\WpfApp1\WpfApp1\db\EmployeeDB.mdf;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                //string command = "Insert Into Employers(fName_nvc50, lName_nvc50, Departament_nvc50, Post_nvc50, Age_int, XP_int) Values(@fName,@lName,@Departament,@Post,@Age,@XP)";
                /*string command = "Insert Into Employers Values(@fName,@lName,@Departament,@Post,@Age,@XP)";

                SqlCommand add = new SqlCommand(command, connection);
                add.Parameters.AddWithValue("@fName", tbFirstName.Text);
                add.Parameters.AddWithValue("@lName", tbLastName.Text);
                add.Parameters.AddWithValue("@Departament", tbDepartament.Text);
                add.Parameters.AddWithValue("@Post", tbPost.Text);
                add.Parameters.AddWithValue("@Age", tbAge.Text);
                add.Parameters.AddWithValue("@XP", tbExprience.Text);*/

                SqlCommand add = new SqlCommand("Insert Into Employers(fName_nvc50,lName_nvc50,Departament_nvc50,Post_nvc50,Age_int,XP_int)" +
                    "Values ('" + Convert.ToString(tbFirstName.Text) +
                    "','" + Convert.ToString(tbLastName.Text) +
                    "','" + Convert.ToString(tbDepartament.Text) +
                    "','" + Convert.ToString(tbPost.Text) +
                    "','" + Convert.ToInt32(tbAge.Text) +
                    "'," + Convert.ToInt32(tbExprience.Text) + 
                    ")", connection);
                add.ExecuteNonQuery();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { connection.Close(); }

            //EmployeeList.Add(new Emploer(Convert.ToString(tbFirstName.Text), Convert.ToString(tbLastName.Text), Convert.ToString(tbDepartament.Text), Convert.ToString(tbPost.Text), Convert.ToInt32(tbAge.Text), Convert.ToInt32(tbExprience.Text), Convert.ToInt32(tbID.Text)));
            Load();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is little WPF application with ObservableCollection binding + DB");
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
                tbID.Text = EmployeeList[indx].ID.ToString();
            }
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            int indx = empl_list.SelectedIndex;
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Draugort\source\repos\WpfApp1\WpfApp1\db\EmployeeDB.mdf;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand update = new SqlCommand("Update Employers Set " +
                    "fName_nvc50='"+ Convert.ToString(tbFirstName.Text) +
                    "', lName_nvc50='"+ Convert.ToString(tbLastName.Text) +
                    "', Departament_nvc50='" + Convert.ToString(tbDepartament.Text) +
                    "', Post_nvc50='" + Convert.ToString(tbPost.Text) +
                    "', Age_int=" + Convert.ToInt32(tbAge.Text) +
                    ", XP_int=" + Convert.ToInt32(tbExprience.Text) + 
                    "Where " +
                    "id=" + Convert.ToInt32(tbID.Text), connection);

                update.ExecuteNonQuery();


            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { connection.Close(); }


            //if (indx >= 0 && indx <= EmployeeList.Count)
            //EmployeeList[empl_list.SelectedIndex] = new Emploer(Convert.ToString(tbFirstName.Text), Convert.ToString(tbLastName.Text), Convert.ToString(tbDepartament.Text), Convert.ToString(tbPost.Text), Convert.ToInt32(tbAge.Text), Convert.ToInt32(tbExprience.Text), Convert.ToInt32(tbID.Text));
            Load();
        }

        private void btnSentToDB_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            

            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Draugort\source\repos\WpfApp1\WpfApp1\db\EmployeeDB.mdf;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand del = new SqlCommand("Delete From Employers Where id="+ Convert.ToString(empl_list.SelectedIndex), connection);
                del.ExecuteNonQuery();

                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { connection.Close(); }
            Load();
        }
    }
}
