namespace MiniGameParty2
{
    partial class CardMatchingGame
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
            lblStatus = new System.Windows.Forms.Label();
            lblTimeLeft = new System.Windows.Forms.Label();
            timer1 = new System.Windows.Forms.Timer(components);
            label1 = new System.Windows.Forms.Label();
            timer2 = new System.Windows.Forms.Timer(components);
            label2 = new System.Windows.Forms.Label();
            p1_score = new System.Windows.Forms.Label();
            p2_score = new System.Windows.Forms.Label();
            plturn = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new System.Drawing.Point(994, 9);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new System.Drawing.Size(113, 15);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Match or Mismatch";
            lblStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTimeLeft
            // 
            lblTimeLeft.AutoSize = true;
            lblTimeLeft.Location = new System.Drawing.Point(994, 37);
            lblTimeLeft.Name = "lblTimeLeft";
            lblTimeLeft.Size = new System.Drawing.Size(57, 15);
            lblTimeLeft.TabIndex = 1;
            lblTimeLeft.Text = "Time Left";
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(994, 128);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(46, 30);
            label1.TabIndex = 3;
            label1.Text = "Player1\r\nscore : ";
            // 
            // timer2
            // 
            timer2.Interval = 1000;
            timer2.Tick += timer2_Tick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(994, 180);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(46, 30);
            label2.TabIndex = 3;
            label2.Text = "Player2\r\nscore : ";
            // 
            // p1_score
            // 
            p1_score.AutoSize = true;
            p1_score.Location = new System.Drawing.Point(1046, 143);
            p1_score.Name = "p1_score";
            p1_score.Size = new System.Drawing.Size(12, 15);
            p1_score.TabIndex = 3;
            p1_score.Text = "-";
            // 
            // p2_score
            // 
            p2_score.AutoSize = true;
            p2_score.Location = new System.Drawing.Point(1046, 195);
            p2_score.Name = "p2_score";
            p2_score.Size = new System.Drawing.Size(12, 15);
            p2_score.TabIndex = 3;
            p2_score.Text = "-";
            // 
            // plturn
            // 
            plturn.AutoSize = true;
            plturn.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            plturn.ForeColor = System.Drawing.Color.Blue;
            plturn.Location = new System.Drawing.Point(472, 618);
            plturn.Name = "plturn";
            plturn.Size = new System.Drawing.Size(20, 25);
            plturn.TabIndex = 4;
            plturn.Text = "-";
            // 
            // CardMatchingGame
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1134, 689);
            Controls.Add(plturn);
            Controls.Add(label2);
            Controls.Add(p2_score);
            Controls.Add(p1_score);
            Controls.Add(label1);
            Controls.Add(lblTimeLeft);
            Controls.Add(lblStatus);
            Name = "CardMatchingGame";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "CardMatching";
            FormClosed += CardMatchingGame_FormClosed;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblTimeLeft;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label p1_score;
        private System.Windows.Forms.Label p2_score;
        private System.Windows.Forms.Label plturn;
    }
}
