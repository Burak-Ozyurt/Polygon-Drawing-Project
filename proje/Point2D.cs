//******************************************************************
//**                                                              **
//**         STUDENT NAME : MUHAMMET BURAK ÖZYURT                 **
//**         STUDENT NUMBER: B231202062                           **
//**                                                              **
//******************************************************************

using System;

namespace b231202062
{
    public class Point2D
    {
        private double _x;
        private double _y;

        public double X
        {
            get { return _x; }               //x değeri dışarıdan değiştirilebilir
            set { _x = value; }
        }

        public double Y
        {
            get { return _y; }              //y değeri dışarıdan değiştirilebilir
            set { _y = value; }
        }

        public Point2D()
        {
            _x = 0;                        //nokta orijinde(0,0)
            _y = 0;
        }

        public Point2D(Random random, int minRange = 0, int maxRange = 3)   
        {
            _x = random.Next(minRange, maxRange + 1);    //min0 max3 olacak şekilde random
            _y = random.Next(minRange, maxRange + 1);
        }

        public Point2D(double x, double y)
        {
            _x = x;                                       //x noktası oluşturulur
            _y = y;                                       //y noktası oluşturulur
        }
        public string PrintCoordinates()
        {
            return $"({_x}, {_y})";            //noktayı x,y biçiminde gösterir
        }
        public (double r, double theta) CalculatePolarCoordinates()
        {
            double r = Math.Sqrt(_x * _x + _y * _y);       //hipotenüs hesaplanır
            double theta = Math.Atan2(_y, _x);             //açı bulunur

            theta = theta * 180 / Math.PI;                 //açı deereceye çevirilir

            if (theta < 0)                               //negatifse pozitife çevrilir 
                theta += 360;

            return (r, theta);
        }
        public static Point2D CalculateCartesianCoordinates(double r, double theta)
        {
            double thetaRadians = theta * Math.PI / 180;   //açıyı radyana çevirir
            double x = r * Math.Cos(thetaRadians);         //x değeri bulunur
            double y = r * Math.Sin(thetaRadians);         //y değeri bulunur

            return new Point2D(x, y);
        }
        public string PrintPolarCoordinates()
        {
            var polarCoords = CalculatePolarCoordinates();
            return $"(r={polarCoords.r:F2}, θ={polarCoords.theta:F2}°)";   //F2 ==> virgülden sonra 2 basamak gösterir
        }
    }
}