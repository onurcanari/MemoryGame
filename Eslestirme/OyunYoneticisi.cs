using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eslestirme
{
    class OyunYoneticisi
    {
        public static List<int> acikResimler;
        public static Image varsayilanResim;
        public static Image[] resimler;
        public static int acilanResimSayisi { get; set; }
        public static int bulunanEsSayisi { get; set; }

        public OyunYoneticisi() {
            resimler=new Image[20];
            acikResimler = new List<int>(2);
            string[] path = Directory.GetFiles(@"resimler/", "*.png");
            for(int i = 0; i<resimler.Length; i++) 
                resimler[i]=Image.FromFile(path[i]);
            varsayilanResim=Image.FromFile(@"resimler/varsayilan.png");
            varsayilanResim.Tag=-1;
            ResimleriNumaralandir();
        }
        public void YeniOyun()
        {
            ResimleriKaristir();
            acilanResimSayisi=0;
            bulunanEsSayisi=0;
            acikResimler=new List<int>(2);
        }
        // Resimleri karıştırır
        private void ResimleriKaristir() {
            Random rnd = new Random();
            Image temp;
            int rndSayi;
            string tagTemp;
            for(int i = 0; i<resimler.Length; i++) {
                rndSayi=rnd.Next(resimler.Length-1);

                temp=resimler[i];
                tagTemp=resimler[i].Tag.ToString();

                resimler[i] = resimler[rndSayi];
                resimler[i].Tag =resimler[rndSayi].Tag;

                resimler[rndSayi] = temp;
                resimler[rndSayi].Tag = tagTemp;
            }
        }

        // tıklanan resmi açar. Açık olan resim sayısı 2 ise resimleri kontrol eder.
        // Eğer aynı değillerse resimleri kapatır.

        private void ResimleriNumaralandir() {
            int j = 1;
            for(int i = 0; i<resimler.Length; i+=2) {
                resimler[i].Tag=j++;
            }
            j=1;
            for(int i = 1; i<resimler.Length; i+=2) {
                resimler[i].Tag=j++;
            }
        }
    }
}
