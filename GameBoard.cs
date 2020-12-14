using System;
namespace Snake
{
    public class GameBoard
    {

        public byte gameBoardWidth;
        public byte gameBoardHeight;

        public GameBoard()
        {
            gameBoardWidth = 50;
            gameBoardHeight = 50;

        }

        public void drawGameBoard()
        {
            // upper
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < gameBoardWidth; i++)
            {
                Console.Write("#");
            }
            // down
            Console.SetCursorPosition(0, gameBoardHeight);
            for (int i = 0; i < gameBoardWidth; i++)
            {
                Console.Write("#");
            }
            //left
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i <= gameBoardHeight; i++)
            {
                Console.Write("#");
                Console.SetCursorPosition(0, i);
            }
            //right
            Console.SetCursorPosition(gameBoardWidth, 0);
            for (int i = 0; i <= gameBoardHeight; i++)
            {
                Console.Write("#");
                Console.SetCursorPosition(gameBoardWidth, i);
            }



        }
    }
}
