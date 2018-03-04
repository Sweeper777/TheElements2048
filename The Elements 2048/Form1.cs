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
        }
}
