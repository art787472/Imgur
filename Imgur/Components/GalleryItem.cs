using Imgur.Contract;
using Imgur.Models;
using Imgur.Presenter;
using Imgur.Views;
using imgurAPI;
using imgurAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;

namespace Imgur.Components
{
    public partial class GalleryItem : UserControl, IVoteView, IAlbumView
    {
        
        private IVotePresenter presenter;
        private IAlbumPresenter albumPresenter;
        private GalleryContentForm contentForm;
        private Task<Action> contentTask;
        // Task<AlbumData> task
        public GalleryItem(GalleryModel.Datum data)
        {
            InitializeComponent();
            this.presenter = new VotePresenter(this, data);
            this.albumPresenter = new AlbumPresenter(this);
            //task = albumPresenter.GetAlbumDetail(data.id);
            titleLabel.Text = data.title;
            UpLabel.Text = data.ups.ToString();
            commentLabel.Text = data.comment_count.ToString();
            viewLabel.Text = data.views.ToString();

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            if (data.images != null && data.images[0].link.Length > 0)
            {
                if (data.images[0].link.EndsWith("mp4"))
                {
                    pictureBox1.LoadAsync($"https://imgur.com/{data.cover}.jpg");
                }
                else
                {
                    pictureBox1.LoadAsync(data.images[0].link);
                }
            }

            if(data.images == null)
            {
                pictureBox1.LoadAsync($"https://imgur.com/{data.cover}.jpg");
            }
            label1.Cursor = Cursors.Hand;
            label2.Cursor = Cursors.Hand;
            label1.Click += Label_Click;
            label2.Click += Label_Click;

            var voteType = VoteString((string)data.vote);
            this.VoteClick(voteType, data.ups);

            contentTask = albumPresenter.GetAlbum(data.id);

        }

        

        public void Dispose()
        {

            pictureBox1.Dispose();
           
            

        }
        private async void Label_Click(object sender, EventArgs e)
        {
            var label = (Label)sender;
            switch(label.Text)
            {
                case "⬆":
                    await presenter.Vote(VoteType.Up);
                    break;
                case "⬇":
                    await presenter.Vote(VoteType.Down);
                    break;
            }
            

        }


        public void VoteClick(VoteType type, int count)
        {
            UpLabel.Text = count.ToString();
            

            switch(type)
            {
                case VoteType.Unvote:
                    label1.ForeColor = Color.Black;
                    label2.ForeColor = Color.Black;
                    break;
                case VoteType.Up:
                    label1.ForeColor = Color.Green;
                    label2.ForeColor = Color.Black;
                    break;

                case VoteType.Down:
                    label1.ForeColor = Color.Black;
                    label2.ForeColor = Color.Red;
                    break;
            }
        }

        private VoteType VoteString(string voteType)
        {
            if(voteType == null)
                return VoteType.Unvote;
            switch (voteType)
            {

                case "up":
                    return VoteType.Up;
                case "down":
                    return VoteType.Down;
                case "veto":
                    return VoteType.Unvote;
            }
            return VoteType.Up;
        }
        // private void AlbumRespnseCallback(AlbumData contentData) {
            // contentForm = new GalleryContentForm(contentData);
            //contentForm.Show();
        // }

        public void GetAlbumFinish(GalleryModel.Datum data)
        {
            contentForm = new GalleryContentForm(data);
            contentForm.Show();
        }

        private async void GalleryItem_DoubleClick(object sender, EventArgs e)
        {

            // atait task;

            (await contentTask).Invoke();
           
        }

        public void GetAlblumsFinish(List<KeyValuePair<string, string>> titles)
        {
            throw new NotImplementedException();
        }
    }
}
