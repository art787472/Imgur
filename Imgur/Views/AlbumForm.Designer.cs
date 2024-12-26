namespace Imgur.Views
{
    partial class AlbumForm
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.paginationBox = new System.Windows.Forms.FlowLayoutPanel();
            this.albumComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(26, 41);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(745, 362);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // paginationBox
            // 
            this.paginationBox.Location = new System.Drawing.Point(3, 409);
            this.paginationBox.Name = "paginationBox";
            this.paginationBox.Size = new System.Drawing.Size(785, 45);
            this.paginationBox.TabIndex = 2;
            // 
            // albumComboBox
            // 
            this.albumComboBox.FormattingEnabled = true;
            this.albumComboBox.Location = new System.Drawing.Point(59, 15);
            this.albumComboBox.Name = "albumComboBox";
            this.albumComboBox.Size = new System.Drawing.Size(126, 20);
            this.albumComboBox.TabIndex = 3;
            this.albumComboBox.SelectedIndexChanged += new System.EventHandler(this.albumComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "相簿：";
            // 
            // AlbumForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 466);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.albumComboBox);
            this.Controls.Add(this.paginationBox);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "AlbumForm";
            this.Text = "AlbumForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel paginationBox;
        private System.Windows.Forms.ComboBox albumComboBox;
        private System.Windows.Forms.Label label1;
    }
}