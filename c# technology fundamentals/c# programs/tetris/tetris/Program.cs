using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace tetris
{
    class Program
    {
        static int TetrisRows = 20;
        static int TetrisCols = 10;
        static int InfoCols = 10;
        static int ConsoleRows = 1 + TetrisRows + 1;
        static int ConsoleCols = 1 + TetrisCols + 1 + InfoCols + 1;
        static int FramesToMoveFigure = 15;

        static List<bool[,]> TetrisFigures = new List<bool[,]>
        {
            new bool[,] //O
            {
            {true, true},
            {true, true},
            },

            new bool[,]
            {                           //S
            {false, true, true },
            {true, true, false },
            },
            new bool[,]
            {                           //Z
            {true, true, false },
            {false, true, true },
            },
            new bool[,]
            {                           //J
            {true, false, false },
            {true, true, true },
            },
            new bool[,]
            {                           //L
            {false, false, true },
            {true, true, true },
            },
            new bool[,]
            {                           //T
            {false, true, false },
            {true, true, true },
            },
            new bool[,]
            { { true, true, true, true } }//I
        };
        
        static void DrawCurrentFigure()
        {
            //
        }

        //wtf is static for? for now always use it
        static void MyMethod()
        {
            Console.Title = "Dedris :DD";
        }

        static void write(string text, int row = 0, int col = 0, ConsoleColor color = ConsoleColor.Yellow)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(col, row);
            Console.Write(text);
            Console.ResetColor();
        }

        static void drawBorders()
        {
            string line = "+";
            Console.Write(line);
            for (int i = 0; i < TetrisCols; i++)
                Console.Write("-");
            Console.Write(line);
            for (int i = 0; i < InfoCols; i++)
                Console.Write("-");
            Console.Write(line+'\n');
            string colsym = "|";
            for (int i = 0; i < TetrisRows; i++)
            {
                string middleline = colsym + new string(' ', TetrisCols);
                middleline += colsym + new string(' ', InfoCols) + colsym;
                Console.WriteLine(middleline);
            }
            Console.Write(line);
            for (int i = 0; i < TetrisCols; i++)
                Console.Write("-");
            Console.Write(line);
            for (int i = 0; i < InfoCols; i++)
                Console.Write("-");
            Console.Write(line);
        }

        static void writeScore(int score)
        {
            write("Score:", 1, 13);
            string sc = score.ToString();
            write(sc, 2, 13);
        }

        static void drawinfo()
        {

        }

        static void Main(string[] args)
        {
            Console.WindowHeight = (int)(ConsoleRows*1.5);
            Console.WindowWidth = ConsoleCols*2;
            Console.BufferHeight = (int)(ConsoleRows*1.5);
            Console.BufferWidth = ConsoleCols*2;
            Console.CursorVisible = false;
            MyMethod();
            drawBorders();
            int score = 0;

            while (true)
            {
                score++;
                writeScore(score);
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    if(key.Key == ConsoleKey.X) break ;
                    if (key.Key == ConsoleKey.A) score -= 100;
                    if (key.Key == ConsoleKey.Spacebar || key.Key == ConsoleKey.W) ; //TODO: spacebar figure rotation
                    if (key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.A) ;
                    if (key.Key == ConsoleKey.RightArrow || key.Key == ConsoleKey.D) ;
                    if (key.Key == ConsoleKey.DownArrow || key.Key == ConsoleKey.S) ;
                }

                //update the game state
                score++;
                if (collison())
                {
                    AdCurrentFigureToTetrisField();
                    Checkforcollision();

                }

                //redraw UI
                drawBorders();

                frame++;
                Thread.Sleep(41);

            }
            Console.ReadKey();
        }
    }
}
