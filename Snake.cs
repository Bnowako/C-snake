using System;
using System.Collections.Generic;
using System.Linq;

namespace Snake
{
    public class Snake
    {
        Random random = new Random();

        public List<byte> bodyX = new List<byte>();
        public List<byte> bodyY = new List<byte>();

        public byte headX;
        public byte headY;

        public byte fruitX;
        public byte fruitY;

        public byte gameBoardWidth = 50;
        public byte gameBoardHeight = 50;

        public byte snakeLength;
        public GameBoard gameboard;

        public char prevDirection = ' ';


        public Snake()

        {
            headX = 20;
            headY = 20;
            snakeLength = 3;
            bodyX.Add(20);
            bodyY.Add(20);
            drawFruit();
            gameboard = new GameBoard();

        }


        public void draw()
        {


            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(headX, headY);
            Console.Write("*");


            int index = bodyX.Count - 1 - snakeLength;

            if (index >= 0 && index <= bodyX.Count)
            {
                Console.SetCursorPosition(bodyX[index], bodyY[index]);
                Console.Write(" ");
            }
        }

        public void drawFruit()
        {


            fruitX = (byte) (random.Next(gameBoardWidth) + 1);
            fruitY = (byte) (random.Next(gameBoardHeight) + 1);

            Console.SetCursorPosition(fruitX, fruitY);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("@");
        }

        

        public void checkCollisions()
        {
            //boundaries
            if((headX == 50 || headY == 50) || (headX == 0 || headY == 0))
            {
                gameOver();
            }
            //body
            int index = bodyX.Count - 1 - snakeLength;
            if (index >= 0 && index <= bodyX.Count)
            {
                for (int i = 0; i < snakeLength; i++)
                {
                    if (headX == bodyX[index + i] && headY == bodyY[index + i])
                    {
                        gameOver();
                    }
                }
            }
            //fruit

            if(headX == fruitX && headY == fruitY)
            {
                snakeLength += 1;
                drawFruit();
            }


        }

        public void gameOver()
        {
            headX = 20;
            headY = 20;
            snakeLength = 3;
            bodyX = new List<byte>();
            bodyY = new List<byte>();
            bodyX.Add(20);
            bodyY.Add(20);
            prevDirection = ' ';
            Console.Clear();
            gameboard.drawGameBoard();
            drawFruit();
        }


        public byte move(char direction)
        {
            
            if (direction == 'U' && prevDirection == 'D')
            {
                direction = prevDirection;
            }
            else if (direction == 'D' && prevDirection == 'U')
            {
                direction = prevDirection;
            }
            else if (direction == 'L' && prevDirection == 'R')
            {
                direction = prevDirection;
            }
            else if (direction == 'R' && prevDirection == 'L')
            {
                direction = prevDirection;
            }


            switch (direction)
            {
                case 'U':
                    headY -= 1;
                    prevDirection = direction;
                    break;
                case 'D':
                    headY += 1;
                    prevDirection = direction;
                    break;
                case 'L':
                    headX -= 1;
                    prevDirection = direction;
                    break;
                case 'R':
                    headX += 1;
                    prevDirection = direction;
                    break;
            }


            

            bodyX.Add(headX);
            bodyY.Add(headY);
            return snakeLength;
        }


    }
}
