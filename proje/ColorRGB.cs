//******************************************************************
//**                                                              **
//**         STUDENT NAME : MUHAMMET BURAK ÖZYURT                 **
//**         STUDENT NUMBER: B231202062                           **
//**                                                              **
//******************************************************************

using System;
using System.Drawing;                //grafikle ilgili snıfları kullanmak için

namespace b231202062
{
    public class ColorRGB
    {
        private int _red;           //renk değişkenlerini tutar
        private int _green;
        private int _blue;

        public int Red
        {
            get { return _red; }
            set { _red = Math.Max(0, Math.Min(255, value)); } //0 ile 255 arası değer gir
        }

        public int Green
        {
            get { return _green; }
            set { _green = Math.Max(0, Math.Min(255, value)); } //0 ile 255 arası değer gir
        }

        public int Blue
        {
            get { return _blue; }
            set { _blue = Math.Max(0, Math.Min(255, value)); } //0 ile 255 arası değer gir
        }

        public ColorRGB()
        {
            _red = 0;            //başlangıçta 0 değeri alır
            _green = 0;
            _blue = 0;
        }

        public ColorRGB(Random random)
        {
            _red = random.Next(0, 256);      //0 ile 255 araıs random değer alır
            _green = random.Next(0, 256);
            _blue = random.Next(0, 256);
        }

        public ColorRGB(int red, int green, int blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }

        public Color ToColor()        //nesneyi grafik çizimine çevirmek için
        {
            return Color.FromArgb(_red, _green, _blue);
        }
    }
}