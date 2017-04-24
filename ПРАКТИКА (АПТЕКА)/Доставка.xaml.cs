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
using Microsoft.Win32;
using System.Data.SqlClient;
using System.Data;

namespace ПРАКТИКА__АПТЕКА_
{
    /// <summary>
    /// Логика взаимодействия для Доставка.xaml
    /// </summary>
    public partial class Доставка : Window
    {
        public Доставка()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = null;

            string sql = ("SELECT * FROM dbo.Dostavka ");
            DataTable Table = new DataTable();

            ConnectionClass ConCheck = new ConnectionClass();
            RegistryKey DataBase_Connection = Registry.CurrentConfig;
            RegistryKey Connection_Base_Party_Options = DataBase_Connection.CreateSubKey("Apteka_A");
            ConCheck.Connection_Options(Connection_Base_Party_Options.GetValue("DS").ToString(),
            Connection_Base_Party_Options.GetValue("IC").ToString(),
            Connection_Base_Party_Options.GetValue("UID").ToString(),
            Connection_Base_Party_Options.GetValue("PDB").ToString());

            connection = new SqlConnection(ConCheck.ConnectString);
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            connection.Open();
            adapter.Fill(Table);
            adapter.Update(Table);
            if (connection != null)
                connection.Close();

            such.ItemsSource = Table.DefaultView;
        }
    }
}
