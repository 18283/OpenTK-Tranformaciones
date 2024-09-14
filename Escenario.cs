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
        }

        public void Dibujar()
        {
            foreach (var item in listaDeObjeto)
            {
                item.Value.Dibujar();
            }
        }
    }
}
