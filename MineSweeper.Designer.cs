namespace MiniGameParty
{
    partial class MineSweeper
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
            components = new System.ComponentModel.Container();
            label1 = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            lbScore = new System.Windows.Forms.Label();
            lbText = new System.Windows.Forms.Label();
            F_Map = new System.Windows.Forms.FlowLayoutPanel();
            timer1 = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(306, 17);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(83, 21);
            label1.TabIndex = 0;
            label1.Text = "깃발 : 0개";
            // 
            // panel1
            // 
            panel1.Controls.Add(lbScore);
            panel1.Controls.Add(lbText);
            panel1.Controls.Add(label1);
            panel1.Location = new System.Drawing.Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(403, 40);
            panel1.TabIndex = 1;
            // 
            // lbScore
            // 
            lbScore.AutoSize = true;
            lbScore.Font = new System.Drawing.Font("Segoe Print", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lbScore.ForeColor = System.Drawing.Color.DeepSkyBlue;
            lbScore.Location = new System.Drawing.Point(145, 7);
            lbScore.Name = "lbScore";
            lbScore.Size = new System.Drawing.Size(105, 37);
            lbScore.TabIndex = 2;
            lbScore.Text = "SCORE :";
            // 
            // lbText
            // 
            lbText.AutoSize = true;
            lbText.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lbText.ForeColor = System.Drawing.Color.Blue;
            lbText.Location = new System.Drawing.Point(0, 9);
            lbText.Name = "lbText";
            lbText.Size = new System.Drawing.Size(139, 30);
            lbText.TabIndex = 1;
            lbText.Text = "지뢰찾기게임";
            // 
            // F_Map
            // 
            F_Map.BackColor = System.Drawing.Color.White;
            F_Map.Location = new System.Drawing.Point(12, 58);
            F_Map.Name = "F_Map";
            F_Map.Size = new System.Drawing.Size(403, 691);
            F_Map.TabIndex = 2;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // MineSweeper
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(422, 761);
            Controls.Add(F_Map);
            Controls.Add(panel1);
            Name = "MineSweeper";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Form2";
            FormClosed += MineSweeper_FormClosed;
            Load += Form2_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel F_Map;
        private System.Windows.Forms.Label lbText;
        private System.Windows.Forms.Label lbScore;
        private System.Windows.Forms.Timer timer1;
    }
}