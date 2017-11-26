using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kramer
{
    class Program
    {
        private static double[,] matrix;
        private static int dimension = 1;
        private static bool error = false;

        static void Main(string[] args)
        {
            string end = "";
            do
            {
                double mainDeterminant = 0;
                error = false;
                Console.WriteLine("START");

                DateTime beginTest = DateTime.Now;

                if (!error) input_matrix();

                Console.WriteLine("\nRESULT:");

                if (!error) mainDeterminant = getDeterminant(matrix, dimension - 1);
                Console.WriteLine("\nMainDeterminant: " + mainDeterminant);

                if (!error)
                    if (mainDeterminant == 0) Console.WriteLine("MainDeterminant = 0.\nThe system has infinitely many solutions or is incompatible");
                    else {
                        for (int i = 0; i < dimension - 1; i++) {
                            double num = getDeterminant(getNewMatrix(matrix, dimension, i), dimension - 1);
                            Console.Write("\n{0} argument: {1} / {2} = {3}", i + 1, num, mainDeterminant, num / mainDeterminant);
                        }
                    }
                //Вывод результата и конец цикла
                Console.WriteLine("\n\nВремя теста: " + (DateTime.Now - beginTest));
                Console.WriteLine("\n\n");
                Console.WriteLine("#Any character to complete");
                end = Console.ReadLine();
            } while (end == "" || end.Length > 1);
        }

        static int input_matrix() {
            const char separator = ' ';
            string[] buffer;
            try
            {
                buffer = Console.ReadLine().Split(separator);
                dimension = buffer.Length;
                matrix = new double[dimension, dimension];

                for (int i = 0; i < dimension; i++)
                {
                    matrix[0, i] = int.Parse(buffer[i]);
                }

                for (int i = 1; i < dimension-1; i++)
                {
                    buffer = Console.ReadLine().Split(separator);

                    for (int j = 0; j < dimension; j++)
                    {
                        matrix[i, j] = double.Parse(buffer[j]);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error entering matrix");
                error = true;
                return 1;
            }
            return 0;
        }

        static double getDeterminant(double[,] matrix_local, int dimension_local)
        {
            double local_buffer = 0;
            double[,] buffer_matrix = new double[dimension_local, dimension_local];
            if (dimension_local > 2)
            {
                for (int i = 0; i < dimension_local; i++)
                {
                    for (int j = 0; j < dimension_local; j++) {
                        if (matrix_local[i, j] != 0) {
                            for (int t = 0; t < dimension_local; t++) {
                                //Console.Write("\n");
                                for (int q = 0; q < dimension_local-1; q++) {
                                    for (int r = 0; r < dimension_local-1; r++) {
                                        if (q < i && r < t) buffer_matrix[q, r] = matrix_local[q, r];
                                        if (q >= i && r < t) buffer_matrix[q, r] = matrix_local[q+1, r];
                                        if (q < i && r >= t) buffer_matrix[q, r] = matrix_local[q, r+1];
                                        if (q >= i && r >= t) buffer_matrix[q, r] = matrix_local[q+1, r+1];
                                    }
                                }

                                /*
                                //Вывод результата
                                for (int p1 = 0; p1 < dimension_local-1; p1++)
                                {
                                    for (int p2 = 0; p2 < dimension_local-1; p2++)
                                        Console.Write("{0}\t", buffer_matrix[p1,p2]);
                                    Console.Write("\n");
                                }
                                */

                                if ((i + t)%2==0)
                                    local_buffer += getDeterminant(buffer_matrix, dimension_local - 1) * matrix_local[i, t];
                                else
                                    local_buffer -= getDeterminant(buffer_matrix, dimension_local - 1) * matrix_local[i, t];
                            }
                            return local_buffer;
                        }
                    }
                }
            }
            else {
                //Console.WriteLine("###  {0}", matrix_local[0, 0] * matrix_local[1, 1] - matrix_local[0, 1] * matrix_local[1, 0]);
                return matrix_local[0, 0] * matrix_local[1, 1] - matrix_local[0, 1] * matrix_local[1, 0];
            }
            return 0;
        }

        static double[,] getNewMatrix(double[,] matrix, int dimension, int number) {
            double[,] matrix_local = new double[dimension, dimension];

            for (int i = 0; i < dimension - 1; i++)
                for (int j = 0; j < dimension; j++) {
                    matrix_local[i, j] = matrix[i, j];
                }

            for (int i = 0; i < dimension - 1; i++) {
                matrix_local[i, number] = matrix_local[i, dimension - 1];
            }
            return matrix_local;
        }


    }
}
