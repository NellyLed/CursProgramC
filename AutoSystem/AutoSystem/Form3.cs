using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace AutoSystem
{
    public partial class Регистрация : Form
    {
        string connectionString =ConfigurationManager.ConnectionStrings["курсовая_новая_2"].ConnectionString;
        SqlConnection conn = new SqlConnection();
        public Регистрация()
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile(@"C:\Users\LED\Desktop\1_visual\9_visual\фон.jpg");
        }
        //записать
        private void button1_Click(object sender, EventArgs e)
        {
            if ((maskedTextBox1.Text == "") && (maskedTextBox2.Text == "") && (maskedTextBox3.Text== "") && (maskedTextBox4.Text == "") && (maskedTextBox5.Text == "") && (maskedTextBox6.Text == ""))
            {
                MessageBox.Show("Заполните все поля");
            }
            else
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand com = new SqlCommand();
                com.CommandType = System.Data.CommandType.Text;
                com.CommandText = String.Format("select max(ID_клиента) from Клиент");
                com.Connection = conn;
                int res_6 = (int)com.ExecuteScalar();
                res_6 = res_6 + 1;
                SqlCommand com_2 = new SqlCommand();
                com_2.CommandText = String.Format("insert into Клиент(ID_клиента, ФИО, Телефон, Почта, Адрес, Логин, Пароль) values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", res_6,maskedTextBox6.Text,maskedTextBox3.Text, maskedTextBox1.Text, maskedTextBox5.Text, maskedTextBox4.Text,maskedTextBox2.Text);
                com_2.Connection = conn;
                int res = (int)com_2.ExecuteNonQuery();
                if (res == 1)
                {
                    Daten.Client = res;
                    SqlCommand om = new SqlCommand();
                    om.CommandType = System.Data.CommandType.Text;
                    om.CommandText = String.Format("select ФИО from Клиент where ФИО='{0}'",maskedTextBox6.Text);
                    om.Connection = conn;
                    string res_5 = om.ExecuteScalar().ToString();
                    if (res_5 != "")
                        Daten.ФИО_клиента = res_5;
                    MessageBox.Show("Все указано верно");
                }
                else { MessageBox.Show("Пользователь с таким логином и паролем существует"); }
            }
            this.Close();
        }
        //назад
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
