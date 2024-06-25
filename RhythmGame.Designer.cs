namespace MiniParty4
{
    partial class RhythmGame
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
            timer1 = new System.Windows.Forms.Timer(components);
            button1 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            button4 = new System.Windows.Forms.Button();
            scoreLabel = new System.Windows.Forms.Label();
            timer2 = new System.Windows.Forms.Timer(components);
            timer3 = new System.Windows.Forms.Timer(components);
            timer4 = new System.Windows.Forms.Timer(components);
            lbPer = new System.Windows.Forms.Label();
            lbGreat = new System.Windows.Forms.Label();
            lbNice = new System.Windows.Forms.Label();
            lbFail = new System.Windows.Forms.Label();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            lbCombo = new System.Windows.Forms.Label();
            pictureBox2 = new System.Windows.Forms.PictureBox();
            pictureBox3 = new System.Windows.Forms.PictureBox();
            pictureBox4 = new System.Windows.Forms.PictureBox();
            lbtime = new System.Windows.Forms.Label();
            timer5 = new System.Windows.Forms.Timer(components);
            timer6 = new System.Windows.Forms.Timer(components);
            timer7 = new System.Windows.Forms.Timer(components);
            pictureBox5 = new System.Windows.Forms.PictureBox();
            PixLupy = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PixLupy).BeginInit();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += NoteTimer;
            // 
            // button1
            // 
            button1.Enabled = false;
            button1.Location = new System.Drawing.Point(50, 516);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(50, 25);
            button1.TabIndex = 0;
            button1.Text = "←";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Enabled = false;
            button2.Location = new System.Drawing.Point(100, 516);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(50, 25);
            button2.TabIndex = 1;
            button2.Text = "↑";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Enabled = false;
            button3.Location = new System.Drawing.Point(150, 516);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(50, 25);
            button3.TabIndex = 2;
            button3.Text = "↓";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Enabled = false;
            button4.Location = new System.Drawing.Point(200, 516);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(50, 25);
            button4.TabIndex = 3;
            button4.Text = "→";
            button4.UseVisualStyleBackColor = true;
            // 
            // scoreLabel
            // 
            scoreLabel.AutoSize = true;
            scoreLabel.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            scoreLabel.Location = new System.Drawing.Point(295, 9);
            scoreLabel.Name = "scoreLabel";
            scoreLabel.Size = new System.Drawing.Size(83, 32);
            scoreLabel.TabIndex = 4;
            scoreLabel.Text = "Score:";
            // 
            // timer2
            // 
            timer2.Interval = 1000;
            timer2.Tick += NoteTimer2;
            // 
            // timer3
            // 
            timer3.Interval = 1000;
            timer3.Tick += NoteTimer3;
            // 
            // timer4
            // 
            timer4.Interval = 1000;
            timer4.Tick += NoteTimer4;
            // 
            // lbPer
            // 
            lbPer.AutoSize = true;
            lbPer.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lbPer.Location = new System.Drawing.Point(295, 172);
            lbPer.Name = "lbPer";
            lbPer.Size = new System.Drawing.Size(17, 21);
            lbPer.TabIndex = 5;
            lbPer.Text = "-";
            // 
            // lbGreat
            // 
            lbGreat.AutoSize = true;
            lbGreat.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lbGreat.Location = new System.Drawing.Point(295, 234);
            lbGreat.Name = "lbGreat";
            lbGreat.Size = new System.Drawing.Size(17, 21);
            lbGreat.TabIndex = 6;
            lbGreat.Text = "-";
            // 
            // lbNice
            // 
            lbNice.AutoSize = true;
            lbNice.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lbNice.Location = new System.Drawing.Point(295, 287);
            lbNice.Name = "lbNice";
            lbNice.Size = new System.Drawing.Size(17, 21);
            lbNice.TabIndex = 7;
            lbNice.Text = "-";
            // 
            // lbFail
            // 
            lbFail.AutoSize = true;
            lbFail.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lbFail.Location = new System.Drawing.Point(295, 350);
            lbFail.Name = "lbFail";
            lbFail.Size = new System.Drawing.Size(17, 21);
            lbFail.TabIndex = 8;
            lbFail.Text = "-";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            pictureBox1.Location = new System.Drawing.Point(50, 500);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(200, 10);
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // lbCombo
            // 
            lbCombo.AutoSize = true;
            lbCombo.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lbCombo.Location = new System.Drawing.Point(295, 79);
            lbCombo.Name = "lbCombo";
            lbCombo.Size = new System.Drawing.Size(78, 25);
            lbCombo.TabIndex = 10;
            lbCombo.Text = "Combo";
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = System.Drawing.Color.FromArgb(192, 0, 192);
            pictureBox2.Location = new System.Drawing.Point(0, 460);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(50, 10);
            pictureBox2.TabIndex = 11;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = System.Drawing.Color.Blue;
            pictureBox3.Location = new System.Drawing.Point(0, 410);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new System.Drawing.Size(50, 10);
            pictureBox3.TabIndex = 12;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = System.Drawing.Color.Red;
            pictureBox4.Location = new System.Drawing.Point(0, 360);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new System.Drawing.Size(50, 10);
            pictureBox4.TabIndex = 13;
            pictureBox4.TabStop = false;
            // 
            // lbtime
            // 
            lbtime.AutoSize = true;
            lbtime.Location = new System.Drawing.Point(295, 128);
            lbtime.Name = "lbtime";
            lbtime.Size = new System.Drawing.Size(56, 15);
            lbtime.TabIndex = 14;
            lbtime.Text = "TimeLeft:";
            // 
            // timer5
            // 
            timer5.Interval = 60000;
            timer5.Tick += timer5_Tick;
            // 
            // timer6
            // 
            timer6.Interval = 65000;
            timer6.Tick += timer6_Tick_1;
            // 
            // timer7
            // 
            timer7.Interval = 1000;
            timer7.Tick += timer7_Tick;
            // 
            // pictureBox5
            // 
            pictureBox5.Location = new System.Drawing.Point(50, 580);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new System.Drawing.Size(200, 10);
            pictureBox5.TabIndex = 15;
            pictureBox5.TabStop = false;
            // 
            // PixLupy
            // 
            PixLupy.Location = new System.Drawing.Point(295, 378);
            PixLupy.Name = "PixLupy";
            PixLupy.Size = new System.Drawing.Size(147, 189);
            PixLupy.TabIndex = 16;
            PixLupy.TabStop = false;
            // 
            // RhythmGame
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(454, 606);
            Controls.Add(PixLupy);
            Controls.Add(pictureBox5);
            Controls.Add(lbtime);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(lbCombo);
            Controls.Add(pictureBox1);
            Controls.Add(lbFail);
            Controls.Add(lbNice);
            Controls.Add(lbGreat);
            Controls.Add(lbPer);
            Controls.Add(scoreLabel);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Cursor = System.Windows.Forms.Cursors.Hand;
            Name = "RhythmGame";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Form1";
            FormClosed += RhythmGame_FormClosed;
            Load += Form1_Load;
            Paint += Form1_Paint;
            KeyDown += Form1_KeyDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)PixLupy).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.Label lbPer;
        private System.Windows.Forms.Label lbGreat;
        private System.Windows.Forms.Label lbNice;
        private System.Windows.Forms.Label lbFail;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbCombo;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label lbtime;
        private System.Windows.Forms.Timer timer5;
        private System.Windows.Forms.Timer timer6;
        private System.Windows.Forms.Timer timer7;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox PixLupy;
    }
}
