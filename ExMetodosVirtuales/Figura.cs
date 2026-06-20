using System;
using System.Drawing;

namespace Figuras
{
    public class Figura
    {
        public Color Color { get; set; } = Color.Black;
        public virtual void Dibujar(Pen pen, Graphics graphics, int x, int y)
        { 
        
        }

        public virtual void escalarMedidas(int muliplicador)
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

        public override void escalarMedidas(int multiplicador)
        {
            alto = alto * multiplicador;
            ancho = ancho * multiplicador;
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

        public override void escalarMedidas(int multiplicador)
        {
            radio = radio * multiplicador;
        }
    }

    public class TrianguloEquilatero : Figura
    {
        protected float lado;
        
        // Constructor
        public TrianguloEquilatero(float lado) 
        {
            this.lado = lado;
        }

        public override void Dibujar(Pen pen, Graphics graphics, int x, int y)
        {
            PointF[] points = new PointF[3]
            { 
                new PointF(x, y), 
                new PointF(x+lado, y), 
                new PointF(x+ (lado / 2f), y + (float)(0.866 * lado)), 
            };
            // DrawPolygon dibuja un poligono dado un conjunto de puntos y un lapiz
            graphics.DrawPolygon(pen, points);
        }

        public override void escalarMedidas(int multiplicador)
        {
            lado = lado * multiplicador;
        }
    }

    public class TrianguloIsoceles : Figura
    {
        protected float lado;
        protected float altura;
        
        // Constructor
        public TrianguloIsoceles(float lado, float altura) 
        {
            this.lado = lado;
            this.altura = altura;
        }

        public override void Dibujar(Pen pen, Graphics graphics, int x, int y)
        {
            PointF[] points = new PointF[3]
            { 
                new PointF(x, y), 
                new PointF(x+lado, y), 
                new PointF(x+ (lado / 2f), y + altura), 
            };
            // DrawPolygon dibuja un poligono dado un conjunto de puntos y un lapiz
            graphics.DrawPolygon(pen, points);
        }

        public override void escalarMedidas(int multiplicador)
        {
            lado = lado * multiplicador;
            altura = altura * multiplicador;
        }
    }
}
