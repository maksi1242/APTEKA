using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;


namespace ПРАКТИКА__АПТЕКА_
{
    /// <summary>
    /// Логика взаимодействия для REGISTRACIYA_APTEKA_.xaml
    /// </summary>
    public partial class REGISTRACIYA_APTEKA_ : Window
    {
        public REGISTRACIYA_APTEKA_()
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
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            switch (PasswordBox2.Password == PasswordBox1.Password)
            {
                case (true):
                    string NewUserCkeck;
                    ConnectionClass ConCheck = new ConnectionClass();


                    RegistryKey DataBase_Connection = Registry.CurrentConfig;
                    RegistryKey Connection_Base_Party_Options = DataBase_Connection.CreateSubKey("Apteka_A");
                    ConCheck.Connection_Options(Connection_Base_Party_Options.GetValue("DS").ToString(),
                    Connection_Base_Party_Options.GetValue("IC").ToString(),
                    Connection_Base_Party_Options.GetValue("UID").ToString(),
                    Connection_Base_Party_Options.GetValue("PDB").ToString()); 
          
                    SqlConnection connectionNewUser = new SqlConnection(ConCheck.ConnectString);
                    SqlCommand Select_USID = new SqlCommand("select [dbo].[Login].[Login_] " +
                    " from [dbo].[Login] " +
                    "where Login_='" + Login_text.Text, connectionNewUser);
                    try
                    {
                        connectionNewUser.Open();
                        NewUserCkeck = Select_USID.ExecuteScalar().ToString();
                        connectionNewUser.Close();
                        MessageBox.Show("Пользователь с именем " + NameClient_textbox.Text + ", уже есть!");
                    }
                    catch
                    {
                        string GuestRole;
                        int Tel_Value;
                        SqlConnection connectionNewUserInsert = new SqlConnection(ConCheck.ConnectString);
                                             
                        try
                        {
                            SqlCommand CreateNewUser = new SqlCommand("Login_ADD", connectionNewUserInsert);
                            CreateNewUser.CommandType = CommandType.StoredProcedure;
                            CreateNewUser.Parameters.AddWithValue("@fam", FamKlient_textbox.Text);
                            CreateNewUser.Parameters.AddWithValue("@imya", NameClient_textbox.Text);
                            CreateNewUser.Parameters.AddWithValue("@otch", Otch_klient_Textbox.Text);
                            CreateNewUser.Parameters.AddWithValue("@nomer_pass", Nomer_pass_Textbox.Text);
                            CreateNewUser.Parameters.AddWithValue("@telefon", Telefon_Textbox.Text);
                            CreateNewUser.Parameters.AddWithValue("@login_", Login_text.Text);
                            CreateNewUser.Parameters.AddWithValue("@pass", PasswordBox1.Password);
                            CreateNewUser.Parameters.AddWithValue("@roli_id", 2);

                            connectionNewUserInsert.Open();
                            CreateNewUser.ExecuteNonQuery();
                            connectionNewUserInsert.Close();
                            MessageBox.Show("Вы прошли регистрацию!");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        }
                            break;
                        case (false):
                            MessageBox.Show("Пароли не совпадают, повторите попытку");
                            break;
                    }
            }

        private void Telefon_Textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Telefon_Textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key < Key.D0 || e.Key > Key.D9) // если код нажатой кнопки находится в данном диапазоне
            {
                if (e.Key <Key.NumPad0 || e.Key > Key.NumPad9) //если анажата кнопка с цифрой
                {
                    e.Handled = true; //Разрешить ввод
                }
            }
            else
            {
                e.Handled = true; //Запретить ввод
            }
        }

        private void Nomer_pass_Textbox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key < Key.D0 || e.Key > Key.D9) // если код нажатой кнопки находится в данном диапазоне
            {
                if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9) //если анажата кнопка с цифрой
                {
                    e.Handled = true; //Разрешить ввод
                }
            }
            else
            {
                e.Handled = true; //Запретить ввод
            }
        }


        }
    }
