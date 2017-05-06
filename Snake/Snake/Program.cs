using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            //Размер окна приложения
            Console.SetBufferSize(80, 25);

            //Отрисовка рамочки
            Walls walls = new Walls(80,25);
            walls.Draw();

            //Отрисовка точек
            Point p = new Point(7,10,'O');
            Snake snake = new Snake(p,4,Direction.RIGHT);
            snake.Draw();

            //Отрисовка еды
            FoodCreator foodCreator = new FoodCreator(80, 25, '#');
            Point food = foodCreator.CreateFood();
            food.Draw();

            
            while (true)
            {
                //Взаимодействие змейки с хвостом и стенками
                if (walls.IsHit(snake) || snake.IsHitTale())
                {
                    Console.SetCursorPosition(35,12);
                    Console.WriteLine("GAME OVER");
                    Console.ReadKey();
                    break;
                }

                // Взаимодействие змейки с едой
                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                }
                else
                    snake.Move();

                Thread.Sleep(100);

                //Управление змейкой
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.Hendling(key.Key);
                }
                
            }
        }
    }
}
