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
    public partial class Заказа : Form
    {
        string connectionString =
ConfigurationManager.ConnectionStrings["курсовая_новая_2"].ConnectionString;
        SqlConnection conn = new SqlConnection();
       
        public Заказа()
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile(@"C:\Users\LED\Desktop\1_visual\9_visual\фон.jpg");
        }
        //проверить
        private void button1_Click(object sender, EventArgs e)
        {
            if (Daten.Client != 0 && Daten.Курс != 0 && Daten.Пакет != 0)
            {
                DialogResult result = MessageBox.Show("Введенные данные верны?", "Confirmation",
   MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    label5.Visible = true;
                    comboBox1.Visible = true;
                    label7.Visible = true;
                    maskedTextBox1.Visible = true;
                }
                else if (result == DialogResult.No)
                { MessageBox.Show("Произошла ошибка"); }
                MessageBox.Show("Можете оплатить курс");
            }
            else
            {
                MessageBox.Show("Вы не ввели все необходимые данные (не авторизовались, не выбрали пакет услуг или курс)!");
            }
        }
        //назад
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //оплатить
        private void button3_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand com = new SqlCommand();
            com.CommandType = System.Data.CommandType.Text;
            com.CommandText = String.Format("select max(ID_заказа) from Заказ");
            com.Connection = conn;
            int res_6 = (int)com.ExecuteScalar();
            res_6 = res_6 + 1;
            SqlCommand com_2 = new SqlCommand();
            com_2.CommandText = String.Format("insert into Заказ(ID_заказа, ID_клиента, ID_курсы, ID_пакета, Стоимость, Банк, Карта)values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", res_6, Daten.Client, Daten.Курс, Daten.Пакет, textBox1.Text, comboBox1.SelectedItem.ToString(), maskedTextBox1.Text);
            com_2.Connection = conn;
            int res = (int)com_2.ExecuteNonQuery();
            if (res > 0) // если есть совпадения с бд
            {
                MessageBox.Show("Ваши данные приняты. Курс оплачен");
            }
            else { MessageBox.Show("Курс не оплачен"); }
            conn.Close();
        }

        private void Заказа_Load(object sender, EventArgs e)
        {
            textBox6.Text = Daten.ФИО_клиента;
            textBox7.Text = Daten.Формат;
            textBox8.Text = Daten.Преподаватель;
            textBox9.Text = Daten.День;
            textBox10.Text = Daten.Время;
            FormCollection fc = Application.OpenForms;
            foreach (Form frm in fc)
            {
                //запись стоимости
                if (frm.Name == "Характеристика_1_курс")
                {
                    textBox1.Text = Convert.ToString(120000);
                    textBox2.Text = DateTime.Now.ToString();
                }
                else if (frm.Name == "Характеристика_2_курс")
                {
                    textBox1.Text = Convert.ToString(89000);
                    textBox2.Text = DateTime.Now.ToString();
                }
                else if (frm.Name == "Характеристика_3_курс")
                {
                    textBox1.Text = Convert.ToString(134000);
                    textBox2.Text = DateTime.Now.ToString();
                }
            }
        }
    }
}
