using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Elements_2048 {
    public partial class GameWindow : Form {
        public GameWindow () {
            InitializeComponent ();
            //Game.CreateNewGame (this.panel1, Current_ScoreChanged, Current_HighscoreChanged, this.lblBestValue);
        }

        //void Current_HighscoreChanged (object sender, EventArgs e) {
        //    this.lblBestValue.Text = Game.Current.Highscore.ToString ();
        //}

        //void Current_ScoreChanged (object sender, EventArgs e) {
        //    this.lblScoreValue.Text = Game.Current.Score.ToString ();
        //}

        private void label3_Click (object sender, EventArgs e) {
        //    Game.Current.Dispose ();
        //    Game.CreateNewGame (this.panel1, Current_ScoreChanged, Current_HighscoreChanged);
        //    this.lblScoreValue.Text = "0";
        }

        private void GameWindow_KeyDown (object sender, KeyEventArgs e) {
            //if (Game.Current.AreTilesMoving) {
            //    return;
            //}

            //if (e.KeyCode == Keys.Right) {
            //    Tile.Tile_FinishedMoving (null, null);
            //    Right ();
            //} else if (e.KeyCode == Keys.Left) {
            //    Tile.Tile_FinishedMoving (null, null);
            //    Left ();
            //} else if (e.KeyCode == Keys.Up) {
            //    Tile.Tile_FinishedMoving (null, null);
            //    Up ();
            //} else if (e.KeyCode == Keys.Down) {
            //    Tile.Tile_FinishedMoving (null, null);
            //    Down ();
            //} else if (e.KeyCode == Keys.B) {
            //    ;
            //}
        }
    }
}
