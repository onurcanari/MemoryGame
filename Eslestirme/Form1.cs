using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eslestirme
{
    public partial class Form1 : Form
    {
        static Image[] resimler = new Image[10];
        static PictureBox[] boxes = new PictureBox[20];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Ayarla();
            string[] path = Directory.GetFiles(@"resimler/", "*.png");
            for(int i=0;i<10;i++)
            {
                resimler[i] = Image.FromFile(path[i]);
                boxes[i].Image = resimler[i];
            }
            
        }

        private void YeniOyun(object sender, EventArgs e)
        {
            bool[] kullanilanResimler = new bool[resimler.Length];
        }
        private void Ayarla()
        {
            boxes[0] = pictureBox1;
            boxes[1] = pictureBox2;
            boxes[2] = pictureBox3;
            boxes[3] = pictureBox4;
            boxes[4] = pictureBox5;
            boxes[5] = pictureBox6;
            boxes[6] = pictureBox7;
            boxes[7] = pictureBox8;
            boxes[8] = pictureBox9;
            boxes[9] = pictureBox10;
            boxes[10] = pictureBox11;
            boxes[11] = pictureBox12;
        }
    }
}
