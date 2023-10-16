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
    public partial class Характеристика_2_курс : Form
    {
        public Характеристика_2_курс()
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile(@"C:\Users\LED\Desktop\1_visual\9_visual\фон.jpg");
            pictureBox1.Image = Image.FromFile(@"C:\Users\LED\Desktop\1_visual\9_visual\finance.jpg");
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }
        //назад
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //формат
        private void button2_Click(object sender, EventArgs e)
        {
            Формат f = new Формат();
            f.Show();
        }
        //программа(2 курс)
        private void button3_Click(object sender, EventArgs e)
        {
            Программа_2_курс p = new Программа_2_курс();
            p.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Вам понравился данный курс? Выберите?",
"Confirmation", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                button2.Visible = true;
            }
            else if (result == DialogResult.No)
            { MessageBox.Show("Посмотрите другие наши курсы"); }
        }
    }
}
