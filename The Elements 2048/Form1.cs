using System;
using System.Drawing;
using System.Windows.Forms;
using GameEssentials;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace The_Elements_2048
{
    public partial class GameWindow : Form
    {
        Game game;
        bool isMoving;

        List<Animation> animations = new List<Animation>();

        int highscore;

        public GameWindow()
        {
            InitializeComponent();
            try
            {
                highscore = GameDataSerializer<int>.Deserialize("TheElements2048");
            }
            catch (FileNotFoundException)
            {

            }
            lblBestValue.Text = highscore.ToString();
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
            NewGame();
        }

        private void GameWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (isMoving)
            {
                return;
            }

            if (e.KeyCode == Keys.Right)
            {
                var result = game.MoveRight();
                EvaluateBoardResult(result, IMovableDirection.Right);
            }
            else if (e.KeyCode == Keys.Left)
            {
                var result = game.MoveLeft();
                EvaluateBoardResult(result, IMovableDirection.Left);
            }
            else if (e.KeyCode == Keys.Up)
            {
                var result = game.MoveDown();
                EvaluateBoardResult(result, IMovableDirection.Up);
            }
            else if (e.KeyCode == Keys.Down)
            {
                var result = game.MoveUp();
                EvaluateBoardResult(result, IMovableDirection.Down);
            }
        }

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

        void AnimateTile(int dx, int dy, PictureBox tile, Action completion)
        {
            if (dx != 0 && dy != 0)
            {
                throw new ArgumentException();
            }
            if (dx != 0)
            {
                var anim = new Animation(
                    x => tile.Location = new Point(x, tile.Location.Y),
                    tile.Location.X,
                    tile.Location.X + dx * 115,
                    0.1,
                    OnMoveComplete);
                animations.Add(anim);
                anim.Start();
            }
            else
            {
                var anim = new Animation(
                    y => tile.Location = new Point(tile.Location.X, y),
                    tile.Location.Y,
                    tile.Location.Y + dy * 115,
                    0.1,
                    OnMoveComplete);
                animations.Add(anim);
                anim.Start();
            }
        }

        void EvaluateBoardResult(BoardResult result, IMovableDirection direction)
        {
            int dx = 0, dy = 0;

            if (!result.Movements.Any(x => x.DistanceMoved > 0))
            {
                return;
            }

            isMoving = true;

            switch (direction)
            {
                case IMovableDirection.Down:
                    (dx, dy) = (0, 1);
                    break;
                case IMovableDirection.Left:
                    (dx, dy) = (-1, 0);
                    break;
                case IMovableDirection.Right:
                    (dx, dy) = (1, 0);
                    break;
                case IMovableDirection.Up:
                    (dx, dy) = (0, -1);
                    break;
            }
            foreach (var pictureBox in panel1.Controls.OfType<PictureBox>().Where(x => x.Tag is BoardPosition))
            {
                var pos = (BoardPosition)pictureBox.Tag;
                var movement = result.Movements[pos.X, pos.Y];
                Action completion = null;
                var mergedPictures = new List<PictureBox>();

                var newX = pos.X + movement.DistanceMoved * dx;
                var newY = pos.Y + movement.DistanceMoved * dy;

                if (movement.Merged)
                {
                    var mergedTo = result.Board[newX, newY];
                    mergedPictures.Add(pictureBox);
                    completion = () => pictureBox.Image = TheElements2048Utility.ElementImageDictionary[mergedTo];
                }
                pos.X = newX;
                pos.Y = newY;
                completion += OnMoveComplete;
                AnimateTile(dx * movement.DistanceMoved, dy * movement.DistanceMoved, pictureBox, completion);
            }
        }

        void OnMoveComplete()
        {
            if (isMoving)
            {
                isMoving = false;
                game.SpawnNewElement();
                Redraw();
                lblScoreValue.Text = game.Score.ToString();
                animations.Clear();
                if (IsGameOver())
                {
                    MessageBox.Show("Game Over!", "The Elements 2048");

                    if (game.Score > highscore)
                    {
                        highscore = game.Score;
                        GameDataSerializer<int>.Serialize(highscore, "TheElements2048");
                        lblBestValue.Text = highscore.ToString();
                    }
                }
            }
        }

        bool IsGameOver() {
            if (game.Board.Any(x => x == Element.None)) {
                return false;
            }
            foreach (var row in game.Board.ToJagged()) {
                if (Enumerable.Range(0, row.Length - 1).Select(x => row[x] == row[x + 1]).Any(x => x)) {
                    return false;
                }
            }
            foreach (var row in game.Board.RotateClockwise().ToJagged()) {
                if (Enumerable.Range(0, row.Length - 1).Select(x => row[x] == row[x + 1]).Any(x => x)) {
                    return false;
                }
            }
            return true;
        }
    }
}
