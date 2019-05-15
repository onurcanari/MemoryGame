using EslestirmeOyunu.Properties;
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
            ResimleriOluştur();
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
        private void ResimleriOluştur() {
            int j = 0;
            for(int i = 0; i<resimler.Length; i++) {
                resimler[i]=Resources.ResourceManager.GetObject("_"+j) as Image;
                resimler[i].Tag=j++;
                if(j==10) j=0;
            }
            varsayilanResim=Resources.varsayilan;
            varsayilanResim.Tag=-1;
        }
    }
}
