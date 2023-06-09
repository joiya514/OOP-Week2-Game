﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2Game.BL;
using EZInput;
using System.Threading;

namespace Week2Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int scores = 0;
            char[,] maze = new char[,] {
                { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', '#', '#', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#',}
            };

            char[,] player = new char[,]
            {
                {' ', '^', ' ' },
                {'<', '@', '>' },
                {'|', ' ', '|'}
            };

            char[,] enemy1 = new char[,]
            {
                {' ', '-', '-', '-'},
                {'<', '=', '=', '|'},
                {' ', '|', '@', '}'}
            };
            printMaze(maze);
            player P = new player();
            enemy1 E1 = new enemy1();
            E1Bullets BE1 = new E1Bullets();
            string directionE1 = "Up";
            BE1.bulletX = E1.E1x - 1;
            BE1.bulletY = E1.E1y + 1;
            List<int> bulletsX = new List<int>();
            List<int> bulletsY = new List<int>();
            while (true)
            {
                if (directionE1 == "Up")
                {
                    if (maze[E1.E1y - 1, E1.E1x] != ' ')
                    {
                        directionE1 = "Down";
                    }
                    else
                    {
                        enemy1Up(ref E1.E1x, ref E1.E1y);
                    }
                }
                if (directionE1 == "Down")
                {
                    enemy1Down(ref E1.E1x, ref E1.E1y);
                    if (maze[E1.E1y + 3, E1.E1x] != ' ')
                    {
                        directionE1 = "Up";
                    }
                }


                //gotoxy(E1.E1x - 1, E1.E1y + 1);
                //Console.Write("<");
                BE1.bulletX = E1.E1x - 1;
                BE1.bulletY = E1.E1y + 1;
                bulletsX.Add(BE1.bulletX);
                bulletsY.Add(BE1.bulletY);
                moveEnemy1Bullets(ref bulletsX, ref bulletsY, ref BE1.bulletX, ref BE1.bulletY, maze);



                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    if (maze[P.Py, P.Px + 3] == ' ' && maze[P.Py + 1, P.Px + 3] == ' ' && maze[P.Py + 2, P.Px + 3] == ' ')
                    {
                        removePlayer(maze, P.Px, P.Py);
                        P.Px++;
                    }
                }

                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    if (maze[P.Py, P.Px - 1] == ' ' && maze[P.Py + 1, P.Px - 1] == ' ' && maze[P.Py + 2, P.Px - 1] == ' ')
                    {
                        removePlayer(maze, P.Px, P.Py);
                        P.Px--;
                    }
                }
                if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    if (maze[P.Py - 1, P.Px] == ' ' && maze[P.Py - 1, P.Px + 1] == ' ' && maze[P.Py - 1, P.Px + 2] == ' ')
                    {
                        removePlayer(maze, P.Px, P.Py);
                        P.Py--;
                    }
                }
                if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    if (maze[P.Py + 3, P.Px] == ' ' && maze[P.Py + 3, P.Px + 1] == ' ' && maze[P.Py + 3, P.Px + 2] == ' ')
                    {
                        removePlayer(maze, P.Px, P.Py);
                        P.Py++;
                    }
                }

                printPlayer(player, P.Px, P.Py);
                printEnemy1(enemy1, E1.E1x, E1.E1y);
                gotoxy(70, 20);
                Console.WriteLine("Score: " + scores);
                Thread.Sleep(200);
            }
        }
        static void printMaze(char[,] maze)
        {
            for (int x = 0; x < maze.GetLength(0); x++)
            {
                for (int y = 0; y < maze.GetLength(1); y++)
                {
                    Console.Write(maze[x, y]);
                }
                Console.WriteLine();
            }
        }
        static void gotoxy(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }

        static void printPlayer(char[,] player, int playerx, int playery)
        {
            for (int x = 0; x < 3; x++)
            {
                gotoxy(playerx, playery);
                for (int y = 0; y < 3; y++)
                {
                    Console.Write(player[x, y]);
                }
                playery++;
            }
        }

        static void removePlayer(char[,] player, int playerx, int playery)
        {
            for (int x = 0; x < 3; x++)
            {
                gotoxy(playerx, playery);
                for (int y = 0; y < 3; y++)
                {
                    Console.Write(" ");
                }
                playery++;
            }
        }

        static void printEnemy1(char[,] enemy1, int enemy1x, int enemy1y)
        {
            for (int x = 0; x < 3; x++)
            {
                gotoxy(enemy1x, enemy1y);
                for (int y = 0; y < 4; y++)
                {
                    Console.Write(enemy1[x, y]);
                }
                enemy1y++;
            }
        }

        static void enemy1Up(ref int enemy1x, ref int enemy1y)
        {
            gotoxy(enemy1x, enemy1y);
            removeEnemy1( enemy1x,  enemy1y);
            enemy1y--;
        }
        static void enemy1Down(ref int enemy1x, ref int enemy1y)
        {
            gotoxy(enemy1x, enemy1y);
            removeEnemy1( enemy1x,  enemy1y);
            enemy1y++;
        }

        static void removeEnemy1( int enemy1x, int enemy1y)
        {
            for (int x = 0; x < 3; x++)
            {
                gotoxy(enemy1x, enemy1y);
                for (int y = 0; y < 4; y++)
                {
                    Console.Write(" ");
                }
                enemy1y++;
            }
        }

        static void moveEnemy1Bullets(ref List<int> BulletsX, ref List<int> BulletsY, ref int bulletx, ref int bullety, char[,] maze)
        {
                for (int x = 0; x < BulletsX.Count; x++)
                {
                if (maze[BulletsY[x], BulletsX[x] - 1] == ' ')
                {
                    if (BulletsX[x] > 0)
                    {
                        gotoxy(BulletsX[x], BulletsY[x]);
                        Console.Write(" ");
                        BulletsX[x]--;
                    }
                }
                }
                for (int x = 0; x < BulletsX.Count; x++)
                {
                  if (BulletsX[x] > 0)
                  {
                    if (maze[BulletsY[x], BulletsX[x]] == ' ')
                    {
                        gotoxy(BulletsX[x], BulletsY[x]);
                        Console.Write("<");
                    }
                    else
                    {
                        gotoxy(BulletsX[x] - 1, BulletsY[x]);
                        Console.Write(" ");
                    }
                }
                }
            Thread.Sleep(1);
        }
    }
}
