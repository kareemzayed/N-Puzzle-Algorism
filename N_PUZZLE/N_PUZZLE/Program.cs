using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using static N_PUZZLE.NPuzzleSolution;

namespace N_Puzz
{
    class Program
    {
        static void Main(string[] args) //θ(n^2)     n: MatrixSize
        {
            Console.WriteLine("N Puzzle Problem:\n[1] Sample test cases\n[2] Complete testing"); //θ(1)
            Console.Write("\nEnter your choice [1-2]: "); //θ(1)
            char choice = (char)Console.ReadLine()[0]; //θ(1)
            bool succeed = false; //θ(1)
            switch (choice)
            {
                case '1':
                    Console.WriteLine("---------------------\n[1] Solvable\n[2] UnSolvable"); //θ(1)
                    Console.Write("\nEnter your choice [1-2]: "); //θ(1)
                    char ch = (char)Console.ReadLine()[0]; //θ(1)
                    if (ch == '1')
                    {
                        Console.WriteLine("---------------------\n[1] 8 Puzzle (2)"); //θ(1)
                        Console.WriteLine("[2] 8 Puzzle (3)\n[3] 15 Puzzle - 1"); //θ(1)
                        Console.WriteLine("[4] 24 Puzzle 1\n[5] 24 Puzzle 2"); //θ(1)
                        Console.Write("\nEnter your choice [1-2-3-4-5]: "); //θ(1)
                        char ch1 = (char)Console.ReadLine()[0]; //θ(1)
                        if(ch1 == '1') //θ(n^2)     n: MatrixSize
                            succeed = Check("..//net6.0//Sample//Solvable//20Puzzle.txt"); //θ(n^2)     n: MatrixSize
                        else if (ch1 == '2') //θ(n^2)     n: MatrixSize
                            succeed = Check("..//net6.0//Sample//Solvable//14Puzzle.txt"); //θ(n^2)     n: MatrixSize
                        else if (ch1 == '3') //θ(n^2)     n: MatrixSize
                            succeed = Check("..//net6.0//Sample//Solvable//15Puzzle.txt"); //θ(n^2)     n: MatrixSize
                        else if (ch1 == '4') //θ(n^2)     n: MatrixSize
                            succeed = Check("..//net6.0//Sample//Solvable//11Puzzle.txt"); //θ(n^2)     n: MatrixSize
                        else if (ch1 == '5') //θ(n^2)     n: MatrixSize
                            succeed = Check("..//net6.0//Sample//Solvable//24Puzzle.txt"); //θ(n^2)     n: MatrixSize
                    }
                    else if(ch == '2')
                    {
                        Console.WriteLine("---------------------\n[1] 8 Puzzle - Case 1 (1)\n[2] 8 Puzzle(2) - Case 1"); //θ(1)
                        Console.WriteLine("[3] 8 Puzzle(3) - Case 1\n[4] 15 Puzzle - Case 2\n[5] 15 Puzzle - Case 3"); //θ(1)
                        Console.Write("\nEnter your choice [1-2-3-4-5]: "); //θ(1)
                        char ch1 = (char)Console.ReadLine()[0]; //θ(1)
                        if (ch1 == '1') //θ(n^2)     n: MatrixSize
                            succeed = Check("..//net6.0//Sample//Unsolvable//8 Puzzle - Case 1.txt");
                        else if (ch1 == '2') //θ(n^2)     n: MatrixSize
                            succeed = Check("..//net6.0//Sample//Unsolvable//8 Puzzle(2) - Case 1.txt");
                        else if (ch1 == '3') //θ(n^2)     n: MatrixSize
                            succeed = Check("..//net6.0//Sample//Unsolvable//8 Puzzle(3) - Case 1.txt");
                        else if (ch1 == '4') //θ(n^2)     n: MatrixSize
                            succeed = Check("..//net6.0//Sample//Unsolvable//15 Puzzle - Case 2.txt");
                        else if (ch1 == '5') //θ(n^2)     n: MatrixSize
                            succeed = Check("..//net6.0//Sample//Unsolvable//15 Puzzle - Case 3.txt");
                    }
                    break;
                case '2':
                    Console.WriteLine("---------------------\n[1] Solvable\n[2] UnSolvable\n[3] Very Larg"); //θ(1)
                    Console.Write("\nEnter your choice [1-2-3]: "); //θ(1)
                    char ch2 = (char)Console.ReadLine()[0]; //θ(1)
                    if (ch2 == '1')
                    {
                        Console.WriteLine("---------------------\n[1] Manhattan & Hamming\n[2] Manhattan Only"); //θ(1)
                        Console.Write("\nEnter your choice [1-2]: "); //θ(1)
                        char ch3 = (char)Console.ReadLine()[0]; //θ(1)
                        if (ch3 == '1')
                        {
                            Console.WriteLine("---------------------\n[1] 50 Puzzle (1)\n[2] 99 Puzzle - 1"); //θ(1)
                            Console.WriteLine("[3] 99 Puzzle - 2\n[4] 9999 Puzzle"); //θ(1)
                            Console.Write("\nEnter your choice [1-2-3-4]: ");  //θ(1)
                            char ch4 = (char)Console.ReadLine()[0]; //θ(1)
                            if (ch4 == '1') //θ(n^2)     n: MatrixSize
                                succeed = Check("..//net6.0//Complete//Solvable puzzles//Manhattan & Hamming//18Puzzle.txt");
                            else if (ch4 == '2') //θ(n^2)     n: MatrixSize
                                succeed = Check("..//net6.0//Complete//Solvable puzzles//Manhattan & Hamming//18Puzzle2.txt");
                            else if (ch4 == '3') //θ(n^2)     n: MatrixSize
                                succeed = Check("..//net6.0//Complete//Solvable puzzles//Manhattan & Hamming//38Puzzle.txt");
                            else if (ch4 == '4') //θ(n^2)     n: MatrixSize
                                succeed = Check("..//net6.0//Complete//Solvable puzzles//Manhattan & Hamming//4Puzzle.txt");
                        }
                        if (ch3 == '2')
                        {
                            Console.WriteLine("---------------------\n[1] 15 Puzzle 1 (1)\n[2] 15 Puzzle 3"); //θ(1)
                            Console.WriteLine("[3] 15 Puzzle 4\n[4] 15 Puzzle 5"); //θ(1)
                            Console.Write("\nEnter your choice [1-2-3-4]: "); //θ(1)
                            char ch4 = (char)Console.ReadLine()[0]; //θ(1)
                            if (ch4 == '1') //θ(n^2)     n: MatrixSize
                                succeed = Check("..//net6.0//Complete//Solvable puzzles//Manhattan Only//46Puzzle.txt");
                            else if (ch4 == '2') //θ(n^2)     n: MatrixSize
                                succeed = Check("..//net6.0//Complete//Solvable puzzles//Manhattan Only//38Puzzle.txt");
                            else if (ch4 == '3') //θ(n^2)     n: MatrixSize
                                succeed = Check("..//net6.0//Complete//Solvable puzzles//Manhattan Only//44Puzzle.txt");
                            else if (ch4 == '4') //θ(n^2)     n: MatrixSize
                                succeed = Check("..//net6.0//Complete//Solvable puzzles//Manhattan Only//45Puzzle.txt");
                        }
                    }
                    else if(ch2 == '2')
                    {
                        Console.WriteLine("---------------------\n[1] 15 Puzzle 1 - Unsolvable\n[2] 99 Puzzle - Unsolvable Case 1"); //θ(1)
                        Console.WriteLine("[3] 99 Puzzle - Unsolvable Case 2\n[4] 9999 Puzzle"); //θ(1)
                        Console.Write("\nEnter your choice [1-2-3-4]: "); //θ(1)
                        char ch4 = (char)Console.ReadLine()[0]; //θ(1)
                        if (ch4 == '1') //θ(n^2)     n: MatrixSize
                            succeed = Check("..//net6.0//Complete//Unsolvable puzzles//15 Puzzle 1 - Unsolvable.txt");
                        else if (ch4 == '2') //θ(n^2)     n: MatrixSize
                            succeed = Check("..//net6.0//Complete//Unsolvable puzzles//99 Puzzle - Unsolvable Case 1.txt");
                        else if (ch4 == '3') //θ(n^2)     n: MatrixSize
                            succeed = Check("..//net6.0//Complete//Unsolvable puzzles//99 Puzzle - Unsolvable Case 2.txt");
                        else if (ch4 == '4') //θ(n^2)     n: MatrixSize
                            succeed = Check("..//net6.0//Complete//Unsolvable puzzles//9999 Puzzle.txt");
                    }
                    else if(ch2 == '3') //θ(n^2)     n: MatrixSize
                        succeed = Check("..//net6.0//Complete//V. Large test case//TEST.txt");
                    if (succeed)
                        Console.WriteLine("\nCongratulations... your program runs successfully"); //θ(1)
                    break;
            }
        }
        ///  terun 1Darry to 2Darray.......
        private static int[,] Conver_To_2D_Array(int[] Matrix1D, int MatrixSize)  //θ(n^2)     n: MatrixSize
        {
            int[,] Array2D = new int[MatrixSize, MatrixSize]; //θ(1)
            for (int i = 0; i < MatrixSize; i++) //θ(n^2)     n: MatrixSize
            {
                for (int j = 0; j < MatrixSize; j++) //θ(n)       n: MatrixSize
                    Array2D[i, j] = Matrix1D[i * MatrixSize + j]; //θ(1)
            }
            return Array2D; //θ(1)
        }
        public static bool Check(string Name_of_file) //θ(n^2)     n: MatrixSize
        {
            FileStream File = new FileStream(Name_of_file, FileMode.Open, FileAccess.Read); //θ(n^2)     n: MatrixSize
            StreamReader Stream_Reader = new StreamReader(File);
            int wrongAnswer = 0; //θ(1)
            int MatrixSize = int.Parse(Stream_Reader.ReadLine()); //θ(1)
            int[] Matrix1D = new int[MatrixSize * MatrixSize]; //θ(1)
            int k = 0; //θ(1)
            for (int i = 0; i < MatrixSize; i++)  //θ(n^2)     n: MatrixSize
            {
                string line = Stream_Reader.ReadLine(); //θ(1)
                string[] ss = line.Split(' '); //θ(1)

                for (int j = 0; j < MatrixSize; j++)  //θ(n)     n: MatrixSize
                {
                    int x = Int32.Parse(ss[j]); //θ(1)
                    Matrix1D[k++] = x; //θ(1)
                }
            }
            int RightAnswer = int.Parse(Stream_Reader.ReadLine()); //θ(1)
            int receivedResult;
            if (CheckSolvability(Matrix1D, MatrixSize))  //θ(n^4) = θ(s^2)     n: MatrixSize, s: Matrix Length
            {
                receivedResult = N_PUZZLE.NPuzzleSolution.AStarAlgorithm(Conver_To_2D_Array(Matrix1D, MatrixSize), MatrixSize, Matrix1D);
            }
            else
            {
                Console.WriteLine("\n====================="); //θ(1)
                Console.WriteLine("    Not Solvable     "); //θ(1)
                Console.WriteLine("====================="); //θ(1)
                return false; //θ(1)
            }
            if (receivedResult != RightAnswer) //θ(1)
            {
                Console.WriteLine("\nwrong answer at number of movements --> expected = " + RightAnswer + " received = " + receivedResult + "\n"); //θ(1)
                return false; //θ(1)
            }
            else  //θ(1)
            {
                if (MatrixSize == 3) //θ(n^2 * c)     n: MatrixSize      c: number of nodes in path
                {
                    PrintPath(n1); //θ(n^2 * c)     n: MatrixSize      c: number of nodes in path
                }
                Console.WriteLine("\n# of movements = " + n1.level); //θ(1)
                Console.WriteLine("\nime : " + CalculateTime.Elapsed); //θ(1)
                Console.WriteLine("\nCongratulations... :)\n"); //θ(1)
                return true; //θ(1)
            }
            Stream_Reader.Close(); //θ(1)
            File.Close(); //θ(1)
        }
    }
}