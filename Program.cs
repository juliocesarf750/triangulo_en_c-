using System;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System.Windows.Input;

namespace triangulo_hola_mundo
{
    class program
    {

        static void Main(string[] args)
        {

            using (game Game = new game()) {

                int i = 0;
                int playerX = 0;
                Game.UpdateFrame += (FrameEventArgs args) => {
                    playerX += 1;
                    Console.WriteLine($"{playerX}");
                
                }; 
                
                Game.Run();
                

            }


        }
    }
}
