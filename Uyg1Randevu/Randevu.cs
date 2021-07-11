using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Uyg1Randevu
{
    class Randevu
    {
        static string dosyaYolu = @"randevu.txt";//@:escape karakteri
        public static void Ekle(string satir)
        {
                StreamWriter yazmaNesnesi=yazmaNesnesi= new StreamWriter(dosyaYolu, true);
                yazmaNesnesi.WriteLine(satir);
                MessageBox.Show("Eklendi");
                yazmaNesnesi.Close();
 
        }

        public static string tumRandevular()
        {
            StreamReader okumaNesnesi = new StreamReader(dosyaYolu);
            //string icerik = okumaNesnesi.ReadToEnd();
            string icerik = "";
            while (okumaNesnesi.EndOfStream == false)
            {
                icerik += okumaNesnesi.ReadLine()+Environment.NewLine;
            }
            okumaNesnesi.Close();
            return icerik;

        }

        public static bool RandevuVarMi(string kimlik,string bolum,string tarih, string saat)
        {
            StreamReader okumaNesnesi = new StreamReader(dosyaYolu);
            string satir = "";
            bool sonuc = false;
            while (okumaNesnesi.EndOfStream == false&&sonuc==false)
            {
                satir = okumaNesnesi.ReadLine();
                string[] parcalar = satir.Split('*');
                if ((parcalar[3] == bolum) && (parcalar[4] == tarih) && (parcalar[5] == saat))
                    sonuc = true;
                if ((parcalar[0] == kimlik) && (parcalar[3] == bolum) && (parcalar[4] == tarih))
                    sonuc = true;
            }
            okumaNesnesi.Close();
            return sonuc;
        }
    }
}
