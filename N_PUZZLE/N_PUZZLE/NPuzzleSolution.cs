using System.Diagnostics;

namespace N_PUZZLE
{
    class NPuzzleSolution
    {
        public static Stopwatch CalculateTime =  new Stopwatch(); //θ(1)
        public static HashSet<int> HashMatrix; //θ(1)
        public static PriorityQueue<Node, int> priorityQueue; //θ(1)
        public static int z_index_x; //θ(1)
        public static int z_index_y; //θ(1)
        public static Node n1; //θ(1)
        public static int AStarAlgorithm(int[,] Array2D, int MatrixSize, int[] Array1D) //E log(V)     E: Number of steps
                                                                                        //             V: priorityQueue.Count
        {
            priorityQueue = new PriorityQueue<Node, int>(); //θ(1)
            HashMatrix = new HashSet<int>(); //θ(1)
            Node n = new Node(Array2D, MatrixSize, null); //θ(n^2)     n: matrix_size

            while (priorityQueue.Count > 0)  //E: number of steps
            {
                CalculateTime.Start();
                n1 = priorityQueue.Dequeue(); //θ(log(V))    V: priorityQueue.Count
                HashMatrix.Add(n1.Hash_Matrix); //θ(1)
                Node tmp = n1; //θ(1)
                if (n1.Cost - n1.level == 0) //θ(1)
                {
                    CalculateTime.Stop();
                    return tmp.level; //θ(1)
                }
                n1.Get_adjs(n1); //θ(n^2)     n: matrix_size
            }
            return 0;
        }
        /// Hamming Function 
        public static int HammingFun(int[,] Mat, int MatrixSize) //θ(MatrixSize^2)
        {
            int Hamming_value = 0; //θ(1)
            for (int i = 0; i < MatrixSize; i++) //θ(MatrixSize^2)
            {
                for (int j = 0; j < MatrixSize; j++) //θ(MatrixSize)
                {
                    if (Mat[i, j] == 0) //θ(1)
                        continue; //θ(1)
                    else if ((i * MatrixSize + j + 1) != Mat[i, j]) //θ(1)
                        Hamming_value += 1; //θ(1)
                }
            }
            return Hamming_value;
        }
        /// Manhatan Function
        public static int ManhatanFun(int[,] Matrix2D, int MatrixSize) //θ(n^2)     n: MatrixSize
        {
            int Col = 0; //θ(1)
            int Row = 0; //θ(1)
            int Manhatan_value = 0; //θ(1)
            for (int i = 0; i < MatrixSize; i++) //θ(n^2)      n: MatrixSize
            {
                for (int j = 0; j < MatrixSize; j++) //θ(n)    n: MatrixSize
                {
                    if (Matrix2D[i, j] == 0) //θ(1)
                        continue; //θ(1)
                    else if (Matrix2D[i, j] != (i * MatrixSize + j) + 1) //θ(1)
                    {
                        Col = ((Matrix2D[i, j] - 1) % MatrixSize); //θ(1)
                        Row = ((Matrix2D[i, j] - 1) / MatrixSize); //θ(1)
                        Manhatan_value += (Math.Abs(Row - i) + Math.Abs(Col - j)); //θ(1)
                    }
                }
            }
            return Manhatan_value;
        }
        /// Check Solvable or not
        public static bool CheckSolvability(int[] Matrix1D, int MatrixSize)  //θ(n^4) = θ(s^2)     n: MatrixSize, s: Matrix Length
        {
            int inv = 0; //θ(1)
            //compare from first cell to the pre last
            for (int i = 0; i < (MatrixSize * MatrixSize); i++) 
            {
                //Console.Write(arr[i] + "  " );
                if (Matrix1D[i] == 0) //θ(1)
                {
                    // Get Zero Index
                    z_index_x = i / MatrixSize; //θ(1)
                    z_index_y = i % MatrixSize; //θ(1)
                    continue;
                }
                //compare with the cell after i cell till the last cell 
                for (int j = (i + 1); j < (MatrixSize * MatrixSize); j++) //θ(n^2)       n: MatrixSize
                {
                    if (Matrix1D[j] == 0) //θ(1)
                        continue; //θ(1)
                    else if (Matrix1D[i] > Matrix1D[j]) //θ(1)
                        inv++; //θ(1)
                }
            }
            if (MatrixSize % 2 != 0 && inv % 2 == 0) //θ(1)
                return true; //θ(1)
            else if (MatrixSize % 2 == 0 && inv % 2 != 0 && z_index_x % 2 == 0) //θ(1)
                return true; //θ(1)
            else if (MatrixSize % 2 == 0 && inv % 2 == 0 && z_index_x % 2 != 0) //θ(1)
                return true; //θ(1)
            return false; //θ(1)
        }
        public static void PrintPath(Node n) //θ(n^2 * c)     n: MatrixSize      c: number of nodes in path
        {
            List<Node> list = new List<Node>(); //θ(1)
            while (n.parent != null) //Best: θ(1),     Worst: θ(v)
            {
                list.Add(n); //θ(1)
                n = n.parent; //θ(1)
            }
            int number_of_movements = 1; //θ(1)
            for (int i = list.Count - 1; i >= 0; i--) //θ(n^2 * c)      n: MatrixSize      c: number of nodes in path
            {
                Console.WriteLine("----------> #" + number_of_movements); //θ(1)
                for (int j = 0; j < list[i].matrix_size; j++) //θ(n^2)      n: MatrixSize
                {
                    for (int k = 0; k < list[i].matrix_size; k++) //θ(n)      n: MatrixSize
                        Console.Write(list[i].matrix[j, k] + " "); //θ(1)
                    Console.WriteLine(); //θ(1)
                }
                number_of_movements++; //θ(1)
                Console.WriteLine(); //θ(1)
            }
        }
    }
}