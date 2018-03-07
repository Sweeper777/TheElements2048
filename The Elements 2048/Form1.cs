using System;
using System.Drawing;
using System.Windows.Forms;
using ReactiveAnimation;
using GameEssentials;
using System.Linq;
using System.Collections.Generic;

namespace The_Elements_2048
{
    public partial class GameWindow : Form
    {
        Game game;
        public GameWindow()
        {
            InitializeComponent();
            NewGame();
            //Game.CreateNewGame (this.panel1, Current_ScoreChanged, Current_HighscoreChanged, this.lblBestValue);
        }

        //void Current_HighscoreChanged (object sender, EventArgs e) {
        //    this.lblBestValue.Text = Game.Current.Highscore.ToString ();
        //}

        //void Current_ScoreChanged (object sender, EventArgs e) {
        //    this.lblScoreValue.Text = Game.Current.Score.ToString ();
        //}

        private void label3_Click(object sender, EventArgs e)
        {
            //    Game.Current.Dispose ();
            //    Game.CreateNewGame (this.panel1, Current_ScoreChanged, Current_HighscoreChanged);
            //    this.lblScoreValue.Text = "0";
        }

        private void GameWindow_KeyDown(object sender, KeyEventArgs e)
        {
        void NewGame()
        {
            game = new Game();
            game.SpawnNewElement(true);
            game.SpawnNewElement(true);
            Redraw();
        }

        void Redraw()
        {
            panel1.Controls.Clear();
            for (int i = 0; i < game.Board.GetLength(0); i++)
            {
                for (int j = 0; j < game.Board.GetLength(1); j++)
                {
                    if (game.Board[i, j] != Element.None)
                    {
                        var pictureBox = new PictureBox();
                        pictureBox.Image = TheElements2048Utility.ElementImageDictionary[game.Board[i, j]];
                        pictureBox.Location = GetPositionForCoordinate(i, j);
                        pictureBox.Size = new Size(100, 100);
                        pictureBox.Tag = new BoardPosition(i, j);
                        panel1.Controls.Add(pictureBox);
                    }
                }
            }
        }

        Point GetPositionForCoordinate(int x, int y)
        {
            return new Point(
                x * 100 + (x + 1) * 15,
                y * 100 + (y + 1) * 15
            );
        }

        }
}
