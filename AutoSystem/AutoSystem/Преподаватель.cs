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
    public partial class Преподаватель : Form
    {
        string connectionString =
ConfigurationManager.ConnectionStrings["курсовая_новая_2"].ConnectionString;
        SqlConnection conn = new SqlConnection();
        DataSet ds = new DataSet();
        DataSet ds_1 = new DataSet();
        public Преподаватель()
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile(@"C:\Users\LED\Desktop\1_visual\9_visual\фон.jpg");
        }
        //отфильтровать для отзывов
        private void button1_Click(object sender, EventArgs e)
        {
            string filter = String.Format("{0} = '{1}'", "ID_преподавателя", textBox1.Text);//фильтр
            ds_1.Tables["Отзывы"].DefaultView.RowFilter = filter;//отфильтровать по фильтру
            dataGridView2.DataSource = ds_1.Tables["Отзывы"];//на datagrid источник данных - таблица недвижимость
        }
        //отсортировать
        private void button2_Click(object sender, EventArgs e)
        {
            string sort = comboBox1.SelectedItem.ToString();//sort - выбранная строка comboBox
            if (checkBox1.Checked)
            {
                sort += " DESC";//если выбрать по убыванию, то сортировать по убыванию
            }
            else if (checkBox2.Checked)
            {
                sort += " ASC";
            }
            ds.Tables["Преподаватель"].DefaultView.Sort = sort;
        }
        //назад
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //форма проверки
        private void button4_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(connectionString);
            SqlCommand com = new SqlCommand("Для_проверки_время_день", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("@date_ned", SqlDbType.VarChar).Value = textBox2.Text;
            com.Parameters.Add("@time", SqlDbType.Time).Value = textBox3.Text;
            conn.Open();
            string res_4 = com.ExecuteScalar().ToString();
            if (res_4 != "") // если есть совпадения с бд
            {
                MessageBox.Show("День и время учтены");
                Daten.Формат = textBox4.Text;
                Daten.Преподаватель = textBox5.Text;
                Daten.День = textBox2.Text;
                Daten.Время = textBox3.Text;
                //запись курса
                FormCollection fc = Application.OpenForms;
                foreach (Form frm in fc)
                {
                    //iterate through
                    if (frm.Name == "Характеристика_1_курс")
                    {
                        //запись 1 курса записать здесь препода и формат через процедуру скл
                        SqlCommand com_2 = new SqlCommand("Запись", conn);
                        com_2.CommandType = CommandType.StoredProcedure;
                        com_2.Parameters.Add("@kurs", SqlDbType.VarChar).Value = "Date Science";
                        int res = (int)com_2.ExecuteScalar();
                        if (res > 0) // если есть совпадения с бд
                        {
                            MessageBox.Show("Первый курс записан");
                            Daten.Курс = res;
                        }
                        else { MessageBox.Show("Курс не записан"); }
                    }
                    else if (frm.Name == "Характеристика_2_курс")
                    {
                        //запись 2 курса
                        SqlCommand com_2 = new SqlCommand("Запись", conn);
                        com_2.CommandType = CommandType.StoredProcedure;
                        com_2.Parameters.Add("@kurs", SqlDbType.VarChar).Value = "Бюджетирование";
                        int res = (int)com_2.ExecuteScalar();
                        if (res > 0) // если есть совпадения с бд
                        {
                            MessageBox.Show("Второй курс записан");
                            Daten.Курс = res;
                        }
                        else { MessageBox.Show("Курс не записан"); }
                    }
                    else if (frm.Name == "Характеристика_3_курс")
                    {
                        //запись 3 курса
                        SqlCommand com_2 = new SqlCommand("Запись", conn);
                        com_2.CommandType = CommandType.StoredProcedure;
                        com_2.Parameters.Add("@kurs", SqlDbType.VarChar).Value = "Mini MBA";
                        int res = (int)com_2.ExecuteScalar();
                        if (res > 0) // если есть совпадения с бд
                        {
                            MessageBox.Show("Третий курс записан");
                            Daten.Курс = res;
                        }
                        else { MessageBox.Show("Курс не записан"); }
                    }
                }
                conn.Close();
                MessageBox.Show("Ваш выбор времени записан! Выберите пакет услуг");
                Пакет_услуг p = new Пакет_услуг();
                p.Show();
                this.Close();
            }
            else { MessageBox.Show("Не учтены дата и время. Выберите другое время"); }
        }

                    private void Преподаватель_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["курсовая_новая_2"].ConnectionString);
            SqlDataAdapter cl = new SqlDataAdapter("select * from Преподаватель", conn);//объект адаптер
cl.Fill(ds, "Преподаватель");//заполнение таблицы
                             //чтение списка названий столбцов таблицы в combobox
            foreach (DataColumn col in ds.Tables["Преподаватель"].Columns)
            {
                if (col.ColumnName != "ID_преподавателя" && col.ColumnName != "ID_формата" &&
                col.ColumnName != "ID_графика")
                    comboBox1.Items.Add(col.ColumnName);//заполнить поля
            }
            dataGridView1.DataSource = ds.Tables["Преподаватель"];//вывести по полю тип
            SqlDataAdapter cl_2 = new SqlDataAdapter("select * from Отзывы", conn);//объект адаптер
            cl_2.Fill(ds_1, "Отзывы");//заполнение таблицы
            dataGridView2.DataSource = ds_1.Tables["Отзывы"];

        }
    }
}
