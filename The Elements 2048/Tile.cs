using GameEssentials;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Elements_2048 {
    public class Tile : GameFigure {
        //Private members
        private const IMovableDirection UP = IMovableDirection.Up;
        private const IMovableDirection DOWN = IMovableDirection.Down;
        private const IMovableDirection LEFT = IMovableDirection.Left;
        private const IMovableDirection RIGHT = IMovableDirection.Right;

        /// <summary>
        /// The element of this tile.
        /// </summary>
        private Element element;

        /// <summary>
        /// The direction that the tile is going in.
        /// </summary>
        private IMovableDirection direction;

        /// <summary>
        /// Whether the tile can be merged into.
        /// </summary>
        private bool canMerge = true;

        /// <summary>
        /// Gets the tie that is on the right of this tile.
        /// </summary>
        private Tile RightTile {
            get {
                int targetedX = this.X + 1;
                int targetedY = this.Y;
                foreach (Tile tile in Game.Current.TileList) {
                    if (tile.X == targetedX && tile.Y == targetedY) {
                        return tile;
                    }
                }

                if (targetedX > 3)
                    throw new IndexOutOfRangeException ();

                return null;
            }
        }

        /// <summary>
        /// Gets the tie that is on the left of this tile.
        /// </summary>
        private Tile LeftTile {
            get {
                int targetedX = this.X - 1;
                int targetedY = this.Y;
                foreach (Tile tile in Game.Current.TileList) {
                    if (tile.X == targetedX && tile.Y == targetedY) {
                        return tile;
                    }
                }

                if (targetedX < 0)
                    throw new IndexOutOfRangeException ();

                return null;
            }
        }

        /// <summary>
        /// Gets the tie that is above this tile.
        /// </summary>
        private Tile UpTile {
            get {
                int targetedX = this.X;
                int targetedY = this.Y - 1;
                foreach (Tile tile in Game.Current.TileList) {
                    if (tile.X == targetedX && tile.Y == targetedY) {
                        return tile;
                    }
                }

                if (targetedY < 0)
                    throw new IndexOutOfRangeException ();

                return null;
            }
        }

        /// <summary>
        /// Gets the tie that is below this tile.
        /// </summary>
        private Tile DownTile {
            get {
                int targetedX = this.X;
                int targetedY = this.Y + 1;
                foreach (Tile tile in Game.Current.TileList) {
                    if (tile.X == targetedX && tile.Y == targetedY) {
                        return tile;
                    }
                }

                if (targetedY > 3)
                    throw new IndexOutOfRangeException ();

                return null;
            }
        }

        /// <summary>
        /// Gets or sets the X coordinate of the tile in the matrix.
        /// </summary>
        public int X {
            get;
            private set;
        }

        /// <summary>
        /// Gets whether the tile's adjcant tiles' ElementType is the same as this one.
        /// </summary>
        public bool CanMergeAdjTiles {
            get {
                foreach (Tile tile in AdjTiles.Values) {
                    if (tile.ElementType == this.ElementType && tile.ElementType != Element.Chlorine) {
                        return true;
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// Gets a dictionary that holds all the 
        /// </summary>
        private Dictionary<IMovableDirection, Tile> AdjTiles {
            get {
                Dictionary<IMovableDirection, Tile> returnVal = new Dictionary<IMovableDirection, Tile> ();
                try {
                    returnVal.Add (UP, UpTile);
                } catch (IndexOutOfRangeException) { }

                try {
                    returnVal.Add (DOWN, DownTile);
                } catch (IndexOutOfRangeException) { }

                try {
                    returnVal.Add (LEFT, LeftTile);
                } catch (IndexOutOfRangeException) { }

                try {
                    returnVal.Add (RIGHT, RightTile);
                } catch (IndexOutOfRangeException) { }
                return returnVal;
            }
        }

        /// <summary>
        /// Gets or sets the Y coordinate of the tile in the matrix.
        /// </summary>
        public int Y {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the element of this tile.
        /// </summary>
        public Element ElementType {
            get { return this.element; }
            set {
                this.element = value;
                this.picture.Image = TheElements2048Utility.GetElementImageDictionary ()[value];
            }
        }

        /// <summary>
        /// Get whether the tile is moving.
        /// </summary>
        public bool IsMoving {
            get;
            private set;
        }

        /// <summary>
        /// Gets the visual representation of the tile.
        /// </summary>
        public PictureBox Picture {
            get { return this.picture; }
        }

        /// <summary>
        /// Is called when the timer ticks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void Timer_Tick (object sender, EventArgs e) {
            const int SPEED = 115;
            switch (direction) {
                case DOWN:
                    this.picture.Top += SPEED;
                    break;
                case LEFT:
                    this.picture.Left -= SPEED;
                    break;
                case RIGHT:
                    this.picture.Left += SPEED;
                    break;
                case UP:
                    this.picture.Top -= SPEED;
                    break;
                default:
                    break;
            }
            this.timer.Stop ();
            if (!this.Move (direction)) {
                this.IsMoving = false;
                if (!Game.Current.AreTilesMoving)
                    FinishedMoving (this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Moves the tile.
        /// </summary>
        /// <param name="direction">The direction of the movement.</param>
        public bool Move (IMovableDirection direction) {
            this.direction = direction;
            try {
                Tile adjTile = AdjTiles[direction];
                if (adjTile == null)
                    goto moveTest;
                if (adjTile.ElementType != Element.Chlorine && adjTile.ElementType == this.ElementType && adjTile.canMerge) {
                    adjTile.OnMerge ();
                    Game.Current.OnMerge (this, adjTile);
                    adjTile.canMerge = false;
                    if (!Game.Current.AreTilesMoving)
                        FinishedMoving (this, EventArgs.Empty);
                    return true;
                } else {
                    return false;
                }
            } catch (KeyNotFoundException) {
                return false;
            }

            moveTest: {
                Tile adjTile = AdjTiles[direction];
                if (adjTile == null) {
                    this.timer.Start ();
                    this.IsMoving = true;

                    switch (direction) {
                        case DOWN:
                            this.Y++;
                            break;
                        case LEFT:
                            this.X--;
                            break;
                        case RIGHT:
                            this.X++;
                            break;
                        case UP:
                            this.Y--;
                            break;
                        default:
                            break;
                    }

                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Is called when another tile is merged with this tile.
        /// </summary>
        public void OnMerge () {
            int thisElement = (int)this.ElementType;
            thisElement++;
            this.ElementType = (Element)thisElement;
        }

        /// <summary>
        /// Creates a new instance of the tile class.
        /// </summary>
        /// <param name="location">The location of the tile.</param>
        /// <param name="control">The control to add the tile to</param>
        /// <param name="tileMatrix">A matrix that holds all the tiles on the game board.</param>
        public Tile (Point location, ScrollableControl control, Element element)
            : base (location, new Size (100, 100), TheElements2048Utility.GetElementImageDictionary ()[element], control, 1) {
            this.timer.Enabled = false;
            this.ElementType = element;
            this.X = location.X / 115;
            this.Y = location.Y / 115;
        }

        public static void Tile_FinishedMoving (object sender, EventArgs e) {
            foreach (Tile tile in Game.Current.TileList) {
                tile.canMerge = true;
            }
        }

        /// <summary>
        /// Occurs when a tile finishes its movement.
        /// </summary>
        public static event EventHandler FinishedMoving;
    }
}
