namespace flaminhotdoritosnake
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnStart = new System.Windows.Forms.Button();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.btnPause = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.btnConfirmSettings = new System.Windows.Forms.Button();
            this.rbTwoPlayer = new System.Windows.Forms.RadioButton();
            this.rbOnePlayer = new System.Windows.Forms.RadioButton();
            this.nudGameSpeed = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.cdSnakeColor = new System.Windows.Forms.ColorDialog();
            this.gbColours = new System.Windows.Forms.GroupBox();
            this.btnColP2 = new System.Windows.Forms.Button();
            this.btnColP1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTies = new System.Windows.Forms.TextBox();
            this.txtP2Wins = new System.Windows.Forms.TextBox();
            this.txtP1Wins = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnResetHighScore = new System.Windows.Forms.Button();
            this.txtP1HighScore = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pbBoard = new System.Windows.Forms.PictureBox();
            this.lblScore = new System.Windows.Forms.Label();
            this.gbSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGameSpeed)).BeginInit();
            this.gbColours.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(618, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(88, 34);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // gameTimer
            // 
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // btnPause
            // 
            this.btnPause.Enabled = false;
            this.btnPause.Location = new System.Drawing.Point(618, 68);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(88, 34);
            this.btnPause.TabIndex = 2;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnReset
            // 
            this.btnReset.Enabled = false;
            this.btnReset.Location = new System.Drawing.Point(618, 124);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(88, 34);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // gbSettings
            // 
            this.gbSettings.Controls.Add(this.btnConfirmSettings);
            this.gbSettings.Controls.Add(this.rbTwoPlayer);
            this.gbSettings.Controls.Add(this.rbOnePlayer);
            this.gbSettings.Controls.Add(this.nudGameSpeed);
            this.gbSettings.Controls.Add(this.label1);
            this.gbSettings.Location = new System.Drawing.Point(712, 12);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Size = new System.Drawing.Size(150, 146);
            this.gbSettings.TabIndex = 4;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Game Settings";
            // 
            // btnConfirmSettings
            // 
            this.btnConfirmSettings.Location = new System.Drawing.Point(9, 112);
            this.btnConfirmSettings.Name = "btnConfirmSettings";
            this.btnConfirmSettings.Size = new System.Drawing.Size(135, 23);
            this.btnConfirmSettings.TabIndex = 4;
            this.btnConfirmSettings.Text = "Confirm Settings";
            this.btnConfirmSettings.UseVisualStyleBackColor = true;
            this.btnConfirmSettings.Click += new System.EventHandler(this.btnConfirmSettings_Click);
            // 
            // rbTwoPlayer
            // 
            this.rbTwoPlayer.AutoSize = true;
            this.rbTwoPlayer.Location = new System.Drawing.Point(9, 86);
            this.rbTwoPlayer.Name = "rbTwoPlayer";
            this.rbTwoPlayer.Size = new System.Drawing.Size(63, 17);
            this.rbTwoPlayer.TabIndex = 3;
            this.rbTwoPlayer.Text = "2 Player";
            this.rbTwoPlayer.UseVisualStyleBackColor = true;
            // 
            // rbOnePlayer
            // 
            this.rbOnePlayer.AutoSize = true;
            this.rbOnePlayer.Checked = true;
            this.rbOnePlayer.Location = new System.Drawing.Point(9, 63);
            this.rbOnePlayer.Name = "rbOnePlayer";
            this.rbOnePlayer.Size = new System.Drawing.Size(63, 17);
            this.rbOnePlayer.TabIndex = 2;
            this.rbOnePlayer.TabStop = true;
            this.rbOnePlayer.Text = "1 Player";
            this.rbOnePlayer.UseVisualStyleBackColor = true;
            // 
            // nudGameSpeed
            // 
            this.nudGameSpeed.Location = new System.Drawing.Point(9, 37);
            this.nudGameSpeed.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudGameSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudGameSpeed.Name = "nudGameSpeed";
            this.nudGameSpeed.Size = new System.Drawing.Size(135, 20);
            this.nudGameSpeed.TabIndex = 1;
            this.nudGameSpeed.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Game Speed (Milliseconds):";
            // 
            // gbColours
            // 
            this.gbColours.Controls.Add(this.btnColP2);
            this.gbColours.Controls.Add(this.btnColP1);
            this.gbColours.Location = new System.Drawing.Point(656, 164);
            this.gbColours.Name = "gbColours";
            this.gbColours.Size = new System.Drawing.Size(178, 91);
            this.gbColours.TabIndex = 5;
            this.gbColours.TabStop = false;
            this.gbColours.Text = "Change Colour";
            // 
            // btnColP2
            // 
            this.btnColP2.Location = new System.Drawing.Point(9, 56);
            this.btnColP2.Name = "btnColP2";
            this.btnColP2.Size = new System.Drawing.Size(163, 23);
            this.btnColP2.TabIndex = 1;
            this.btnColP2.Text = "Change Player 2";
            this.btnColP2.UseVisualStyleBackColor = true;
            this.btnColP2.Click += new System.EventHandler(this.btnColP2_Click);
            // 
            // btnColP1
            // 
            this.btnColP1.Location = new System.Drawing.Point(9, 19);
            this.btnColP1.Name = "btnColP1";
            this.btnColP1.Size = new System.Drawing.Size(163, 23);
            this.btnColP1.TabIndex = 0;
            this.btnColP1.Text = "Change Player 1";
            this.btnColP1.UseVisualStyleBackColor = true;
            this.btnColP1.Click += new System.EventHandler(this.btnColP1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTies);
            this.groupBox1.Controls.Add(this.txtP2Wins);
            this.groupBox1.Controls.Add(this.txtP1Wins);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(633, 367);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(223, 103);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Scoreboard (2 Player)";
            // 
            // txtTies
            // 
            this.txtTies.Location = new System.Drawing.Point(94, 72);
            this.txtTies.Name = "txtTies";
            this.txtTies.ReadOnly = true;
            this.txtTies.Size = new System.Drawing.Size(113, 20);
            this.txtTies.TabIndex = 5;
            this.txtTies.TabStop = false;
            // 
            // txtP2Wins
            // 
            this.txtP2Wins.Location = new System.Drawing.Point(94, 46);
            this.txtP2Wins.Name = "txtP2Wins";
            this.txtP2Wins.ReadOnly = true;
            this.txtP2Wins.Size = new System.Drawing.Size(113, 20);
            this.txtP2Wins.TabIndex = 4;
            this.txtP2Wins.TabStop = false;
            // 
            // txtP1Wins
            // 
            this.txtP1Wins.Location = new System.Drawing.Point(107, 20);
            this.txtP1Wins.Name = "txtP1Wins";
            this.txtP1Wins.ReadOnly = true;
            this.txtP1Wins.Size = new System.Drawing.Size(100, 20);
            this.txtP1Wins.TabIndex = 3;
            this.txtP1Wins.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Obsidian Ties:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Ice Cold Wins:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Flamin Hot Wins:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnResetHighScore);
            this.groupBox2.Controls.Add(this.txtP1HighScore);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(633, 261);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(223, 100);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Scoreboard (1 Player)";
            // 
            // btnResetHighScore
            // 
            this.btnResetHighScore.Location = new System.Drawing.Point(37, 54);
            this.btnResetHighScore.Name = "btnResetHighScore";
            this.btnResetHighScore.Size = new System.Drawing.Size(141, 36);
            this.btnResetHighScore.TabIndex = 2;
            this.btnResetHighScore.Text = "Reset HighScore";
            this.btnResetHighScore.UseVisualStyleBackColor = true;
            this.btnResetHighScore.Click += new System.EventHandler(this.btnResetHighScore_Click);
            // 
            // txtP1HighScore
            // 
            this.txtP1HighScore.Location = new System.Drawing.Point(80, 25);
            this.txtP1HighScore.Name = "txtP1HighScore";
            this.txtP1HighScore.ReadOnly = true;
            this.txtP1HighScore.Size = new System.Drawing.Size(127, 20);
            this.txtP1HighScore.TabIndex = 1;
            this.txtP1HighScore.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "HighScore:";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::flaminhotdoritosnake.Properties.Resources.icecold;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(748, 476);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(115, 140);
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::flaminhotdoritosnake.Properties.Resources.flaminhot;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(626, 476);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(115, 140);
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // pbBoard
            // 
            this.pbBoard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbBoard.Location = new System.Drawing.Point(12, 19);
            this.pbBoard.Name = "pbBoard";
            this.pbBoard.Size = new System.Drawing.Size(602, 602);
            this.pbBoard.TabIndex = 0;
            this.pbBoard.TabStop = false;
            this.pbBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.pbBoard_Paint);
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(542, 5);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(55, 13);
            this.lblScore.TabIndex = 11;
            this.lblScore.Text = "Score: 0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(874, 672);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbColours);
            this.Controls.Add(this.gbSettings);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.pbBoard);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Snake";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGameSpeed)).EndInit();
            this.gbColours.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBoard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbBoard;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox gbSettings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudGameSpeed;
        private System.Windows.Forms.RadioButton rbTwoPlayer;
        private System.Windows.Forms.RadioButton rbOnePlayer;
        private System.Windows.Forms.Button btnConfirmSettings;
        private System.Windows.Forms.ColorDialog cdSnakeColor;
        private System.Windows.Forms.GroupBox gbColours;
        private System.Windows.Forms.Button btnColP2;
        private System.Windows.Forms.Button btnColP1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTies;
        private System.Windows.Forms.TextBox txtP2Wins;
        private System.Windows.Forms.TextBox txtP1Wins;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnResetHighScore;
        private System.Windows.Forms.TextBox txtP1HighScore;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblScore;
    }
}

