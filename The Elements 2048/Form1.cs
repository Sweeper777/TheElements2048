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

            var animation = new Animation
            {
                DurationInFrames = Animation.FromTimeSpanToDurationInFrames(0.05),
                EasingFunction = ef => Easing.EaseInOut(ef, EasingType.Quadratic)
            };
            if (dx != 0)
            {
                animation.AnimateOnControlThread(
                    this,
                    ObservableHelper.FixedValue((float)tile.Location.X),
                    ObservableHelper.FixedValue((float)tile.Location.X + 115 * dx),
                    v => tile.Location = new Point((int)v.CurrentValue, tile.Location.Y),
                    completion
                );
            }
            else
            {
                animation.AnimateOnControlThread(
                    this,
                    ObservableHelper.FixedValue((float)tile.Location.Y),
                    ObservableHelper.FixedValue((float)tile.Location.Y + 115 * dy),
                    v => tile.Location = new Point(tile.Location.X, (int)v.CurrentValue),
                    completion
                );
            }
            animation.Start();
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
        }
        }
}
