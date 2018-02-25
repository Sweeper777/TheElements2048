using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
namespace The_Elements_2048
{
    public class Game
    {
        Random random = new Random();

        const int boardSize = 4;

        public int Score { get; set; } = 0;
        public Element[,] Board { get; set; } = new Element[boardSize, boardSize];

        public List<Position> EmptySpaces => Board.IndicesOf(Element.None);

        public void SpawnNewElement() {
            var emptySpaces = EmptySpaces;
            var randomEmptySpace = emptySpaces[random.Next(emptySpaces.Count)];
            var newElement = random.Next(3) == 0 ? Element.Helium : Element.Hydrogen;
            Board[randomEmptySpace.X, randomEmptySpace.Y] = newElement;
        }

        Element[] EvaluateRow(Element[] row) {
            var fromTo = Enumerable.Repeat(-1, row.Length).ToArray();
            var result = Enumerable.Repeat(Element.None, row.Length).ToArray();
            var prevVal = Element.None;
            var pos = 0;
            for (int i = 0; i < row.Length; i++) {
                if (row[i] != Element.None) {
                    if (row[i] == prevVal) {
                        result[pos - 1]++;
                        fromTo[i] = pos - 1;
                        prevVal = Element.None;
                    } else {
                        result[pos] = row[i];
                        fromTo[i] = pos;
                        prevVal = row[i];
                        pos++;
                    }
                }
            }
            return result;
        }

        Element[,] EvaluateBoard(Element[,] board) {
            return board.ToJagged().Select(EvaluateRow).ToArray().ToMatrix();
        }

        public bool MoveLeft() {
            var newBoard = EvaluateBoard(Board);
            var moved = !newBoard.Cast<Element>().SequenceEqual(Board.Cast<Element>());
            Board = newBoard;
            return moved;
        }

        public bool MoveUp() {
            var newBoard = EvaluateBoard(Board.RotateCounterClockwise()).RotateClockwise();
            var moved = !newBoard.Cast<Element>().SequenceEqual(Board.Cast<Element>());
            Board = newBoard;
            return moved;
        }

        public bool MoveRight() {
            var newBoard = EvaluateBoard(Board.RotateClockwise().RotateClockwise())
                .RotateCounterClockwise().RotateCounterClockwise();
            var moved = !newBoard.Cast<Element>().SequenceEqual(Board.Cast<Element>());
            Board = newBoard;
            return moved;
        }

        public bool MoveDown() {
            var newBoard = EvaluateBoard(Board.RotateClockwise()).RotateCounterClockwise(); 
            var moved = !newBoard.Cast<Element>().SequenceEqual(Board.Cast<Element>());
            Board = newBoard;
            return moved;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"Score: {Score}");
            for (int i = 0; i < Board.GetLength(1); i++) {
                for (int j = 0; j < Board.GetLength(0); j++) {
                    builder.Append((char)(Board[j, Board.GetLength(1) - i - 1] + 96));
                }
                builder.AppendLine();
            }
            return builder.ToString();
        }
    }
}
