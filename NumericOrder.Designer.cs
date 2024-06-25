namespace MiniGameParty
{
    partial class NumericOrder
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
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            lbTime = new System.Windows.Forms.Label();
            timer1 = new System.Windows.Forms.Timer(components);
            label1 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new System.Drawing.Point(0, 61);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(743, 744);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // lbTime
            // 
            lbTime.AutoSize = true;
            lbTime.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lbTime.Location = new System.Drawing.Point(536, 21);
            lbTime.Name = "lbTime";
            lbTime.Size = new System.Drawing.Size(196, 30);
            lbTime.TabIndex = 2;
            lbTime.Text = "경과 시간 : 0분 0초";
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("맑은 고딕", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.ForeColor = System.Drawing.Color.Blue;
            label1.Location = new System.Drawing.Point(234, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(287, 45);
            label1.TabIndex = 3;
            label1.Text = "순발력 테스트게임";
            // 
            // NumericOrder
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(744, 807);
            Controls.Add(label1);
            Controls.Add(lbTime);
            Controls.Add(flowLayoutPanel1);
            Name = "NumericOrder";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Form1";
            FormClosed += NumericOrder_FormClosed;
            Load += Main_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
    }
}
