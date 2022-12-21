using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Snek
{
    internal class Program
    {
        //creamos un enum con las direcciones posibles para el movimiento
        enum direction
        {
            Up,
            Down,
            Left,
            Right
        }

        //variables estaticas
        static bool playing = true;
        static direction dir = direction.Right;
        static List<Dot> Snek = new List<Dot>()
        {
            new Dot (10, 10)
        };

        static void Main(string[] args)
        {
            Console.Title = "Snek game by Paula F.";

            //creamos un thread para correr en paralelo el metodo DetectKeys mientras se ejecuta el metodo Move dentro del while
            Thread threadKeys = new Thread(DetectKeys);
            threadKeys.SetApartmentState(ApartmentState.STA);
            threadKeys.Start();

            //creamos comida como objetivo
            SpawnFood();

            while (playing)
            {
                Move();
                Thread.Sleep(100);
            }

            threadKeys.Abort();








        }

        //metodos
        private static void Move()
        {

            for (int i = 0; i < Snek.Count; i++)
            {
                //setteamos serpiente y limpiamos posicion anterior
                Console.SetCursorPosition(Snek[i].X, Snek[i].Y);
                Console.WriteLine(" ");

                //direcciones
                if (dir == direction.Up)
                {
                    Snek[i].Y -= 1;
                }
                else if (dir == direction.Down)
                {
                    Snek[i].Y += 1;
                }
                else if (dir == direction.Left)
                {
                    Snek[i].X -= 1;
                }
                else if (dir == direction.Right)
                {
                    Snek[i].X += 1;
                }

                //setteamos serpiente y dibujamos posicion actual
                Console.SetCursorPosition(Snek[i].X, Snek[i].Y);
                Console.WriteLine("0");

            }
        }

        private static void DetectKeys()
        {

            while (playing)
            {
                //realizamos la deteccion de las teclas apropiadas en relacion al movimiento
                //bloqueamos la posibilidad de movimiento de arriba a abajo y de izq a derecha
                if (dir != direction.Down && Keyboard.IsKeyDown(Key.Up))
                {
                    dir = direction.Up;
                }
                else if (dir != direction.Up && Keyboard.IsKeyDown(Key.Down))
                {
                    dir = direction.Down;
                }
                else if (dir != direction.Right && Keyboard.IsKeyDown(Key.Left))
                {
                    dir = direction.Left;
                }
                else if (dir != direction.Left && Keyboard.IsKeyDown(Key.Right))
                {
                    dir = direction.Right;
                }
            }
        }

        private static void SpawnFood()
        {




        }



    }
}
