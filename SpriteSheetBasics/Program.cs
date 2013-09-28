using System;

namespace SpriteSheetBasics
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (SpriteSheetBasicsGame game = new SpriteSheetBasicsGame())
            {
                game.Run();
            }
        }
    }
}

