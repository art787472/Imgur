namespace Imgur.Components
{
    partial class CommentItem
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.VoteLabel = new System.Windows.Forms.Label();
            this.UpLabel = new System.Windows.Forms.Label();
            this.DownLabel = new System.Windows.Forms.Label();
            this.repliesPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.repliesLabel = new System.Windows.Forms.Label();
            this.commentPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Font = new System.Drawing.Font("新細明體", 14F);
            this.UsernameLabel.Location = new System.Drawing.Point(3, 0);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(78, 19);
            this.UsernameLabel.TabIndex = 1;
            this.UsernameLabel.Text = "username";
            // 
            // VoteLabel
            // 
            this.VoteLabel.AutoSize = true;
            this.VoteLabel.Font = new System.Drawing.Font("新細明體", 14F);
            this.VoteLabel.Location = new System.Drawing.Point(23, 69);
            this.VoteLabel.Name = "VoteLabel";
            this.VoteLabel.Size = new System.Drawing.Size(18, 19);
            this.VoteLabel.TabIndex = 5;
            this.VoteLabel.Text = "0";
            this.VoteLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UpLabel
            // 
            this.UpLabel.AutoSize = true;
            this.UpLabel.Font = new System.Drawing.Font("新細明體", 18F);
            this.UpLabel.Location = new System.Drawing.Point(6, 65);
            this.UpLabel.Name = "UpLabel";
            this.UpLabel.Size = new System.Drawing.Size(20, 24);
            this.UpLabel.TabIndex = 3;
            this.UpLabel.Text = "⬆";
            // 
            // DownLabel
            // 
            this.DownLabel.AutoSize = true;
            this.DownLabel.Font = new System.Drawing.Font("新細明體", 18F);
            this.DownLabel.Location = new System.Drawing.Point(47, 65);
            this.DownLabel.Name = "DownLabel";
            this.DownLabel.Size = new System.Drawing.Size(20, 24);
            this.DownLabel.TabIndex = 6;
            this.DownLabel.Text = "⬇";
            // 
            // repliesPanel
            // 
            this.repliesPanel.AutoScroll = true;
            this.repliesPanel.Location = new System.Drawing.Point(10, 97);
            this.repliesPanel.Name = "repliesPanel";
            this.repliesPanel.Size = new System.Drawing.Size(419, 679);
            this.repliesPanel.TabIndex = 7;
            // 
            // repliesLabel
            // 
            this.repliesLabel.AutoSize = true;
            this.repliesLabel.Location = new System.Drawing.Point(73, 74);
            this.repliesLabel.Name = "repliesLabel";
            this.repliesLabel.Size = new System.Drawing.Size(50, 12);
            this.repliesLabel.TabIndex = 8;
            this.repliesLabel.Text = "+5 replies";
            this.repliesLabel.Click += new System.EventHandler(this.repliesLabel_Click);
            // 
            // commentPanel
            // 
            this.commentPanel.AutoScroll = true;
            this.commentPanel.Location = new System.Drawing.Point(6, 21);
            this.commentPanel.Name = "commentPanel";
            this.commentPanel.Size = new System.Drawing.Size(422, 44);
            this.commentPanel.TabIndex = 9;
            // 
            // CommentItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.commentPanel);
            this.Controls.Add(this.repliesLabel);
            this.Controls.Add(this.repliesPanel);
            this.Controls.Add(this.DownLabel);
            this.Controls.Add(this.VoteLabel);
            this.Controls.Add(this.UpLabel);
            this.Controls.Add(this.UsernameLabel);
            this.Name = "CommentItem";
            this.Size = new System.Drawing.Size(446, 792);
            this.SizeChanged += new System.EventHandler(this.CommentItem_SizeChanged);
            this.Click += new System.EventHandler(this.CommentItem_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Label VoteLabel;
        private System.Windows.Forms.Label UpLabel;
        private System.Windows.Forms.Label DownLabel;
        private System.Windows.Forms.FlowLayoutPanel repliesPanel;
        private System.Windows.Forms.Label repliesLabel;
        private System.Windows.Forms.FlowLayoutPanel commentPanel;
    }
}
