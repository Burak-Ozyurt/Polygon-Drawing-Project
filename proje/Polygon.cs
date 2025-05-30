//******************************************************************
//**                                                              **
//**         STUDENT NAME : MUHAMMET BURAK ÖZYURT                 **
//**         STUDENT NUMBER: B231202062                           **
//**                                                              **
//******************************************************************

using b231202062;
using System;                         //matematiksel işlemler için
using System.Collections.Generic;     //list kullanmak için

namespace b231202062
{
    public class Polygon
    {
        private Point2D _center;        //merkez
        private int _length;            //uzunluk
        private ColorRGB _color;        //renk
        private int _numberOfEdges;     //kenar sayısı
        private List<Point2D> _vertices; //köşe noktaları

        public Point2D Center
        {
            get { return _center; }
            set { _center = value; }
        }

        public int Length
        {
            get { return _length; }
            set { _length = Math.Max(3, Math.Min(9, value)); } //uzunluk min3 max9 olmalı   
        }

        public ColorRGB Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public int NumberOfEdges
        {
            get { return _numberOfEdges; }
            set { _numberOfEdges = Math.Max(3, Math.Min(10, value)); } //kenar sayısı min3 max10 olmalı
        }

        public List<Point2D> Vertices
        {
            get { return _vertices; }
        }

        public Polygon()
        {
            _center = new Point2D();
            _length = 4;                          //başlangıçta uzunuk 4  kenar sayısı 5
            _color = new ColorRGB();
            _numberOfEdges = 5;
            _vertices = new List<Point2D>();
        }

        public Polygon(Point2D center, int length)
        {
            _center = center;
            _length = length;
            _color = new ColorRGB();
            _numberOfEdges = 5;
            _vertices = new List<Point2D>();
        }

        public Polygon(Point2D center, int length, ColorRGB color, int numberOfEdges)
        {
            _center = center;
            Length = length;
            _color = color;
            NumberOfEdges = numberOfEdges;
            _vertices = new List<Point2D>();     //köşe noktalarını listeye atar
        }

        public void CalculateEdgeCoordinates()
        {
            _vertices.Clear();                  //varolan köşe nokraları temizlenir
            double radius = _length;            //yarıçap lenghte atanır

            for (int i = 0; i < _numberOfEdges; i++)
            {
                double angle = 360.0 / _numberOfEdges * i;             //köşe noktaları eşit açılarla yerleştirilir
                Point2D vertex = Point2D.CalculateCartesianCoordinates(radius, angle);
                vertex.X += _center.X;
                vertex.Y += _center.Y;
                _vertices.Add(vertex);       //listeye eklenir
            }
        }
        public void RotatePolygon(double angle, bool counterClockwise = false)
        {
            if (_vertices.Count == 0)
            {                                      //köşeleri hesaplar(hesaplanmamışsa)
                CalculateEdgeCoordinates();
            }

            if (counterClockwise)
            {
                angle = -angle;                 //saat yönünün tersiyse açı negatif olur
            }

            List<Point2D> rotatedVertices = new List<Point2D>();

            foreach (Point2D vertex in _vertices)
            {
                double x = vertex.X - _center.X;
                double y = vertex.Y - _center.Y;

                double angleRad = angle * Math.PI / 180;    //açı radyana çevrilir

                double rotatedX = x * Math.Cos(angleRad) - y * Math.Sin(angleRad);   //noktaları döndüdrür
                double rotatedY = x * Math.Sin(angleRad) + y * Math.Cos(angleRad);

                rotatedX += _center.X;                              //noktalar merkeze taşınıe
                rotatedY += _center.Y;

                rotatedVertices.Add(new Point2D(rotatedX, rotatedY));     //listeye eklenir
            }

            _vertices = rotatedVertices;          //listeyi günceller
        }
    }
}