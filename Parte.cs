using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static OpenTK.Graphics.OpenGL.GL;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp1
{
    internal class Parte
    {
        public Punto centro { get; set; }
        public IDictionary<string, Poligono> listaDePoligono { get; set; }

        public Parte()
        {
            centro=new Punto();
            listaDePoligono = new Dictionary<string, Poligono>();
        }

        public void SetCentro(Punto c)
        {
            centro = c;
        }

        public Punto GetCentro()
        {
            return centro;
        }

        public void AnadirPoligono(string clave, Poligono valor)
        {
            listaDePoligono.Add(clave, valor);
            centro=Centro();
        }

        public Punto Centro()
        {
            Punto p=new Punto();
            float sumx = 0;
            float sumy = 0;
            float sumz = 0;

            foreach (var item in listaDePoligono)
            {
                centro = item.Value.GetCentro();
                sumx=sumx+centro.x; 
                sumy=sumy+centro.y;
                sumz=sumz+centro.z;
            }

            float PromX=sumx/listaDePoligono.Count;
            float PromY=sumy/listaDePoligono.Count;
            float PromZ=sumz/listaDePoligono.Count;

            p.Set(PromX, PromY, PromZ);
            return p;

        }

        public void trasladar(float trasladarX, float trasladarY, float trasladarZ)
        {
            
            foreach (var punto in listaDePoligono)
            {
                punto.Value.trasladar(trasladarX, trasladarY, trasladarZ);
            }
        }

        public void escalar(float valorDeEscalar)
        {

            foreach (var punto in listaDePoligono)
            {
                punto.Value.SetCentro(centro);
                punto.Value.escalar(valorDeEscalar);
            }
        }

        public void rotar(float anguloX, float anguloY, float anguloZ)
        {
            foreach (var punto in listaDePoligono)
            {
                punto.Value.rotar(anguloX, anguloY, anguloZ);
            }
        }

        public void Dibujar()
        {
            foreach (var item in listaDePoligono)
            {
                item.Value.SetCentro(centro);
                item.Value.Dibujar();
            }
        }
    }
}
