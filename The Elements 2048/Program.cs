using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Elements_2048 {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main () {
            Application.EnableVisualStyles ();
            Application.SetCompatibleTextRenderingDefault (false);
            Application.Run (new GameWindow ());

            //var game = new Game();
            //game.SpawnNewElement();
            //game.SpawnNewElement();
            //Console.WriteLine(game);
            //while (true) {
            //    bool moved;
            //    var key = Console.ReadKey();
            //    Console.WriteLine();
            //    switch (key.Key) {
            //        case ConsoleKey.DownArrow:
            //            moved = game.MoveDown().HasMoved;
            //            break;
            //        case ConsoleKey.LeftArrow:
            //            moved = game.MoveLeft().HasMoved;
            //            break;
            //        case ConsoleKey.RightArrow:
            //            moved = game.MoveRight().HasMoved;
            //            break;
            //        case ConsoleKey.UpArrow:
            //            moved = game.MoveUp().HasMoved;
            //            break;
            //        default:
            //            moved = false;
            //            break;
            //    }
            //    if (moved) {
            //        game.SpawnNewElement();
            //    }
            //    Console.WriteLine(game);
            //}
        }
    }
}
