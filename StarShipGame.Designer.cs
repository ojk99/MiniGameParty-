namespace MiniGameParty
{
    partial class StarShipGame
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pictureBox2 = new System.Windows.Forms.PictureBox();
            pictureBox3 = new System.Windows.Forms.PictureBox();
            pb_starship = new System.Windows.Forms.PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            fireTimer = new System.Windows.Forms.Timer(components);
            move = new System.Windows.Forms.Timer(components);
            timelimit = new System.Windows.Forms.Timer(components);
            etimer = new System.Windows.Forms.Timer(components);
            lb_score = new System.Windows.Forms.Label();
            lb_gameover = new System.Windows.Forms.Label();
            lb_time = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_starship).BeginInit();
            SuspendLayout();
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.Stars;
            pictureBox2.Location = new System.Drawing.Point(-10, -479);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(700, 900);
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.Stars;
            pictureBox3.Location = new System.Drawing.Point(-10, 409);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new System.Drawing.Size(700, 900);
            pictureBox3.TabIndex = 1;
            pictureBox3.TabStop = false;
            // 
            // pb_starship
            // 
            pb_starship.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            pb_starship.Image = Properties.Resources.starship1;
            pb_starship.Location = new System.Drawing.Point(279, 749);
            pb_starship.Name = "pb_starship";
            pb_starship.Size = new System.Drawing.Size(80, 100);
            pb_starship.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pb_starship.TabIndex = 2;
            pb_starship.TabStop = false;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // fireTimer
            // 
            fireTimer.Tick += fireTimer_Tick;
            // 
            // move
            // 
            move.Tick += move_Tick;
            // 
            // timelimit
            // 
            timelimit.Tick += timelimit_Tick;
            // 
            // etimer
            // 
            etimer.Tick += etimer_Tick;
            // 
            // lb_score
            // 
            lb_score.AutoSize = true;
            lb_score.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lb_score.ForeColor = System.Drawing.Color.Gold;
            lb_score.Image = Properties.Resources.Stars;
            lb_score.Location = new System.Drawing.Point(98, 9);
            lb_score.Name = "lb_score";
            lb_score.Size = new System.Drawing.Size(28, 32);
            lb_score.TabIndex = 3;
            lb_score.Text = "0";
            // 
            // lb_gameover
            // 
            lb_gameover.AutoSize = true;
            lb_gameover.BackColor = System.Drawing.Color.Transparent;
            lb_gameover.Font = new System.Drawing.Font("맑은 고딕", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lb_gameover.ForeColor = System.Drawing.Color.Gold;
            lb_gameover.Image = Properties.Resources.Stars;
            lb_gameover.Location = new System.Drawing.Point(194, 165);
            lb_gameover.Name = "lb_gameover";
            lb_gameover.Size = new System.Drawing.Size(284, 65);
            lb_gameover.TabIndex = 4;
            lb_gameover.Text = "Game Over";
            lb_gameover.Visible = false;
            // 
            // lb_time
            // 
            lb_time.AutoSize = true;
            lb_time.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            lb_time.ForeColor = System.Drawing.Color.Gold;
            lb_time.Image = Properties.Resources.Stars;
            lb_time.Location = new System.Drawing.Point(630, 9);
            lb_time.Name = "lb_time";
            lb_time.Size = new System.Drawing.Size(42, 32);
            lb_time.TabIndex = 5;
            lb_time.Text = "60";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Cursor = System.Windows.Forms.Cursors.No;
            label1.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.ForeColor = System.Drawing.Color.Gold;
            label1.Image = Properties.Resources.Stars;
            label1.Location = new System.Drawing.Point(12, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(91, 32);
            label1.TabIndex = 6;
            label1.Text = "Score :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label3.ForeColor = System.Drawing.Color.Gold;
            label3.Image = Properties.Resources.Stars;
            label3.Location = new System.Drawing.Point(12, 824);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(81, 25);
            label3.TabIndex = 8;
            label3.Text = "Attack :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label4.ForeColor = System.Drawing.Color.Gold;
            label4.Image = Properties.Resources.Stars;
            label4.Location = new System.Drawing.Point(87, 824);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(93, 25);
            label4.TabIndex = 9;
            label4.Text = "SpaceBar";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("맑은 고딕", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label2.ForeColor = System.Drawing.Color.Gold;
            label2.Image = Properties.Resources.Stars;
            label2.Location = new System.Drawing.Point(181, 141);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(314, 86);
            label2.TabIndex = 11;
            label2.Text = "Star Ship";
            // 
            // button1
            // 
            button1.Font = new System.Drawing.Font("맑은 고딕", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            button1.ForeColor = System.Drawing.Color.Gold;
            button1.Image = Properties.Resources.Stars;
            button1.Location = new System.Drawing.Point(243, 435);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(188, 109);
            button1.TabIndex = 10;
            button1.Text = "Start";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // StarShipGame
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(684, 861);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(lb_time);
            Controls.Add(lb_gameover);
            Controls.Add(lb_score);
            Controls.Add(pb_starship);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            KeyPreview = true;
            Name = "StarShipGame";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Form1";
            FormClosed += StarShipGame_FormClosed;
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            KeyUp += Form1_KeyUp;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_starship).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pb_starship;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer fireTimer;
        private System.Windows.Forms.Timer move;
        private System.Windows.Forms.Timer timelimit;
        private System.Windows.Forms.Timer etimer;
        private System.Windows.Forms.Label lb_score;
        private System.Windows.Forms.Label lb_gameover;
        private System.Windows.Forms.Label lb_time;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}
