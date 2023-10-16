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
    public partial class Программа_2_курс : Form
    {
        public Программа_2_курс()
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile(@"C:\Users\LED\Desktop\1_visual\9_visual\фон.jpg");
            pictureBox1.Image = Image.FromFile(@"C:\Users\LED\Desktop\1_visual\9_visual\бюджетиров.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }
        //назад
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
