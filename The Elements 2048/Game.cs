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

    }
}
