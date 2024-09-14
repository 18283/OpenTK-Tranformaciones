using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Objeto
    {
        public Punto centro { get; set; }
        public IDictionary<string, Parte> listaDeParte { get; set; }

        public Objeto()
        {
            centro= new Punto();
            listaDeParte= new Dictionary<string, Parte>();
        }

        public void SetCentro(Punto c)
        {
            centro = c;
        }

        public Punto GetCentro()
        {
            return centro;
        }

        public void AnadirParte(string clave, Parte valor)
        {
            listaDeParte.Add(clave, valor);
            centro = Centro();
        }

        public Punto Centro()
        {
            Punto p = new Punto();
            float sumX = 0;
            float sumY = 0;
            float sumZ = 0;

            foreach (var parte in listaDeParte)
            {
                var centroParte = parte.Value.Centro();
                sumX += centroParte.x;
                sumY += centroParte.y;
                sumZ += centroParte.z;
            }

            // Promedio de los centros de las partes
            if (listaDeParte.Count > 0)
            {
                p.Set(sumX / listaDeParte.Count,
                    sumY / listaDeParte.Count,
                    sumZ / listaDeParte.Count) ;
            }

            return p;
        }

        public void trasladar(float trasladarX, float trasladarY, float trasladarZ)
        {

            foreach (var punto in listaDeParte)
            {
                punto.Value.trasladar(trasladarX, trasladarY, trasladarZ);
            }
        }

        public void escalar(float valorDeEscalar)
        {

            foreach (var punto in listaDeParte)
            {
                punto.Value.SetCentro(centro);
                punto.Value.escalar(valorDeEscalar);
            }
        }

        public void rotar(float anguloX, float anguloY, float anguloZ)
        {
            foreach (var punto in listaDeParte)
            {
                punto.Value.rotar(anguloX, anguloY, anguloZ);
            }
        }

        public void Dibujar()
        {
            //realizar suma de centros
            foreach (var item in listaDeParte)
            {
                item.Value.SetCentro(centro);
                item.Value.Dibujar();
            }
        }
    }
}
