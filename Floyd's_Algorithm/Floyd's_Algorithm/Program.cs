using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floyd_s_Algorithm
{

    class Floyd
    {

        public static void Run(int[,] myGraph, int[,] myS)
        {
            //////////////////////////// улучшаем с помощью треугольного оператора

            // 1-ая строка и столбец
            int numColRow = 0;

            for (numColRow = 0; numColRow < myGraph.GetLength(1); numColRow++)
            {
                for (int i = 0; i < myGraph.GetLength(1); i++) 
                {
                    for (int j = 0; j < myGraph.GetLength(1); j++)
                    {
                        if (((j != numColRow && myGraph[i, j] == 0 && myGraph[i, numColRow] > 0)
                            && (i != numColRow && myGraph[i, j] == 0 && myGraph[numColRow, j] > 0))                            
                            ||
                            (j != numColRow && i != numColRow && 
                            myGraph[i, numColRow] > 0 && myGraph[numColRow, j] > 0 &&
                            myGraph[i, j] > myGraph[numColRow, j] + myGraph[i, numColRow]))
                        {
                            myGraph[i, j] = myGraph[numColRow, j] + myGraph[i, numColRow];
                            
                            // for myS
                            myS[i, j] = numColRow+1;                            
                        }
                    }
                }
            }


            Show(myGraph);
            Console.WriteLine("\n\n");
            Show(myS);




            for (;;)
            {
                Console.WriteLine("\n\nВведите две вершины, между которыми хотите узнать кратчайший путь: ");
                int A = Convert.ToInt32(Console.ReadLine());
                int B = Convert.ToInt32(Console.ReadLine());

                // SHORTEST WAY  
                int a = A - 1;
                int b = B - 1;
                string way = "";

                way += B + " "; // finish
                for (;;)
                {
                    if ((b + 1) == myS[a, b]) break;
                    way += myS[a, b] + " ";      //Console.WriteLine("\n\nb = " + b + "\n");                 
                    b = myS[a, b] - 1;           //Console.WriteLine("\n\nmyS[a, b] = " + myS[a, b] + "\n");
                }
                way += A + " "; // start
                
                Console.Write("\nCost = {0} | Way = {1}", myGraph[A - 1, B - 1], way);
            }
            

        }
        

        static void Show(int[,] Matrix)
        {
            for (int i = 0; i < Matrix.GetLength(1); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    Console.Write(Matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void Show(string[] Matrix)
        {
            for (int i = 0; i < Matrix.Length; i++)
            {
                Console.WriteLine(Matrix[i]);
            }
            Console.WriteLine();
        }
        static void Show(int[] Matrix)
        {
            for (int i = 0; i < Matrix.Length; i++)
            {
                Console.Write(Matrix[i] + "\t");
            }
            Console.WriteLine();
        }
        static void Show(bool[] Matrix)
        {
            for (int i = 0; i < Matrix.Length; i++)
            {
                Console.Write(Matrix[i] + "\t");
            }
            Console.WriteLine();
        }
        static void Show(string Matrix)
        {
            Console.WriteLine("\n" + Matrix);
        }

        public static string ReverseString(string s)
        {
            char[] arr = new char[s.Length];

            for (int i = 0; i < s.Length; i++)
            {
                arr[i] = s[i];
            }



            for (int i = 0; i < arr.Length / 2; i++)
            {
                char buf = arr[i];
                arr[i] = arr[arr.Length - 1 - i];
                arr[arr.Length - 1 - i] = buf;
            }


            // FOR TEN BUG !!!!
            for (int i = 0; i < s.Length - 1; i++)
            {
                if (arr[i] == '0' && arr[i + 1] == '1')
                {
                    char buf = arr[i];
                    arr[i] = arr[i + 1];
                    arr[i + 1] = buf;
                    break;
                }
            }


            string newArr = "";
            for (int i = 0; i < s.Length; i++)
            {
                newArr += arr[i];
            }





            return newArr;
        }

    }





    class Program
    {
        static void Main(string[] args)
        {

            int[,] myGraph = {
                { -1,  2,  4,  0,  0,  0,  0,  0, 10,  0 }, // 1
                {  0, -1,  0,  1,  0,  0,  0,  0,  3,  0 }, // 2
                {  0,  0, -1,  3,  5,  0,  0,  0,  0,  0 }, // 3
                {  0,  1,  3, -1,  0,  8,  3,  7,  0,  0 }, // 4
                {  0,  0,  0,  0, -1,  2,  0,  0,  0,  0 }, // 5
                {  0,  0,  0,  0,  2, -1,  0,  1,  0,  0 }, // 6
                {  0,  0,  0,  3,  0,  0, -1,  0,  0,  7 }, // 7
                {  0,  0,  0,  7,  0,  1,  4, -1,  0,  0 }, // 8
                {  0,  3,  0,  0,  0,  0,  7,  0, -1,  4 }, // 9
                {  0,  0,  0,  0,  0,  0,  0,  0,  0, -1 }, // 10
            };

            int[,] myS = {
                {  -1,  2,  3,  4,  5,  6,  7,  8,  9, 10  }, // 1
                {   1, -1,  3,  4,  5,  6,  7,  8,  9, 10  }, // 2
                {   1,  2, -1,  4,  5,  6,  7,  8,  9, 10  }, // 3
                {   1,  2,  3, -1,  5,  6,  7,  8,  9, 10  }, // 4
                {   1,  2,  3,  4, -1,  6,  7,  8,  9, 10  }, // 5
                {   1,  2,  3,  4,  5, -1,  7,  8,  9, 10  }, // 6
                {   1,  2,  3,  4,  5,  6, -1,  8,  9, 10  }, // 7
                {   1,  2,  3,  4,  5,  6,  7, -1,  9, 10  }, // 8
                {   1,  2,  3,  4,  5,  6,  7,  8, -1, 10  }, // 9
                {   1,  2,  3,  4,  5,  6,  7,  8,  9, -1  }, // 10
            };





            Floyd.Run(myGraph, myS);




            Console.ReadKey();
        }
    }
}
