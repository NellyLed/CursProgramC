using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoSystem
{
    public partial class Главная : Form
    {
        public Главная()
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile(@"C:\Users\LED\Desktop\1_visual\9_visual\фон.jpg");
            pictureBox1.Image = Image.FromFile(@"C:\Users\LED\Desktop\1_visual\9_visual\1_kurs.jpg");
            pictureBox2.Image = Image.FromFile(@"C:\Users\LED\Desktop\1_visual\9_visual\2_kurs.jpg");
            pictureBox3.Image = Image.FromFile(@"C:\Users\LED\Desktop\1_visual\9_visual\3_kurs.jpg");
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
        }
        //ознакомиться(1 курс)
        private void button1_Click(object sender, EventArgs e)
        {
            Характеристика_1_курс k = new Характеристика_1_курс();
            k.Show();
        }
        //ознакомиться(2 курс)
        private void button2_Click(object sender, EventArgs e)
        {
            Характеристика_2_курс k = new Характеристика_2_курс();
            k.Show();
        }
        //ознакомиться(3 курс)
        private void button3_Click(object sender, EventArgs e)
        {
            Характеристика_3_курс k = new Характеристика_3_курс();
            k.Show();
        }
        //войти
        private void button4_Click(object sender, EventArgs e)
        {
            Авторизация a = new Авторизация();
            a.Show();
        }

        private void Главная_Load(object sender, EventArgs e)
        {

        }
    }
}
