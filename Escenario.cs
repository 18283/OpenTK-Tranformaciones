using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Escenario
    {
        public Punto centro { get; set; }
        public IDictionary<string, Objeto> listaDeObjeto { get; set; }

        public Escenario()
        {
            centro = new Punto();
            listaDeObjeto = new Dictionary<string, Objeto>();
        }

        public void SetCentro(Punto c)
        {
            centro= c;
        }

        public Punto GetCentro()
        {
            return centro;
        }

        public void AnadirObjeto(string clave, Objeto valor)
        {
            listaDeObjeto.Add(clave, valor);
            centro = Centro();
        }

        public Punto Centro()
        {
            Punto p = new Punto();
            float sumX = 0;
            float sumY = 0;
            float sumZ = 0;

            foreach (var parte in listaDeObjeto)
            {
                var centroParte = parte.Value.Centro();
                sumX += centroParte.x;
                sumY += centroParte.y;
                sumZ += centroParte.z;
            }

            // Promedio de los centros de las partes
            if (listaDeObjeto.Count > 0)
            {
                p.Set(sumX / listaDeObjeto.Count,
                    sumY / listaDeObjeto.Count,
                    sumZ / listaDeObjeto.Count);
            }

            return p;
        }

        public void trasladar(float trasladarX, float trasladarY, float trasladarZ)
        {

            foreach (var punto in listaDeObjeto)
            {
                punto.Value.trasladar(trasladarX, trasladarY, trasladarZ);
            }
        }

        public void escalar(float valorDeEscalar)
        {

            foreach (var punto in listaDeObjeto)
            {
                punto.Value.SetCentro(centro);
                punto.Value.escalar(valorDeEscalar);
            }
        }

        public void rotar(float anguloX, float anguloY, float anguloZ)
        {
            foreach (var punto in listaDeObjeto)
            {
                punto.Value.rotar(anguloX, anguloY, anguloZ);
            }
        }

        public void Dibujar()
        {
            foreach (var item in listaDeObjeto)
            {
                item.Value.SetCentro(centro);
                item.Value.Dibujar();
            }
        }
    }
}
