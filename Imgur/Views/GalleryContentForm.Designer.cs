namespace Imgur.Views
{
    partial class GalleryContentForm
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
            this.UpLabel = new System.Windows.Forms.Label();
            this.DownLabel = new System.Windows.Forms.Label();
            this.VoteLabel = new System.Windows.Forms.Label();
            this.HeartLabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.commentPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ItemIdLab = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UpLabel
            // 
            this.UpLabel.AutoSize = true;
            this.UpLabel.Font = new System.Drawing.Font("新細明體", 24F);
            this.UpLabel.Location = new System.Drawing.Point(46, 116);
            this.UpLabel.Name = "UpLabel";
            this.UpLabel.Size = new System.Drawing.Size(27, 32);
            this.UpLabel.TabIndex = 0;
            this.UpLabel.Text = "⬆";
            // 
            // DownLabel
            // 
            this.DownLabel.AutoSize = true;
            this.DownLabel.Font = new System.Drawing.Font("新細明體", 24F);
            this.DownLabel.Location = new System.Drawing.Point(46, 260);
            this.DownLabel.Name = "DownLabel";
            this.DownLabel.Size = new System.Drawing.Size(27, 32);
            this.DownLabel.TabIndex = 1;
            this.DownLabel.Text = "⬇";
            this.DownLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // VoteLabel
            // 
            this.VoteLabel.AutoSize = true;
            this.VoteLabel.Font = new System.Drawing.Font("新細明體", 24F);
            this.VoteLabel.Location = new System.Drawing.Point(44, 160);
            this.VoteLabel.Name = "VoteLabel";
            this.VoteLabel.Size = new System.Drawing.Size(29, 32);
            this.VoteLabel.TabIndex = 2;
            this.VoteLabel.Text = "0";
            this.VoteLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HeartLabel
            // 
            this.HeartLabel.AutoSize = true;
            this.HeartLabel.Font = new System.Drawing.Font("新細明體", 24F);
            this.HeartLabel.Location = new System.Drawing.Point(36, 212);
            this.HeartLabel.Name = "HeartLabel";
            this.HeartLabel.Size = new System.Drawing.Size(47, 32);
            this.HeartLabel.TabIndex = 3;
            this.HeartLabel.Text = "❤";
            this.HeartLabel.Click += new System.EventHandler(this.HeartLabel_Click);
            // 
            // TitleLabel
            // 
            this.TitleLabel.Font = new System.Drawing.Font("新細明體", 24F);
            this.TitleLabel.Location = new System.Drawing.Point(93, 9);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(402, 70);
            this.TitleLabel.TabIndex = 4;
            this.TitleLabel.Text = "標題";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(529, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(372, 55);
            this.textBox1.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(934, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 28);
            this.button1.TabIndex = 6;
            this.button1.Text = "送出";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(99, 97);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(396, 518);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // commentPanel
            // 
            this.commentPanel.AutoScroll = true;
            this.commentPanel.Location = new System.Drawing.Point(529, 97);
            this.commentPanel.Name = "commentPanel";
            this.commentPanel.Size = new System.Drawing.Size(488, 518);
            this.commentPanel.TabIndex = 8;
            // 
            // ItemIdLab
            // 
            this.ItemIdLab.AutoSize = true;
            this.ItemIdLab.Location = new System.Drawing.Point(529, 79);
            this.ItemIdLab.Name = "ItemIdLab";
            this.ItemIdLab.Size = new System.Drawing.Size(0, 12);
            this.ItemIdLab.TabIndex = 9;
            // 
            // GalleryContentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 637);
            this.Controls.Add(this.ItemIdLab);
            this.Controls.Add(this.commentPanel);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.HeartLabel);
            this.Controls.Add(this.VoteLabel);
            this.Controls.Add(this.DownLabel);
            this.Controls.Add(this.UpLabel);
            this.Name = "GalleryContentForm";
            this.Text = "GalleryContentForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UpLabel;
        private System.Windows.Forms.Label DownLabel;
        private System.Windows.Forms.Label VoteLabel;
        private System.Windows.Forms.Label HeartLabel;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel commentPanel;
        private System.Windows.Forms.Label ItemIdLab;
    }
}