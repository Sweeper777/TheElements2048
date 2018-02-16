using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Elements_2048 {
    public class Game : IDisposable {
        /// <summary>
        /// A panel to put all the tiles in.
        /// </summary>
        private Panel panel;

        /// <summary>
        /// Housekeeping for Score.
        /// </summary>
        private int score;

        /// <summary>
        /// Housekeeping for Highscore.
        /// </summary>
        private int highscore;

        /// <summary>
        /// Indicates whether the player has already won.
        /// </summary>
        private bool hasWon = false;

        private EventHandler scoreChanged, highscoreChanged;

        /// <summary>
        /// Gets or sets the current score of the game.
        /// </summary>
        public int Score {
            get { return score; }
            set {
                score = value;
                try {
                    this.ScoreChanged (this, EventArgs.Empty);
                } catch (NullReferenceException) { }
                if (Score > Highscore) {
                    Highscore = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the highscore.
        /// </summary>
        public int Highscore {
            get { return this.highscore; }
            set {
                highscore = value;
                try {
                    this.HighscoreChanged (this, EventArgs.Empty);
                } catch (NullReferenceException) { }
                GameEssentials.GameDataSerializer<int>.Serialize (value, "The Elements 2048");
            }
        }

        /// <summary>
        /// Gets the current game.
        /// </summary>
        public static Game Current {
            get;
            private set;
        }

        /// <summary>
        /// Gets a matrix of tiles from the game board.
        /// </summary>
        public Tile[,] TileMatrix {
            get {
                Tile[,] matrix = new Tile[4, 4];
                foreach (Tile tile in this.TileList) {
                    matrix[tile.X, tile.Y] = tile;
                }
                return matrix;
            }
        }

        /// <summary>
        /// Gets a list of all the tiles on the ame board.
        /// </summary>
        public List<Tile> TileList {
            get;
            private set;
        }

        /// <summary>
        /// Gets a list of all the empty locations on the game board.
        /// </summary>
        public List<Point> EmptyLocations {
            get {
                List<Point> emptyPoints = new List<Point> ();
                for (int x = 0 ; x < 4 ; x++) {
                    for (int y = 0 ; y < 4 ; y++) {
                        if (this.TileMatrix[x, y] == null) {
                            emptyPoints.Add (new Point (x, y));
                        }
                    }
                }
                return emptyPoints;
            }
        }

        /// <summary>
        /// Gets whether any tile on the board is moving.
        /// </summary>
        public bool AreTilesMoving {
            get {
                foreach (Tile tile in TileList) {
                    if (tile.IsMoving)
                        return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Gets or sets whether the game needs to add another tile after this move.
        /// </summary>
        public bool NeedToAddTile {
            get;
            set;
        }

        /// <summary>
        /// Initializes the Game.Current property.
        /// </summary>
        public static void CreateNewGame (Panel panel, EventHandler scoreChanged, EventHandler highscoreChanged, Label lblHighscore = null) {
            Game.Current = new Game (panel, lblHighscore, scoreChanged, highscoreChanged);
        }

        /// <summary>
        /// Creates a new instance of the game class.
        /// </summary>
        /// <param name="panel"></param>
        private Game (Panel panel, Label lblHighscore, EventHandler scoreChanged, EventHandler highscoreChanged) {
            this.TileList = new List<Tile> ();
            this.panel = panel;
            this.scoreChanged = scoreChanged;
            this.highscoreChanged = highscoreChanged;

            for (int i = 0 ; i < 2 ; i++) {
                AddTile ();
            }

            while (this.EmptyLocations.Count == 15 && this.TileList.Count == 2) {
                this.TileList.RemoveAt (1);
                AddTile ();
            }
            Tile.FinishedMoving += OnFinishedMoving;

            string folderPath = GameEssentials.GameDataSerializer<int>.BASE_FOLDER_PATH + "\\The Elements 2048";
            Console.WriteLine(folderPath);
            if (Directory.Exists (folderPath) && File.Exists (folderPath + "\\gameData.dat")) {
                int highscoreRead = GameEssentials.GameDataSerializer<int>.Deserialize ("The Elements 2048");
                this.highscore = highscoreRead;
            } else {
                this.highscore = 0;
            }
            this.Score = 0;
            if (lblHighscore != null)
                lblHighscore.Text = this.Highscore.ToString ();
            this.hasWon = false;
            this.NeedToAddTile = true;
            this.HighscoreChanged += highscoreChanged;
            this.ScoreChanged += scoreChanged;
        }

        /// <summary>
        /// Add a tile to the board.
        /// </summary>
        public void AddTile () {
            int x = 0;
            int y = 0;
            Random r = new Random ();
            x = this.EmptyLocations[r.Next (EmptyLocations.Count)].X;
            y = this.EmptyLocations[r.Next (EmptyLocations.Count)].Y;
            x = x * 100 + ( x + 1 ) * 15;
            y = y * 100 + ( y + 1 ) * 15;
            Element ele = r.Next (3) > 0 ? Element.Hydrogen : Element.Helium;
            this.TileList.Add (new Tile (new Point (x, y), panel, ele));

            //Check whether the game is over.
            if (this.TileList.Count == 16) {
                foreach (Tile tile in TileList) {
                    if (tile.CanMergeAdjTiles)
                        return;
                }
                Thread.Sleep (1000);
                MessageBox.Show ("Game Over!\r\nYour score: " + this.Score, "The Elements 2048");
                this.Dispose ();
                Game.CreateNewGame (panel, scoreChanged, highscoreChanged);
            }
        }

        private void OnFinishedMoving (object sender, EventArgs e) {
            //Console.WriteLine ("FinishedMoving event occured");
            if (NeedToAddTile) {
                this.AddTile ();
                this.NeedToAddTile = false;
            }
        }

        /// <summary>
        /// Is called when two tiles merge.
        /// </summary>
        /// <param name="sender">The tile that merges into another one.</param>
        /// <param name="mergeInto">The tile that is merged into.</param>
        public void OnMerge (Tile sender, Tile mergeInto) {
            this.TileList.Remove (sender);
            this.panel.Controls.Remove (( sender ).Picture);
            this.Score += TheElements2048Utility.GetElementScoreDictionary ()[mergeInto.ElementType];
            if (mergeInto.ElementType == Element.Sodium && !hasWon) {
                DialogResult result = MessageBox.Show ("You win!\r\nDo you want to restart?", "The Elements 2048", MessageBoxButtons.YesNo);
                hasWon = true;
                if (result == DialogResult.Yes) {
                    this.Dispose ();
                    Game.CreateNewGame (panel, scoreChanged, highscoreChanged);
                }
            }
        }

        public void Dispose () {
            panel.Controls.Clear ();
            this.TileList = null;
            this.Score = 0;
        }

        /// <summary>
        /// Occurs when the current score changed.
        /// </summary>
        public event EventHandler ScoreChanged;

        /// <summary>
        /// Occurs when the highscore changed.
        /// </summary>
        public event EventHandler HighscoreChanged;
    }
}
