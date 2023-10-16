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
    public partial class Формат : Form
    {
        string connectionString =
ConfigurationManager.ConnectionStrings["курсовая_новая_2"].ConnectionString;
        SqlConnection conn = new SqlConnection();
        DataSet ds = new DataSet();
        public Формат()
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile(@"C:\Users\LED\Desktop\1_visual\9_visual\фон.jpg");
        }
        //отфильтровать
        private void button1_Click(object sender, EventArgs e)
        {
            string filter = String.Format("{0} = '{1}'", comboBox1.SelectedItem.ToString(),textBox1.Text);//фильтр
            ds.Tables["Формат"].DefaultView.RowFilter = filter;//отфильтровать по фильтру
            dataGridView1.DataSource = ds.Tables["Формат"];//на datagrid источник данных - таблица недвижимость
        }
        //сортировать
        private void button2_Click(object sender, EventArgs e)
        {
            string sort = comboBox1.SelectedItem.ToString();//sort - выбранная строка comboBox
            if (checkBox1.Checked)
            {
                sort += " DESC";//если выбрать по убыванию, то сортировать по убыванию
            }//источник данных сортируется по sort
            else if (checkBox2.Checked)
            {
                sort += " ASC";
            }
            ds.Tables["Формат"].DefaultView.Sort = sort;
        }
        //назад
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //принять
        private void button4_Click(object sender, EventArgs e)
        {
            Преподаватель p = new Преподаватель();
            p.textBox2.Text = this.textBox4.Text;
            p.textBox3.Text = this.textBox5.Text;
            p.textBox4.Text = this.textBox2.Text;
            if (p.textBox2.Text != "" && p.textBox3.Text != "" && p.textBox4.Text != "")
            {
                MessageBox.Show("Данные записаны верно.Сейчас откроется форма с выбором преподавателей");
                p.Show();
                this.Close();
            }
            else { MessageBox.Show("Произошла ошибка"); }
        }
        //определяем данные таблицы
        private void Формат_Load(object sender, EventArgs e)
        {
            conn = new
SqlConnection(ConfigurationManager.ConnectionStrings["курсовая_новая_2"].ConnectionString);
            SqlDataAdapter cl = new SqlDataAdapter("select * from Формат", conn);//объект адаптер
            cl.Fill(ds, "Формат");//заполнение таблицы
                                  //чтение списка названий столбцов таблицы в combobox
            foreach (DataColumn col in ds.Tables["Формат"].Columns)
            {
                if (col.ColumnName != "ID_формата")
                    comboBox1.Items.Add(col.ColumnName);//заполнить поля
            }
            dataGridView1.DataSource = ds.Tables["Формат"].DefaultView;//вывести по полю тип
        }
    }
}
