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
        }

        public void Dibujar()
        {
            //realizar suma de centros
            foreach (var item in listaDeParte)
            {
                item.Value.Dibujar();
            }
        }
    }
}
