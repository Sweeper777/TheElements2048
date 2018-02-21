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

        public List<(int x, int y)> EmptySpaces { 
            get {
                var emptySpaces = new List<(int x, int y)>();
                for (int i = 0; i < Board.GetLength(0); i++) {
                    for (int j = 0; j < Board.GetLength(1); j++) {
                        if (Board[i, j] == Element.None) {
                            emptySpaces.Add((i, j));
                        }
                    }
                }
                return emptySpaces;
            }
        }

        public void SpawnNewElement() {
            var emptySpaces = EmptySpaces;
            var randomEmptySpace = emptySpaces[random.Next(emptySpaces.Count)];
            var newElement = random.Next(3) == 0 ? Element.Helium : Element.Hydrogen;
            Board[randomEmptySpace.x, randomEmptySpace.y] = newElement;
        }

        Element[] EvaluateRow(Element[] row) {
            StringBuilder rowString = new StringBuilder(RowToString(row));
            rowString.Replace("`", "");
            var regex = new Regex("([a-p])\\1");
            int lastIndex = -1;
            while (true) {
                var match = regex.Match(rowString.ToString(), lastIndex + 1);
                if (match.Success) {
                    char newChar = (char)(match.Value[0] + 1);
                    rowString.Remove(match.Index, match.Length);
                    rowString.Insert(match.Index, newChar);
                    lastIndex = match.Index;

                    Score += TheElements2048Utility.ElementScoreDictionary[(Element)(newChar - 96)];
                } else {
                    break;
                }
            }
            return StringToRow(rowString.ToString());
        }

        string RowToString(Element[] row) {
            return string.Concat(row.Select(x => (char)(x + 96)));
        }

        Element[] StringToRow(string str) {
            return str.PadRight(boardSize, '`').Select(x => (Element)(x - 96)).ToArray();
        }

    }
}
