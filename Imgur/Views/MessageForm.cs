using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Imgur.Views
{
    public partial class MessageForm : Form
    {
        Task<bool> callback;
        public MessageForm(Task<bool> callback)
        {
            InitializeComponent();
            button1.Visible = false;
            this.callback = callback;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private async void MessageForm_Load(object sender, EventArgs e)
        {
            
            label1.Text = "上傳中...";
            button1.Visible = false;
            bool isSuccess = await callback;
            
            if (isSuccess)
            {
                label1.Text = "上傳成功";
                button1.Visible = true;
                return;
            }
            label1.Text = "上傳失敗";
            button1.Visible = true;

        }
    }
}
