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
using Microsoft.Win32;
using System.Data.SqlClient;
using System.Data;




namespace ПРАКТИКА__АПТЕКА_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string USID;
        public string ISA;
        public MainWindow()
        {
            InitializeComponent();
        }

        void Button_Click(object sender, RoutedEventArgs e)
        {
            REGISTRACIYA_APTEKA_ fjfu = new REGISTRACIYA_APTEKA_();
            fjfu.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow xix = new MainWindow();
            Close();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ConnectionClass ConCheck = new ConnectionClass();
            /* RegistryKey DataBase_Connection = Registry.CurrentConfig;
             RegistryKey Connection_Base_Party_Options = DataBase_Connection.CreateSubKey("DB_AUTO_OPTIOS");*/
            ConCheck.Connection_Options("DESKTOP-7EPDK3G", "Apteka_A","sa","3290540");
            SqlConnection connectionUser = new SqlConnection(ConCheck.ConnectString);
            SqlCommand Select_USID = new SqlCommand("select [dbo].[Login].[ID_Login] " +
                "from [dbo].[Login] " +
                "where [Login_] = '" + logintext.Text + "' and [pass] = '" + PasswordBoxLog.Password + "'", connectionUser);
            SqlCommand Select_ISA = new SqlCommand("select [dbo].[roli].[Nazvanie]" +
              " from [dbo].[Login] inner join[dbo].[roli] on " +
              "[dbo].[Login].[Roli_id] =[dbo].[roli].[ID_roli]" +
              "where [Login_]='" + logintext.Text + "' and [pass]='" + PasswordBoxLog.Password + "'", connectionUser);


            try
            {
                connectionUser.Open();
                USID = Select_USID.ExecuteScalar().ToString();
                ISA = Select_ISA.ExecuteScalar().ToString();
                /* MessageBox.Show(ISA);
                 USID = Select_USID.ExecuteScalar().ToString();
                 ISA = Select_ISA.ExecuteScalar().ToString();
                 MessageBox.Show(ISA);
                connectionUser.Close();
                  */
                connectionUser.Close();


                MessageBox.Show("Авторизация пройлена успешно! Вы зашли  как гость )");
                Window2 regi = new Window2();
                this.Hide();
                regi.Show();
            }
            catch (Exception bl)
            {
                MessageBox.Show(bl.Message);
            }

        }

        

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void Buttonpodkl_Click(object sender, RoutedEventArgs e)
        {
           Window1  fjfu = new Window1();
            fjfu.Show();
            System.Data.Sql.SqlDataSourceEnumerator Server_List =
            System.Data.Sql.SqlDataSourceEnumerator.Instance;
            System.Data.DataTable Server_Table = Server_List.GetDataSources();
            foreach (DataRow row in Server_Table.Rows)
            {
                fjfu.ServersCB.Items.Clear();
                fjfu.ServersCB.Items.Add(row[0] + "\\" + row[1]);
            }
        }

      
            }
        }

    

