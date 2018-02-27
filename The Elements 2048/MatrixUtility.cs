using System;
using System.Collections.Generic;
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

        public static T[,] RotateCounterClockwise<T>(this T[,] oldMatrix)
        {
            T[,] newMatrix = new T[oldMatrix.GetLength(1), oldMatrix.GetLength(0)];
            int newColumn, newRow = 0;
            for (int oldColumn = oldMatrix.GetLength(1) - 1; oldColumn >= 0; oldColumn--)
            {
                newColumn = 0;
                for (int oldRow = 0; oldRow < oldMatrix.GetLength(0); oldRow++)
                {
                    newMatrix[newRow, newColumn] = oldMatrix[oldRow, oldColumn];
                    newColumn++;
                }
                newRow++;
            }
            return newMatrix;
        }

        public static T[,] RotateClockwise<T>(this T[,] oldMatrix)
        {
            var dimensionX = oldMatrix.GetLength(1);
            var dimensionY = oldMatrix.GetLength(0);

            var newMatrix = new T[dimensionX, dimensionY];

            for (var oldColumn = 0; oldColumn < dimensionX; ++oldColumn)
            {
                for (var oldRow = 0; oldRow < dimensionY; ++oldRow)
                {
                    newMatrix[oldColumn, oldRow] = oldMatrix[dimensionY - oldRow - 1, oldColumn];
                }
            }
            return newMatrix;
        }

        public static List<Position> IndicesOf<T>(this T[,] matrix, T item) {
            var list = new List<Position>();
            for (int i = 0; i < matrix.GetLength(0); i++) {
                for (int j = 0; j < matrix.GetLength(1); j++) {
                    if (EqualityComparer<T>.Default.Equals(matrix[i, j], item)) {
                        list.Add(new Position(i, j));
                    }
                }
            }
            return list;
        }

        public static U[,] Select<T, U>(this T[,] matrix, Func<T, U> transform) {
            var newMatrix = new U[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    newMatrix[i, j] = transform(matrix[i, j]);
                }
            }
            return newMatrix;
        }

        public static bool Any<T>(this T[,] matrix, Predicate<T> predicate) {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (predicate(matrix[i, j])) {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
