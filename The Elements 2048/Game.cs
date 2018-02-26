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
            var movementResults = new MovementResult[fromTo.Length];
            for (int i = 0; i < movementResults.Length; i++) {
                if (fromTo[i] > -1)
                {
                    var merged = result[fromTo[i]] != row[i];
                    var distanceMoved = i - fromTo[i];
                    movementResults[i] = new MovementResult(merged, distanceMoved);
                } else {
                    movementResults[i] = new MovementResult(false, 0);
                }
            }
            return new RowResult(result, movementResults);
        }

        }

        public bool MoveLeft() {
            var newBoard = EvaluateBoard(Board);
            var moved = !newBoard.Cast<Element>().SequenceEqual(Board.Cast<Element>());
            Board = newBoard;
            return moved;
        BoardResult EvaluateBoard(Element[,] board) {
            var rowResults = board.ToJagged().Select(EvaluateRow).ToArray();
            var resultingBoard = rowResults.Select(x => x.Row).ToArray().ToMatrix();
            var movementResults = rowResults.Select(x => x.Movements).ToArray().ToMatrix();
            return new BoardResult(resultingBoard, movementResults);
        }

        public BoardResult MoveLeft() {
            var boardResult = EvaluateBoard(Board);
            Board = boardResult.Board;
            return boardResult;
        }

        public bool MoveRight() {
            var newBoard = EvaluateBoard(Board.RotateClockwise().RotateClockwise())
                .RotateCounterClockwise().RotateCounterClockwise();
            var moved = !newBoard.Cast<Element>().SequenceEqual(Board.Cast<Element>());
            Board = newBoard;
            return moved;
        }

        public BoardResult MoveDown() {
            var boardResult = EvaluateBoard(Board.RotateClockwise()).RotateCounterClockwise(); 
            Board = boardResult.Board;
            return boardResult;
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
