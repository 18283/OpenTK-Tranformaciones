using OpenTK;
using OpenTK.Graphics;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp1
{
    public class Game: GameWindow
    {
        private Parte parte1;
        //private Poligono frente;


        public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title)
        {
            parte1 = new Parte();
            //frente = new Poligono();    

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(Color4.Black);
            GL.Enable(EnableCap.DepthTest);

            Serializador serializador = new Serializador();

            if (!File.Exists("figura3d.json"))
            {
                serializador.CrearYGuardar(); // Crear y guardar el objeto si no existe el archivo
            }

            Poligono objetoCargado = serializador.Cargar("figura3d.json");
            //parte.AnadirPoligono("objeto", objetoCargado);

            Punto a = new Punto();
            Punto b = new Punto();
            Punto c = new Punto();
            Punto d = new Punto();
            Punto a1 = new Punto();
            Punto b1 = new Punto();
            Punto c1 = new Punto();
            Punto d1 = new Punto();
            Punto f = new Punto();
            Punto g = new Punto();
            Punto h = new Punto();
            Punto i = new Punto();
            Punto f1 = new Punto();
            Punto g1 = new Punto();
            Punto h1 = new Punto();
            Punto i1 = new Punto();

            a.Set(-0.3f, 0.4f, 0.0f);
            b.Set(-0.3f, 0.2f, 0.0f);
            c.Set(0.3f, 0.2f, 0.0f);
            d.Set(0.3f, 0.4f, 0.0f);

            a1.Set(-0.3f, 0.4f, 0.2f);
            b1.Set(-0.3f, 0.2f, 0.2f);
            c1.Set(0.3f, 0.2f, 0.2f);
            d1.Set(0.3f, 0.4f, 0.2f);

            //abajo
            f.Set(-0.1f, 0.2f, 0.0f);
            g.Set(-0.1f, -0.3f, 0.0f);
            h.Set(0.1f, -0.3f, 0.0f);
            i.Set(0.1f, 0.2f, 0.0f);

            f1.Set(-0.1f, 0.2f, 0.2f);
            g1.Set(-0.1f, -0.3f, 0.2f);
            h1.Set(0.1f, -0.3f, 0.2f);
            i1.Set(0.1f, 0.2f, 0.2f);

            Poligono frente = new Poligono();
            frente.AnadirPunto("Punto1", a);
            frente.AnadirPunto("Punto2", b);
            frente.AnadirPunto("Punto3", c);
            frente.AnadirPunto("Punto4", d);


            Poligono atras = new Poligono();
            atras.AnadirPunto("Punto5", a1);
            atras.AnadirPunto("Punto6", b1);
            atras.AnadirPunto("Punto7", c1);
            atras.AnadirPunto("Punto8", d1);

            Poligono izquierda = new Poligono();
            izquierda.AnadirPunto("Punto9", a1);
            izquierda.AnadirPunto("Punto10", b1);
            izquierda.AnadirPunto("Punto11", b);
            izquierda.AnadirPunto("Punto12", a);

            Poligono derecha = new Poligono();
            derecha.AnadirPunto("Punto13", d1);
            derecha.AnadirPunto("Punto14", c1);
            derecha.AnadirPunto("Punto15", c);
            derecha.AnadirPunto("Punto16", d);

            Poligono frente2 = new Poligono();
            frente2.AnadirPunto("P1", f);
            frente2.AnadirPunto("P2", g);
            frente2.AnadirPunto("P3", h);
            frente2.AnadirPunto("P4", i);

            Poligono atras2 = new Poligono();
            atras2.AnadirPunto("P5", f1);
            atras2.AnadirPunto("P6", g1);
            atras2.AnadirPunto("P7", h1);
            atras2.AnadirPunto("P8", i1);

            Poligono izquierda2 = new Poligono();
            izquierda2.AnadirPunto("P9", f);
            izquierda2.AnadirPunto("P10", g);
            izquierda2.AnadirPunto("P11", g1);
            izquierda2.AnadirPunto("P12", f1);

            Poligono derecha2 = new Poligono();
            derecha2.AnadirPunto("P1", i);
            derecha2.AnadirPunto("P2", h);
            derecha2.AnadirPunto("P3", h1);
            derecha2.AnadirPunto("P4", i1);

            //Parte parte1 = new Parte();
            parte1.AnadirPoligono("c1", frente);
            parte1.AnadirPoligono("c2", atras);
            parte1.AnadirPoligono("c3", izquierda);
            parte1.AnadirPoligono("c4", derecha);



            //frente.Dibujar();
            //frente.trasladar(0.02f, 0.0f, 0.0f);
            //frente.escalar(1.9f); //aqui
            //parte1.escalar(1.9f);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            //GL.Rotate(1, 0.0, 0.1, 0.1);


            //frente.Dibujar();
            //frente.trasladar(0.0f, 0.0f, 0.0f);
            //frente.rotar(0, 0, 1);
            //Console.WriteLine(frente.GetCentro().ToString());

            //parte.Dibujar();
            parte1.Dibujar();
            parte1.rotar(1, 1, 0);
            //parte1.trasladar(0.001f, 0f, 0f);
            Console.WriteLine(parte1.GetCentro().ToString());



            Context.SwapBuffers();

        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, Width, Height);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            KeyboardState input = Keyboard.GetState();

            if (input.IsKeyDown(Key.Escape))
            {
                Exit();
            }
        }
    }
}
