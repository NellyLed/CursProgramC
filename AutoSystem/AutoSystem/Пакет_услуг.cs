using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace AutoSystem
{
    public partial class Пакет_услуг : Form
    {
        string connectionString =ConfigurationManager.ConnectionStrings["курсовая_новая_2"].ConnectionString;
        SqlConnection conn = new SqlConnection();
        DataSet ds = new DataSet();
        Заказа z = new Заказа();
        public Пакет_услуг()
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile(@"C:\Users\LED\Desktop\1_visual\9_visual\фон.jpg");
        }
        //выбрать база
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ваша скидка составит 5%. Рассрочка - 6 месяцев.Вы согласны ? ","Confirmation", MessageBoxButtons.YesNoCancel);
if (result == DialogResult.Yes)
            {
                conn = new SqlConnection(connectionString);
                SqlCommand com = new SqlCommand("Пакет", conn);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@baza", SqlDbType.VarChar).Value = linkLabel1.Text;
                com.Parameters.Add("@pluz", SqlDbType.VarChar).Value = linkLabel2.Text;
                com.Parameters.Add("@but", SqlDbType.VarChar).Value = linkLabel3.Text;
                conn.Open();
                int res = (int)com.ExecuteScalar();
                if (res > 0)
                {
                    Daten.Пакет = res;
                    MessageBox.Show("Базовый пакет записан");
                    z.Show();
                    this.Close();
                }
            }
            else if (result == DialogResult.No)
            { MessageBox.Show("Посмотрите другие пакеты услуг"); }
        }
        //выбрать плюс
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ваша скидка составит 7%. Рассрочка - 8 месяцев.Вы согласны ? ", "Confirmation", MessageBoxButtons.YesNoCancel);
if (result == DialogResult.Yes)
            {
                conn = new SqlConnection(connectionString);
                SqlCommand com = new SqlCommand("Пакет", conn);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@baza", SqlDbType.VarChar).Value = linkLabel1.Text;
                com.Parameters.Add("@pluz", SqlDbType.VarChar).Value = linkLabel2.Text;
                com.Parameters.Add("@but", SqlDbType.VarChar).Value = linkLabel3.Text;
                conn.Open();
                int res = (int)com.ExecuteScalar();
                if (res > 0)
                {
                    Daten.Пакет = res;
                    MessageBox.Show("Плюс пакет записан");
                    z.Show();
                    this.Close();
                }
            }
            else if (result == DialogResult.No)
            { MessageBox.Show("Посмотрите другие пакеты услуг"); }
        }
        //выбрать буткемп
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ваша скидка составит 10%. Рассрочка - 12 месяцев.Вы согласны ? ", "Confirmation", MessageBoxButtons.YesNoCancel);
if (result == DialogResult.Yes)
            {
                conn = new SqlConnection(connectionString);
                SqlCommand com = new SqlCommand("Пакет", conn);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@baza", SqlDbType.VarChar).Value = linkLabel1.Text;
                com.Parameters.Add("@pluz", SqlDbType.VarChar).Value = linkLabel2.Text;
                com.Parameters.Add("@but", SqlDbType.VarChar).Value = linkLabel3.Text;
                conn.Open();
                int res = (int)com.ExecuteScalar();
                if (res > 0)
                {
                    Daten.Пакет = res;
                    MessageBox.Show("Буткемп пакет записан");
                    z.Show();
                    this.Close();
                }
            }
            else if (result == DialogResult.No)
            { MessageBox.Show("Посмотрите другие пакеты услуг"); }
        }
        //назад
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
