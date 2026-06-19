using System;
using System.Drawing;

namespace Figuras
{
    public class Figura
    {
        public virtual void Dibujar(Pen pen, Graphics graphics, int x, int y)
        { 
            
        }
    }


    public class Rectangulo : Figura
    {
        protected int alto;
        protected int ancho;
        
        // Constructor
        public Rectangulo(int ancho, int alto) 
        {
            this.ancho = ancho;
            this.alto = alto;
        }

        public override void Dibujar(Pen pen, Graphics graphics, int x, int y)
        {
            Point[] points = new Point[4]
            { 
                new Point(x,y), 
                new Point(x+ancho,y), 
                new Point(x+ancho,y+alto), 
                new Point(x,y+alto) 
            };
            // DrawPolygon dibuja un poligono dado un conjunto de puntos y un lapiz
            graphics.DrawPolygon(pen, points);
        }
    }

    public class Cuadrado : Rectangulo
    {
        // Constructor. Un cuadrado es un rectangulo con ancho = alto
        public Cuadrado(int lado) : base(lado,lado)
        {
        }
    }


    public class Circulo : Figura
    {
        private int radio;

        // Constructor
        public Circulo(int radio)
        {
            this.radio= radio;
        }

        public override void Dibujar(Pen pen, Graphics graphics, int x, int y)
        {
            graphics.DrawEllipse(pen,x,y, radio, radio);
        }
    }
}
