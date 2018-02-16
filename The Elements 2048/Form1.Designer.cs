namespace The_Elements_2048 {
    partial class GameWindow {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing) {
            if (disposing && ( components != null )) {
                components.Dispose ();
            }
            base.Dispose (disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent () {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameWindow));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNewGame = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblScoreValue = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblBestValue = new System.Windows.Forms.Label();
            this.lblBest = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(58, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(375, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "The Elements 2048";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(69, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(344, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Join the elements and get to the Sodium tile!";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::The_Elements_2048.Properties.Resources.gameBoard;
            this.panel1.Location = new System.Drawing.Point(12, 146);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(475, 475);
            this.panel1.TabIndex = 1;
            // 
            // btnNewGame
            // 
            this.btnNewGame.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnNewGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewGame.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewGame.ForeColor = System.Drawing.Color.White;
            this.btnNewGame.Location = new System.Drawing.Point(12, 85);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(175, 49);
            this.btnNewGame.TabIndex = 3;
            this.btnNewGame.Text = "New Game";
            this.btnNewGame.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnNewGame.Click += new System.EventHandler(this.label3_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Controls.Add(this.lblScoreValue);
            this.panel2.Controls.Add(this.lblScore);
            this.panel2.Location = new System.Drawing.Point(193, 77);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(126, 63);
            this.panel2.TabIndex = 4;
            // 
            // lblScoreValue
            // 
            this.lblScoreValue.BackColor = System.Drawing.Color.Transparent;
            this.lblScoreValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScoreValue.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScoreValue.ForeColor = System.Drawing.Color.White;
            this.lblScoreValue.Location = new System.Drawing.Point(0, 22);
            this.lblScoreValue.Name = "lblScoreValue";
            this.lblScoreValue.Size = new System.Drawing.Size(126, 41);
            this.lblScoreValue.TabIndex = 1;
            this.lblScoreValue.Text = "0";
            this.lblScoreValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblScore
            // 
            this.lblScore.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblScore.Font = new System.Drawing.Font("Arial Black", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblScore.Location = new System.Drawing.Point(0, 0);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(126, 22);
            this.lblScore.TabIndex = 0;
            this.lblScore.Text = "SCORE";
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gray;
            this.panel3.Controls.Add(this.lblBestValue);
            this.panel3.Controls.Add(this.lblBest);
            this.panel3.Location = new System.Drawing.Point(325, 77);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(126, 63);
            this.panel3.TabIndex = 5;
            // 
            // lblBestValue
            // 
            this.lblBestValue.BackColor = System.Drawing.Color.Transparent;
            this.lblBestValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBestValue.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBestValue.ForeColor = System.Drawing.Color.White;
            this.lblBestValue.Location = new System.Drawing.Point(0, 22);
            this.lblBestValue.Name = "lblBestValue";
            this.lblBestValue.Size = new System.Drawing.Size(126, 41);
            this.lblBestValue.TabIndex = 1;
            this.lblBestValue.Text = "0";
            this.lblBestValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBest
            // 
            this.lblBest.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBest.Font = new System.Drawing.Font("Arial Black", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblBest.Location = new System.Drawing.Point(0, 0);
            this.lblBest.Name = "lblBest";
            this.lblBest.Size = new System.Drawing.Size(126, 22);
            this.lblBest.TabIndex = 0;
            this.lblBest.Text = "BEST";
            this.lblBest.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(504, 633);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "GameWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "The Elements 2048";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameWindow_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label btnNewGame;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblScoreValue;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblBestValue;
        private System.Windows.Forms.Label lblBest;
    }
}

