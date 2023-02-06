using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static N_PUZZLE.NPuzzleSolution;
namespace N_PUZZLE
{
    public class Node
    {
        public static int ManOrHam = 0; //θ(1)
        public int[,] matrix; //θ(1)
        public int matrix_size; //θ(1)
        public Node parent; //θ(1)
        public int z_x; //θ(1)
        public int z_y; //θ(1)
        public int Cost; //θ(1)
        public int level; //θ(1)
        public int Hash_Matrix; //θ(1)

        public Node(int[,] Matrix2D, int Size, Node par) //θ(n^2)     n: matrix_size
        {
            matrix = Matrix2D; //θ(1)
            matrix_size = Size; //θ(1)
            Hash_Matrix = GetMatrixHash(this.matrix); //θ(n^2)     n: matrix_size
            if (par == null) //θ(n^2)     n: matrix_size
            {
                level = 0; //θ(1)
                parent = null; //θ(1)
                z_x = z_index_x; //θ(1)
                z_y = z_index_y; //θ(1)
                Console.WriteLine("----------------------\n[1] Hamming Distance\n[2] Manhatan Distance"); //θ(1)
                Console.Write("\nEnter your choice [1-2]: "); //θ(1)
                char Ch = (char)Console.ReadLine()[0]; //θ(1)
                if (Ch == '1') //θ(n^2)    n: MatrixSize
                {
                    Cost = HammingFun(matrix, matrix_size); //θ(n^2)     n: matrix_size
                    ManOrHam = 1; //θ(1)
                }
                else //θ(n^2)    n: MatrixSize
                {
                    Cost = ManhatanFun(matrix, matrix_size); //θ(n^2)    n: matrix_size
                }
                priorityQueue.Enqueue(this, Cost); //θ(log(n))     n: priorityQueue.Count
            }
            else //θ(n^2)     n: matrix_size
            {
                parent = par; //θ(1)
                level = parent.level + 1; //θ(1)
                if (ManOrHam == 1) //θ(n^2)    n: MatrixSize
                {
                    Cost = HammingFun(matrix, matrix_size) + level; //θ(n^2)     n: matrix_size
                }
                else //θ(n^2)   n: matrix_size
                {
                    Cost = ManhatanFun(matrix, matrix_size) + level; //θ(n^2)     n: matrix_size
                }
            }
        }
        public void Get_adjs(Node x)  //θ(n^2)     n: matrix_size
        {
            if (x.z_x + 1 < x.matrix_size) //θ(n^2)     n: matrix_size
            {
                int[,] mat = new int[x.matrix_size, x.matrix_size]; //θ(1)
                Array.Copy(x.matrix, mat, x.matrix_size * x.matrix_size); //θ(n^2)     n: matrix_size
                mat[x.z_x, x.z_y] = mat[x.z_x + 1, x.z_y]; //θ(1)
                mat[x.z_x + 1, x.z_y] = 0; //θ(1)
                Node n1 = new Node(mat, matrix_size, x); //θ(n^2)     n: matrix_size
                n1.z_x = x.z_x + 1; //θ(1)
                n1.z_y = x.z_y; //θ(1)
                bool visited = HashMatrix.Contains(n1.Hash_Matrix); //θ(n)     n: HashMatrix.Count
                if (!visited)  //θ(log(n))     n: priorityQueue.Count
                {
                    priorityQueue.Enqueue(n1, n1.Cost); //θ(log(n))     n: priorityQueue.Count
                }
            }
            if (x.z_x - 1 >= 0) //θ(n^2)     n: matrix_size
            {
                int[,] mat = new int[x.matrix_size, x.matrix_size]; //θ(1)
                Array.Copy(x.matrix, mat, x.matrix_size * x.matrix_size); //θ(n^2)     n: matrix_size
                mat[x.z_x, x.z_y] = mat[x.z_x - 1, x.z_y]; //θ(1)
                mat[x.z_x - 1, x.z_y] = 0; //θ(1)
                Node n2 = new Node(mat, matrix_size, x); //θ(n^2)     n: matrix_size
                n2.z_x = x.z_x - 1; //θ(1)
                n2.z_y = x.z_y; //θ(1)
                bool visited = HashMatrix.Contains(n2.Hash_Matrix); //θ(n)     n: HashMatrix.Count
                if (!visited)  //θ(log(n))     n: priorityQueue.Count
                {
                    priorityQueue.Enqueue(n2, n2.Cost); //θ(log(n))     n: priorityQueue.Count
                }
            }
            if (x.z_y + 1 < x.matrix_size) //θ(n^2)     n: matrix_size
            {
                int[,] mat = new int[x.matrix_size, x.matrix_size]; //θ(1)
                Array.Copy(x.matrix, mat, x.matrix_size * x.matrix_size); //θ(n^2)     n: matrix_size
                mat[x.z_x, x.z_y] = mat[x.z_x, x.z_y + 1]; //θ(1)
                mat[x.z_x, x.z_y + 1] = 0; //θ(1)
                Node n3 = new Node(mat, matrix_size, x); //θ(n^2)     n: matrix_size
                n3.z_x = x.z_x; //θ(1)
                n3.z_y = x.z_y + 1; //θ(1)
                bool visited = HashMatrix.Contains(n3.Hash_Matrix); //θ(n)     n: HashMatrix.Count
                if (!visited)  //θ(log(n))     n: priorityQueue.Count
                {
                    priorityQueue.Enqueue(n3, n3.Cost); //θ(log(n))     n: priorityQueue.Count
                }
            }
            if (x.z_y - 1 >= 0) //θ(n^2)     n: matrix_size
            {
                int[,] mat = new int[x.matrix_size, x.matrix_size]; //θ(1)
                Array.Copy(x.matrix, mat, x.matrix_size * x.matrix_size); //θ(n^2)     n: matrix_size
                mat[x.z_x, x.z_y] = mat[x.z_x, x.z_y - 1]; //θ(1)
                mat[x.z_x, x.z_y - 1] = 0; //θ(1)
                Node n4 = new Node(mat, matrix_size, x); //θ(n^2)     n: matrix_size
                n4.z_x = x.z_x; //θ(1)
                n4.z_y = x.z_y - 1; //θ(1)
                bool visited = HashMatrix.Contains(n4.Hash_Matrix); //θ(n)     n: HashMatrix.Count
                if (!visited)  //θ(log(n))     n: priorityQueue.Count
                {
                    priorityQueue.Enqueue(n4, n4.Cost); //θ(log(n))     n: priorityQueue.Count
                }
            }
        }
        public int GetMatrixHash(int[,] matrix_hash) //θ(n^2)     n: matrix_size
        {
            int RandomHash = 193; //θ(1)
            for (int row = 0; row < matrix_size; row++) //θ(n^2)     n: matrix_size
            {
                for (int col = 0; col < matrix_size; col++) //θ(n)     n: matrix_size
                {
                    RandomHash = RandomHash * 59 + (matrix_hash[row, col]); //θ(1)
                }
            }
            return RandomHash; //θ(1)
        }
    }
}