using System;

namespace SpaceStationEstablishment
{
    class Program
    {
        public class Position
        {
            public int i;
            public int j;
            public Position(int i, int j)
            {
                this.i = i;
                this.j = j;
            }
        }
        static void PrintMatrx(char[,] matrix)
        {
            for(int i=0; i<matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++) Console.Write(matrix[i, j]);
                Console.WriteLine();
            }

        }

        static Position FindStephen(char[,] matrix)
        {
            Position pp = new Position(-1, -1);
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] == 'S') {pp = new Position(i, j); break; }
            return pp;
            
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] space = new char[n, n];
            for(int i=0; i<n; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < n; j++) space[i, j] = input[j];
            }
            bool inTheVoid = false;
            string command = "";
            Position playerPosition = FindStephen(space);
            int StarPower = 0;
            while (!inTheVoid && StarPower<50)
            {
                command = Console.ReadLine();
                Position nextPosition = new Position(playerPosition.i, playerPosition.j);
                switch (command)
                {
                    case "up":

                        {
                            nextPosition.i--;
                            break;
                        }
                    case "down":
                        {
                            nextPosition.i++;
                            break;
                        }
                    case "left":
                        {
                            nextPosition.j--;
                            break;
                        }
                    case "right":
                        {
                            nextPosition.j++;
                            break;
                        }
                }
                if (nextPosition.i < 0 ||
                    nextPosition.i >= n ||
                    nextPosition.j < 0 ||
                    nextPosition.j >= n)
                {
                    space[playerPosition.i, playerPosition.j] = '-';
                    inTheVoid = true;
                }
                else
                {
                    switch (space[nextPosition.i, nextPosition.j])
                    {
                        case 'O': // black hole
                            {
                                Position entryBlackHole = nextPosition;
                                Position exitBlackHole = new Position(-1, -1);
                                for (int i = 0; i < space.GetLength(0); i++)
                                    for (int j = 0; j < space.GetLength(1); j++)
                                        if (space[i, j] == 'O' && i != entryBlackHole.i && j != entryBlackHole.j)
                                        {
                                            exitBlackHole = new Position(i, j);
                                            break;
                                        }
                                space[playerPosition.i, playerPosition.j] = '-';
                                space[entryBlackHole.i, entryBlackHole.j] = '-';
                                space[exitBlackHole.i, exitBlackHole.j] = 'S';
                                playerPosition = exitBlackHole;
                                break;
                            }
                        case '-':
                            {
                                space[playerPosition.i, playerPosition.j] = '-';
                                space[nextPosition.i, nextPosition.j] = 'S';
                                playerPosition = nextPosition;
                                break;
                            }
                        default:
                            {
                                StarPower += (int)(space[nextPosition.i, nextPosition.j] - '0');
                                space[playerPosition.i, playerPosition.j] = '-';
                                space[nextPosition.i, nextPosition.j] = 'S';
                                playerPosition = nextPosition;
                                break;
                            }
                    }
                }
            }
            if (inTheVoid) Console.WriteLine("Bad news, the spaceship went to the void.");
            else if (StarPower >= 50) Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
            Console.WriteLine($"Star power collected: {StarPower}");
            PrintMatrx(space);
        }
    }
}
