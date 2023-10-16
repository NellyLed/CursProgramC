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
    public partial class Авторизация : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["курсовая_новая_2"].ConnectionString;
        SqlConnection conn = new SqlConnection();
        public Авторизация()
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile(@"C:\Users\LED\Desktop\1_visual\9_visual\фон.jpg");
            pictureBox1.Image = Image.FromFile(@"C:\Users\LED\Desktop\1_visual\9_visual\cap.jpg");
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }
        //вход
        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "") && (textBox2.Text == "")) // если поля не заполнены
            {
                MessageBox.Show("Не все поля заполнены");
            }
            else
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand com = new SqlCommand();
                com.CommandType = System.Data.CommandType.Text;
                com.CommandText = String.Format("select ID_клиента from Клиент where Логин='{0}' and Пароль = '{1}'", textBox1.Text, textBox2.Text);
                com.Connection = conn;
                int res = (int)com.ExecuteScalar();
                if (res == 1) // если есть совпадения с бд
                {
                    Daten.Client = res;
                    SqlCommand om = new SqlCommand();
                    om.CommandType = System.Data.CommandType.Text;
                    om.CommandText = String.Format("select ФИО from Клиент where Логин='{0}' and Пароль = '{1}'", textBox1.Text, textBox2.Text);
                    om.Connection = conn;
                    string re = om.ExecuteScalar().ToString();
                    if (re != "")
                        Daten.ФИО_клиента = re;
                    MessageBox.Show("Все указано верно");
                }
                else // совпадений нет
                {
                    MessageBox.Show("Неверный логин или пароль. Проверьте свои данные");
                }
            }
            this.Close();
        }
        //регистрация
        private void button2_Click(object sender, EventArgs e)
        {
            Регистрация r = new Регистрация();
            r.Show();
            this.Close();
        }
        //назад
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
