using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eslestirme {
    public partial class Form1 : Form {


        static private PictureBox[] boxes = new PictureBox[20];
        private OyunYoneticisi yonetici;
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            Ayarla();
            yonetici=new OyunYoneticisi();

            for(int i = 0; i<boxes.Length; i++) {
                boxes[i].Image=OyunYoneticisi.varsayilanResim;
            }


        }

        private void Ayarla() {
            boxes[0]=pictureBox1;
            boxes[1]=pictureBox2;
            boxes[2]=pictureBox3;
            boxes[3]=pictureBox4;
            boxes[4]=pictureBox5;
            boxes[5]=pictureBox6;
            boxes[6]=pictureBox7;
            boxes[7]=pictureBox8;
            boxes[8]=pictureBox9;
            boxes[9]=pictureBox10;
            boxes[10]=pictureBox11;
            boxes[11]=pictureBox12;
            boxes[12]=pictureBox13;
            boxes[13]=pictureBox14;
            boxes[14]=pictureBox15;
            boxes[15]=pictureBox16;
            boxes[16]=pictureBox17;
            boxes[17]=pictureBox18;
            boxes[18]=pictureBox19;
            boxes[19]=pictureBox20;
        }

        private void YeniOyunBaslat(object sender, EventArgs e) {
            yonetici.YeniOyun();
            ResimleriGoster();
            Thread.Sleep(5000);
            for(int i = 0; i<boxes.Length; i++) {
                boxes[i].Image=OyunYoneticisi.varsayilanResim;
                boxes[i].Visible=true;
            }
            label2.Text=OyunYoneticisi.acilanResimSayisi.ToString();
            label1.Text=OyunYoneticisi.bulunanEsSayisi.ToString();
            
        }
        private void ResimleriGoster() {
            for(int i = 0; i<boxes.Length; i++) {
                boxes[i].Image=OyunYoneticisi.resimler[i];
                boxes[i].Refresh();
            }
        }
        private void ResimAc(object sender, MouseEventArgs e) {
            OyunYoneticisi.acilanResimSayisi++;
            for(int i = 0; i<boxes.Length; i++) {
                if(((PictureBox)sender).Equals(boxes[i])) {
                    boxes[i].Image=OyunYoneticisi.resimler[i];
                    boxes[i].Refresh();
                    OyunYoneticisi.acikResimler.Add(i);
                    break;
                }
            }
            if(OyunYoneticisi.acikResimler.Count==2) {
                timer1.Start();
                panel1.Enabled=false;
            }



        }
        private void ResimKontrol() {
            if(OyunYoneticisi.acikResimler.Count==2) {
                if(Convert.ToInt32(OyunYoneticisi.resimler[OyunYoneticisi.acikResimler.ElementAt(0)].Tag)==Convert.ToInt32(OyunYoneticisi.resimler[OyunYoneticisi.acikResimler.ElementAt(1)].Tag)) {
                    OyunYoneticisi.bulunanEsSayisi++;

                    for(int i = 0; i<2; i++) {
                        boxes[OyunYoneticisi.acikResimler.ElementAt(i)].Visible=false;
                    }
                } else {
                    for(int i = 0; i<2; i++) {
                        boxes[OyunYoneticisi.acikResimler.ElementAt(i)].Image=OyunYoneticisi.varsayilanResim;
                    }
                }
                OyunYoneticisi.acikResimler.RemoveRange(0, 2);
            }
            label2.Text=OyunYoneticisi.acilanResimSayisi.ToString();
            label1.Text=OyunYoneticisi.bulunanEsSayisi.ToString();
        }

        private void Timer1_Tick(object sender, EventArgs e) {

            ResimKontrol();
            panel1.Enabled=true;
            timer1.Stop();
        }

        private void KartlariGoster_Tick(object sender, EventArgs e) {
            panel1.Enabled=true;
            timer1.Stop();
        }
    }
}
