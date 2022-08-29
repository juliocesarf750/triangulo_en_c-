using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System.Runtime;

namespace triangulo_hola_mundo
{
    class program
    {
        static void Main(string[] args)
        {

            using (game Game = new game()) {

                
                Game.Run();
            }

        }
    }
}
