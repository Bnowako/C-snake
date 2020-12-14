using System;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {

            GameBoard gameBoard = new GameBoard();
            Snake snake = new Snake();
            
            char direction = 'R';
            bool gameOn = true;
            double gameTickTime = 500;

            byte snakeLength = 3;
            bool speedAdded = false;

            DateTime prevDate = DateTime.Now;

            gameBoard.drawGameBoard();

            while (gameOn)
            {
                Console.CursorVisible = false;

                Console.ForegroundColor = ConsoleColor.White;
                snake.draw();

                if ((DateTime.Now - prevDate).TotalMilliseconds > gameTickTime)
                {
                    snakeLength = snake.move(direction);
                    prevDate = DateTime.Now;
                    snake.checkCollisions();
                    

                }

                // speed handling each 5 bodysegments + 5% speed up to 500%
                if ((snakeLength % 5) == 0 && gameTickTime > 100 && !speedAdded)
                {
                    gameTickTime -= 25;
                    speedAdded = true;
                }
                if(snakeLength%5 != 0)
                {
                    speedAdded = false;
                }


                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo input = Console.ReadKey();
                    Console.WriteLine(input.KeyChar);


                    switch (input.Key)
                    {
                        case ConsoleKey.Escape:
                            gameOn = false;
                            break;


                        case ConsoleKey.UpArrow:
                            if (direction != 'D' && direction != 'U')
                            {
                                direction = 'U';

                            }
                            break;
                        case ConsoleKey.DownArrow:
                            if (direction != 'U' && direction != 'D')
                            {
                                direction = 'D';


                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (direction != 'L' && direction != 'R')
                            {
                                direction = 'R';


                            }
                            break;
                        case ConsoleKey.LeftArrow:
                            if (direction != 'R' && direction != 'L')
                            {
                                direction = 'L';

                            }
                            break;

                    }



                }


            }


            }


        }
    }


