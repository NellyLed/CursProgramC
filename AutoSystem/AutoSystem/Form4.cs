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
    public partial class Характеристика_1_курс : Form
    {
        public Характеристика_1_курс()
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile(@"C:\Users\LED\Desktop\1_visual\9_visual\фон.jpg");
            pictureBox1.Image = Image.FromFile(@"C:\Users\LED\Desktop\1_visual\9_visual\data_s.jpg");
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }
        //формат
        private void button1_Click(object sender, EventArgs e)
        {
            Формат f = new Формат();
            f.Show();
        }
        //назад
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Вам понравился данный курс? Выберите?",
"Confirmation", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                button1.Visible = true;
            }
            else if (result == DialogResult.No)
            { MessageBox.Show("Посмотрите другие наши курсы"); }
        }
        //программа(1 курс)
        private void button3_Click(object sender, EventArgs e)
        {
            Программа_1_курс p = new Программа_1_курс();
            p.Show();
        }
        
    }
}
