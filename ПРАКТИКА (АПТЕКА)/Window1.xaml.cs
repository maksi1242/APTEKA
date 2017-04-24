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
using System.Windows.Shapes;
using System.Data.SqlClient;
using Microsoft.Win32;
using System.Data;

namespace ПРАКТИКА__АПТЕКА_
{
    /// <summary>
    /// Логика взаимодействия для Connection.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public SqlConnection Try_Connect = new SqlConnection();

        public Window1()
        {
            InitializeComponent();
        }
        void ServersCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        void window1_Loaded(object sender, RoutedEventArgs e)
        {

        }

       void ServersCB_GotMouseCapture(object sender, MouseEventArgs e)
        {
            //Try_Connect.Close();
        //    try
          //  {

            //    Try_Connect.ConnectionString = "Data Source=DESKTOP-7EPDK3G" + ServersCB.Text
              //      + "; Initial Catalog=Apteka_A; Persist Security Info=True;User ID=sa"
                //    + UserName_text.Text + ";Password=\"" + Pass_text.Text + "\"";
                //Try_Connect.Open();
                //SqlDataAdapter Base_Adapter = new SqlDataAdapter("exec sp_helpdb", Try_Connect);
                //DataSet Base_Data_Set = new DataSet();
                //Base_Adapter.Fill(Base_Data_Set, "db");

                //SelectDBCB.ItemsSource = Base_Data_Set.Tables[0].DefaultView;
                //SelectDBCB.DisplayMemberPath = "name";
                //Try_Connect.Close();
           // }
           // catch (Exception ex)
           // {
             //   MessageBox.Show(ex.Message);
            //}
        }
        void SelectDBCB_GotMouseCapture(object sender, MouseEventArgs e)
        {
            //Try_Connect.Close();
            try
            {

                Try_Connect.ConnectionString = "Data Source=" + ServersCB.Text
                    + "; Initial Catalog=master; Persist Security Info=True;User ID="
                    + UserName_text.Text + ";Password=\"" + Pass_text.Text + "\"";
                Try_Connect.Open();
                //Data Source=DESKTOP-7EPDK3G;Initial Catalog=Apteka_A;User ID=sa
                SqlDataAdapter Base_Adapter = new SqlDataAdapter("exec sp_helpdb", Try_Connect);
                DataSet Base_Data_Set = new DataSet();
                Base_Adapter.Fill(Base_Data_Set, "db");

                SelectDBCB.ItemsSource = Base_Data_Set.Tables[0].DefaultView;
                SelectDBCB.DisplayMemberPath = "name";
                Try_Connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void button1_Click(object sender, RoutedEventArgs e)
        {
            RegistryKey DataBase_Connection = Registry.CurrentConfig;
            RegistryKey Connection_Base_Party_Options = DataBase_Connection.CreateSubKey("DB_PARTY_OPTIOS");
            Connection_Base_Party_Options.SetValue("DS", Encrypt.Encrypting(ServersCB.Text));
            Connection_Base_Party_Options.SetValue("IC", Encrypt.Encrypting("Apteka_A"));
            Connection_Base_Party_Options.SetValue("UID", Encrypt.Encrypting(UserName_text.Text));
            Connection_Base_Party_Options.SetValue("PDB", Encrypt.Encrypting(Pass_text.Text));

        }
        void Window1_ContentRendered(object sender, EventArgs e)
        {

        }

        private void ServersCB_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SelectDBCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        
        }
    }
