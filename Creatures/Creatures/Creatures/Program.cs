using System;

namespace Creatures
{
#if WINDOWS || XBOX
    static class Program
    {

        //The game
        public static Game1 game = null;
        //The windowed form
        public static MainForm mainForm1 = null;

        //[STAThread]
        static void Main(string[] args)
        {
            //Nice UI
            System.Windows.Forms.Application.EnableVisualStyles();

            //Form for Windowed mode
            mainForm1 = new MainForm();
            mainForm1.Show();

            //The main Game
            game = new Game1(mainForm1.getDrawSurface());
            game.Run();
        }

    }
#endif
}

