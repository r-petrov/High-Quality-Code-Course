using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
    public class MinesweeperMain
    {
        const int minefieldRowsNumber = 5;

        const int minefieldColumnsNumber = 10;

        const int MaxStepsOnTheMinefield = 35;

        private static char[,] minefield;

        private static char[,] mines;

        static string inputCommand = string.Empty;

        private static void Main()
        {
            minefield = CreateMinefield(minefieldRowsNumber, minefieldColumnsNumber);

            mines = PutMinesOnMinefield(minefieldRowsNumber, minefieldColumnsNumber);

            int stepCounter = 0;
            bool hasMineExploded = false;
            List<Player> bestPlayers = new List<Player>(6);
            int minefieldRow = 0;
            int minefieldColumn = 0;
            //TODO change the flag name
            bool isGameStarted = true;
            
            bool areMaxStepsMade = false;

            do
            {
                if (isGameStarted)
                {
                    Console.WriteLine(
                        "Let's play “Minesweeper”. Try your lucky to find all boxes not containing mines."
                        + " Command 'top' shows current rating, 'restart' starts a new game, 'exit' ends the game!");

                    DrawMinefield(minefield);
                    isGameStarted = false;
                }

                Console.Write("Please, enter the number of row and column or other command: ");

                inputCommand = Console.ReadLine().Trim();

                if (inputCommand.Length >= 3)
                {
                    if (int.TryParse(inputCommand[0].ToString(), out minefieldRow) && int.TryParse(inputCommand[2].ToString(), out minefieldColumn)
                        && minefieldRow <= minefield.GetLength(0) && minefieldColumn <= minefield.GetLength(1))
                    {
                        inputCommand = "turn";
                    }
                }

                switch (inputCommand)
                {
                    case "top":
                        PrintBestPlayersRating(bestPlayers);
                        break;
                    case "restart":
                        minefield = CreateMinefield(minefieldRowsNumber, minefieldColumnsNumber);
                        mines = PutMinesOnMinefield(minefieldRowsNumber, minefieldColumnsNumber);
                        DrawMinefield(minefield);
                        //TODO delete next two lines????
                        //hasMineExploded = false;
                        //flag = false;
                        break;
                    case "exit":
                        Console.WriteLine("Good Bye and thanks for playing!");
                        break;
                    case "turn":
                        if (mines[minefieldRow, minefieldColumn] != '*')
                        {
                            if (mines[minefieldRow, minefieldColumn] == '-')
                            {
                                MakeNextStep(minefield, mines, minefieldRow, minefieldColumn);
                                stepCounter++;
                            }

                            if (MaxStepsOnTheMinefield == stepCounter)
                            {
                                areMaxStepsMade = true;
                            }
                            else
                            {
                                DrawMinefield(minefield);
                            }
                        }
                        else
                        {
                            hasMineExploded = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nGreshka! nevalidna Komanda\n");
                        break;
                }

                if (hasMineExploded)
                {
                    //TODO extract next lines into method
                    DrawMinefield(mines);
                    Console.Write("\nBoom! You died like a hero with {0} points. " + "Enter your nickname: ", stepCounter);
                    string nickname = Console.ReadLine();
                    Player currentPlayer = new Player(nickname, stepCounter);

                    if (bestPlayers.Count < 5)
                    {
                        bestPlayers.Add(currentPlayer);
                    }
                    else
                    {
                        for (int i = 0; i < bestPlayers.Count; i++)
                        {
                            if (bestPlayers[i].Points < currentPlayer.Points)
                            {
                                bestPlayers.Insert(i, currentPlayer);
                                bestPlayers.RemoveAt(bestPlayers.Count - 1);
                                break;
                            }
                        }
                    }

                    bestPlayers.Sort((Player playerOne, Player playerTwo) => playerTwo.Name.CompareTo(playerOne.Name));
                    bestPlayers.Sort((Player playerOne, Player playerTwo) => playerTwo.Points.CompareTo(playerOne.Points));
                    PrintBestPlayersRating(bestPlayers);

                    //TODO extract next lines into method
                    minefield = CreateMinefield(minefieldRowsNumber, minefieldColumnsNumber);
                    mines = PutMinesOnMinefield(minefieldRowsNumber, minefieldColumnsNumber);
                    stepCounter = 0;
                    hasMineExploded = false;
                    isGameStarted = true;
                }

                if (areMaxStepsMade)
                {
                    Console.WriteLine("\nCONGRATULATIONS! You have opened {0} boxes with no casualty.", MaxStepsOnTheMinefield);

                    //TODO extract next lines into method
                    DrawMinefield(mines);
                    Console.WriteLine("Enter your nickname, dude: ");
                    string nickname = Console.ReadLine();

                    Player currentPlayer = new Player(nickname, stepCounter);
                    bestPlayers.Add(currentPlayer);
                    PrintBestPlayersRating(bestPlayers);

                    //TODO extract next lines into method
                    minefield = CreateMinefield(minefieldRowsNumber, minefieldColumnsNumber);
                    mines = PutMinesOnMinefield(minefieldRowsNumber, minefieldColumnsNumber);
                    stepCounter = 0;
                    areMaxStepsMade = false;
                    isGameStarted = true;
                }
            }
            while (inputCommand != "exit");

            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }

        private static void PrintBestPlayersRating(List<Player> bestPlayers)
        {
            Console.WriteLine("\nBest players rating:");
            if (bestPlayers.Count > 0)
            {
                for (int i = 0; i < bestPlayers.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} boxes", i + 1, bestPlayers[i].Name, bestPlayers[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty rating!\n");
            }
        }

        private static void MakeNextStep(char[,] minefield, char[,] mines, int minefieldRowIndex, int minefieldColumnIndex)
        {
            char numberOfNeighborMines = CalculateNumberOfNeighborMines(mines, minefieldRowIndex, minefieldColumnIndex);
            mines[minefieldRowIndex, minefieldColumnIndex] = numberOfNeighborMines;
            minefield[minefieldRowIndex, minefieldColumnIndex] = numberOfNeighborMines;
        }

        private static void DrawMinefield(char[,] minefield)
        {
            int minefieldRowsNumber = minefield.GetLength(0);
            int minefieldColumnsNumber = minefield.GetLength(1);

            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int row = 0; row < minefieldRowsNumber; row++)
            {
                Console.Write("{0} | ", row);
                for (int col = 0; col < minefieldColumnsNumber; col++)
                {
                    Console.Write("{0} ", minefield[row, col]);
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateMinefield(int minefieldRowsNumber, int minefieldColumnsNumber)
        {
            
            minefield = new char[minefieldRowsNumber, minefieldColumnsNumber];

            for (int row = 0; row < minefieldRowsNumber; row++)
            {
                for (int col = 0; col < minefieldColumnsNumber; col++)
                {
                    minefield[row, col] = '?';
                }
            }

            return minefield;
        }

        private static char[,] PutMinesOnMinefield(int minefieldRowsNumber, int minefieldColumnsNumber)
        {
            minefield = new char[minefieldRowsNumber, minefieldColumnsNumber];

            for (int row = 0; row < minefieldRowsNumber; row++)
            {
                for (int col = 0; col < minefieldColumnsNumber; col++)
                {
                    minefield[row, col] = '-';
                }
            }

            List<int> minesNumbers = new List<int>();

            while (minesNumbers.Count < 15)
            {
                Random random = new Random();
                int currentMineNumber = random.Next(50);

                if (!minesNumbers.Contains(currentMineNumber))
                {
                    minesNumbers.Add(currentMineNumber);
                }
            }

            foreach (int mineNumber in minesNumbers)
            {
                int mineRowIndex = mineNumber / minefieldColumnsNumber;
                int mineColumnIndex = mineNumber % minefieldColumnsNumber;
                if (mineColumnIndex == 0 && mineNumber != 0)
                {
                    mineRowIndex--;
                    mineColumnIndex = minefieldColumnsNumber;
                }
                else
                {
                    mineColumnIndex++;
                }

                minefield[mineRowIndex, mineColumnIndex - 1] = '*';
            }

            return minefield;
        }

        //private static void GiveValueOfOpenedCleanBoxes(char[,] minefield)
        //{
        //    int minefieldRowsNumber = minefield.GetLength(0);
        //    int minefieldColumnsNumber = minefield.GetLength(1);

        //    for (int row = 0; row < minefieldRowsNumber; row++)
        //    {
        //        for (int col = 0; col < minefieldColumnsNumber; col++)
        //        {
        //            if (minefield[row, col] != '*')
        //            {
        //                char boardFieldValue = CalculateNumberOfNeighborMines(minefield, row, col);
        //                minefield[row, col] = boardFieldValue;
        //            }
        //        }
        //    }
        //}

        private static char CalculateNumberOfNeighborMines(char[,] minefield, int minefieldRowIndex, int minefieldColumnIndex)
        {
            int numberOfMines = 0;
            int minefieldRowsNumber = minefield.GetLength(0);
            int minefieldColumnsNumber = minefield.GetLength(1);

            if (minefieldRowIndex - 1 >= 0)
            {
                if (minefield[minefieldRowIndex - 1, minefieldColumnIndex] == '*')
                {
                    numberOfMines++;
                }
            }

            if (minefieldRowIndex + 1 < minefieldRowsNumber)
            {
                if (minefield[minefieldRowIndex + 1, minefieldColumnIndex] == '*')
                {
                    numberOfMines++;
                }
            }

            if (minefieldColumnIndex - 1 >= 0)
            {
                if (minefield[minefieldRowIndex, minefieldColumnIndex - 1] == '*')
                {
                    numberOfMines++;
                }
            }

            if (minefieldColumnIndex + 1 < minefieldColumnsNumber)
            {
                if (minefield[minefieldRowIndex, minefieldColumnIndex + 1] == '*')
                {
                    numberOfMines++;
                }
            }

            if ((minefieldRowIndex - 1 >= 0) && (minefieldColumnIndex - 1 >= 0))
            {
                if (minefield[minefieldRowIndex - 1, minefieldColumnIndex - 1] == '*')
                {
                    numberOfMines++;
                }
            }

            if ((minefieldRowIndex - 1 >= 0) && (minefieldColumnIndex + 1 < minefieldColumnsNumber))
            {
                if (minefield[minefieldRowIndex - 1, minefieldColumnIndex + 1] == '*')
                {
                    numberOfMines++;
                }
            }

            if ((minefieldRowIndex + 1 < minefieldRowsNumber) && (minefieldColumnIndex - 1 >= 0))
            {
                if (minefield[minefieldRowIndex + 1, minefieldColumnIndex - 1] == '*')
                {
                    numberOfMines++;
                }
            }

            if ((minefieldRowIndex + 1 < minefieldRowsNumber) && (minefieldColumnIndex + 1 < minefieldColumnsNumber))
            {
                if (minefield[minefieldRowIndex + 1, minefieldColumnIndex + 1] == '*')
                {
                    numberOfMines++;
                }
            }

            return char.Parse(numberOfMines.ToString());
        }
    }
}