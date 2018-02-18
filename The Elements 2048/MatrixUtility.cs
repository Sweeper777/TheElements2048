using System;
using System.Linq;
namespace The_Elements_2048
{
    public static class MatrixUtility
    {
        public static T[] Row<T>(this T[,] matrix, int row) {
            return Enumerable.Range(0, matrix.GetLength(0)).Select(x => matrix[x, row]).ToArray();
        }

        public static T[][] ToJagged<T>(this T[,] matrix) {
            return Enumerable.Range(0, matrix.GetLength(1)).Select(x => matrix.Row(x)).ToArray();
        }

        public static T[,] ToMatrix<T>(this T[][] jagged) {
            int height = jagged.Length;
            int width = jagged.First().Length;
            T[,] matrix = new T[width, height];
            for (int i = 0; i < width; i++) {
                for (int j = 0; j < height; j++) {
                    matrix[i, j] = jagged[j][i];
                }
            }
            return matrix;
        }

    }
}
