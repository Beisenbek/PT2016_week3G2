﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example3.Models
{
    public class Game
    {
        public static bool isActive;
        public static Snake snake;
        public static Food food;
        public static Wall wall;

        public static void Init()
        {
            isActive = true;
            snake = new Snake();
            food = new Food();
            wall = new Wall();

            snake.body.Add(new Point { x = 20, y = 20 });
            food.body.Add(new Point { x = 10, y = 20 });

            food.color = ConsoleColor.Green;
            wall.color = ConsoleColor.White;
            snake.color = ConsoleColor.Yellow;

            Console.SetWindowSize(48, 48);
        }

        public static void LoadlLevel(int level)
        {
            FileStream fs = new FileStream(string.Format(@"Levels\MapLevel{0}.txt",level),FileMode.Open,FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string line;
            int row = -1;
            int col = -1;

            while ((line = sr.ReadLine()) != null)
            {
                row++;
                col = -1;
                foreach(char c in line)
                {
                    col++;
                    if(c == '#')
                    {
                        wall.body.Add(new Point { x = col, y = row});
                    }
                }
            }

            sr.Close();
            fs.Close();
        }

        public static void Save()
        {
            wall.Save();
            snake.Save();
            food.Save();
        }

        public static void Resume()
        {
            wall.Resume();
            snake.Resume();
            food.Resume();
        }

        public static void Draw()
        {
            Console.Clear();
            snake.Draw();
            food.Draw();
            wall.Draw();
        }
    }
}
