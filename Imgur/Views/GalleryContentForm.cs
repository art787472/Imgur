using Imgur.Components;
using Imgur.Contract;
using Imgur.Models;
using Imgur.Presenter;
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

namespace Imgur.Views
{
    public partial class GalleryContentForm : Form, IVoteView, ICommentView, IFavoriteView
    {
        private IVotePresenter _votePresenter;
        private ICommentPresenter _commentPresenter;
        private IFavoritePresenter _favouritePresenter;
        public GalleryContentForm(GalleryModel.Datum data)
        {
            InitializeComponent();
            _votePresenter = new VotePresenter(this, data);
            _commentPresenter = new CommentPresenter(this, data);
            _favouritePresenter = new FavoritetPresenter(this, data);
            

            VoteLabel.Text = _votePresenter.data.ups.ToString();
            TitleLabel.Text = _votePresenter.data.title;

            foreach(var imageData in _votePresenter.data.images)
            {
                string url = imageData.link;
                PictureBox pictureBox = new PictureBox();
                pictureBox.Width = 300;
                pictureBox.Height = 400;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.LoadAsync(url);
                flowLayoutPanel1.Controls.Add(pictureBox);
            }

            LoadComment(data.id);

            UpLabel.Cursor = Cursors.Hand;
            DownLabel.Cursor = Cursors.Hand;
            UpLabel.Click += Label_Click;
            DownLabel.Click += Label_Click;

            ItemIdLab.Text = data.id;

            if(data.favorite)
            {
                HeartLabel.ForeColor = Color.Red;
            }

        }

        private async void LoadComment(string gallerHash)
        {
            await _commentPresenter.LoadCommentAsync("best", gallerHash);
        }

        private async void Label_Click(object sender, EventArgs e)
        {
            var label = (Label)sender;
            switch (label.Text)
            {
                case "⬆":
                    await _votePresenter.Vote(VoteType.Up);
                    break;
                case "⬇":
                    await _votePresenter.Vote(VoteType.Down);
                    break;
            }


        }

        public void VoteClick(VoteType type, int count)
        {
            VoteLabel.Text = count.ToString();


            switch (type)
            {
                case VoteType.Unvote:
                    UpLabel.ForeColor = Color.Black;
                    DownLabel.ForeColor = Color.Black;
                    break;
                case VoteType.Up:
                    UpLabel.ForeColor = Color.Green;
                    DownLabel.ForeColor = Color.Black;
                    break;

                case VoteType.Down:
                    UpLabel.ForeColor = Color.Black;
                    DownLabel.ForeColor = Color.Red;
                    break;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public void LoadCommentFinish(GalleryCommentResponseModel.Datum[] data)
        {
            foreach(var commentData in data)
            {
                var model = new CommentModel
                {
                    ImageId = commentData.image_id,
                    Author = commentData.author,
                    CommentId = commentData.id.ToString(),
                    Comment = commentData.comment,
                    Children = commentData.children.ToList(),
                    Ups = commentData.ups
                };
                CommentItem commentItem = new CommentItem(model);
                commentItem.Click += CommentItem_Click;
                commentItem.ClickEvent += CommentItem_ClickEvent;
                commentPanel.Controls.Add(commentItem);
            }
        }

        private void CommentItem_ClickEvent(object sender, string e)
        {
            var item = (CommentItem)sender;
            commentItem = item;
            ItemIdLab.Text = e;
        }

        private CommentItem commentItem;
        private void CommentItem_Click(object sender, EventArgs e)
        {
            var item = (CommentItem)sender;
            commentItem = item;
            ItemIdLab.Text = item.Id;
        }

        public void CreateCommentFinish(CommentModel model)
        {
            var newCommentItem = new CommentItem(model);
            newCommentItem.Click += CommentItem_Click;
            commentPanel.Controls.Add(newCommentItem);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var commentModel = new CommentModel();
            commentModel.Comment = textBox1.Text;

            // 回覆留言
            if(commentItem != null)
            {
                commentModel.CommentId = commentItem.Id;
                
                await commentItem.CreateReply(commentModel);
                return;
            }
            
            
            commentModel.ImageId = _commentPresenter.data.id;
            await this._commentPresenter.CreateCommentAsync(commentModel);


            
            
                
        }

        private async void HeartLabel_Click(object sender, EventArgs e)
        {
            await _favouritePresenter.AddFavoriteAsync();
        }

        public void AddFavoriteFinish(bool isFavorite)
        {
            if(isFavorite)
            {
                HeartLabel.ForeColor = Color.Red;
                
                return;
            }
            HeartLabel.ForeColor = Color.Black;
        }

        public void GetFavoriteFinish(GalleryModel.Datum[] data)
        {
            throw new NotImplementedException();
        }
    }
}
