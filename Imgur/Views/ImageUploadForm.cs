using Imgur.Contract;
using Imgur.Models;
using Imgur.Presenter;
using imgurAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Imgur.Views
{
    public partial class ImageUploadForm : Form, IUploadView
    {
        IUploadPresenter _uploadPresenter;
        private string filePath = string.Empty;
        
        public ImageUploadForm()
        {
            InitializeComponent();
            
            albumComboBox.Enabled = false;

            _uploadPresenter = new UploadPresenter(this);


            pictureBox1.Click += PictureUpload;
            _uploadPresenter.GetAlbums("art787472");
        }

        public void GetAlblumsFinish(List<KeyValuePair<string, string>> titles)
        {
            albumComboBox.DataSource = titles;
            albumComboBox.DisplayMember = "Value";
            
        }

        public void UploadFinish(bool isSuccess)
        {
            
            button1.Enabled = true;
            if(isSuccess)
            {
                
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;

                return;

            }
            

        }

        private void PictureUpload(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Images(全部的圖檔)|*.png;*.jpg;*.gif;*.jpeg;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox.Load(openFileDialog.FileName);
                filePath = openFileDialog.FileName;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            var model = new ImageUploadRequest();
            model.Title = textBox1.Text;
            model.Description = textBox2.Text;
            
            model.ImagePath = filePath;

            if(checkBox1.Checked)
            {
                if(albumComboBox.SelectedValue is KeyValuePair<string, string> pair)
                {
                    model.AlbumId = pair.Key;
                }

            }
            model.IsPublic = checkBox2.Checked;

            byte[] imageBytes = File.ReadAllBytes(filePath);
            MemoryStream ms = new MemoryStream(imageBytes);
            
                // 現在圖片在記憶體中，可以使用 ms 來處理圖片
            model.Image = ms;

            Task<bool> isSuccess = _uploadPresenter.Upload(model);

            MessageForm messageForm = new MessageForm(isSuccess);


            messageForm.ShowDialog();

            

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            
            albumComboBox.Enabled = checkBox.Checked;
            
        }
    }
}
