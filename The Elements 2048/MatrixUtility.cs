using System;
using System.Linq;
namespace The_Elements_2048
{
    public static class MatrixUtility
    {
        public static T[] Row<T>(this T[,] matrix, int row) {
            return Enumerable.Range(0, matrix.GetLength(0)).Select(x => matrix[x, row]).ToArray();
        }
    }
}
