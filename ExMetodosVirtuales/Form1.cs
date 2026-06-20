using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Figuras
{
    public partial class Form1 : Form
    {
        Figura[] figuras;
        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
            figuras = new Figura[5] 
            {
                new TrianguloEquilatero(45),
                new TrianguloIsoceles(30, 50),
                new Circulo(60),
                new Rectangulo(30,50),
                new Cuadrado(45)
            };
            figuras[0].Color = this.colorAleatorio();
            figuras[1].Color = this.colorAleatorio();
            figuras[2].Color = this.colorAleatorio();
            figuras[3].Color = this.colorAleatorio();
            figuras[4].Color = this.colorAleatorio();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics gr = pictureBox1.CreateGraphics();
            Pen pen = new Pen(Color.Red);
            for (int i = 0; i < figuras.Length; i++)
            {
                pen.Color = figuras[i].Color;
                figuras[i].escalarMedidas(i+1);
                figuras[i].Dibujar(pen,gr,i * 100, 50);
            }

        }

        private Color colorAleatorio()
        {
           int r, g, b;
           do
            {
                r = numeroAleatorioColor();
                g = numeroAleatorioColor();
                b = numeroAleatorioColor();
            } while (luminosidadWCAG(r, g, b) > 140); 
            return Color.FromArgb(r, g, b);
        }
        private int numeroAleatorioColor()
        {
            return rnd.Next(0, 256);
        }

        private double luminosidadWCAG(int R, int G, int B)
        {
            return (0.2126 * R) + (0.7152 * G) + (0.0722 * B); //<- Formula de Luminancia Relativa. Version simplificada de las norms WCAG
        }
    }
}
