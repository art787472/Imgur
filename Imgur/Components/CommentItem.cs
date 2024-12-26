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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static imgurAPI.Models.GalleryCommentResponseModel;
using Label = System.Windows.Forms.Label;

namespace Imgur.Components
{
    public partial class CommentItem : UserControl, IVoteView, ICommentView
    {
        private bool isCollapsed = false;
        private CommentModel data;
        private GalleryCommentResponseModel.Child childData;

        public event EventHandler<string> ClickEvent;
        public string Id { get; set; }
        public string ImageId { get; set; }

        private IVotePresenter presenter;
        private ICommentPresenter replyPresenter;
        

        public CommentItem(CommentModel data)
        {
            InitializeComponent();
            this.data = data;
            this.Id = data.CommentId;
            this.ImageId = data.ImageId;
            UsernameLabel.Text = data.Author;
            

            var commentStr = SplitComment(data.Comment);
            GenerateCommentUI(commentPanel, commentStr);

            //CommentLabel.Text = data.comment;
            Id = data.CommentId;
            ImageId = data.ImageId;

            presenter = new CommentVotePresenter(this, Id);
            replyPresenter = new ReplyPresenter(this);

            VoteClick(VotePresenter.VoteString(data.Vote), data.Ups);
            this.Height = 90;
            if (data.Children.Count > 0)
            {
                repliesLabel.Text = $"+{data.Children.Count}replies";
            }
            else
            {
                repliesLabel.Text = string.Empty;
                repliesPanel.Visible = false;

            }

            UpLabel.Click += Label_Click;
            DownLabel.Click += Label_Click;

            UsernameLabel.Click += UsernameLabel_Click;

        }

        private void UsernameLabel_Click(object sender, EventArgs e)
        {
            ClickEvent?.Invoke(this, Id);
        }

        private void repliesLabel_Click(object sender, EventArgs e)
        {
            if (!isCollapsed)
            {
                

                int height =  this.data.Children.Count * 90;
                
                this.Height = height + 110 ;
                repliesLabel.Text = "-" + repliesLabel.Text.TrimStart('+');

                this.repliesPanel.Controls.Clear();
                this.repliesPanel.Height = height + 10;
                this.repliesPanel.Width = 400;
                
                foreach(var commentData in data.Children)
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
                    var item = new CommentItem(model);
                    item.ClickEvent += Item_ClickEvent;
                    item.ClickEvent += this.ClickEvent;
                    this.repliesPanel.Controls.Add(item);

                }
                isCollapsed = !isCollapsed;
                return;
            }

            this.Height = 90;
            repliesLabel.Text = "+" + repliesLabel.Text.TrimStart('-');
            isCollapsed = !isCollapsed;
        }

        private void Item_ClickEvent(object sender, string e)
        {
            ClickEvent?.Invoke(this, Id);
        }

        private List<string> SplitComment(string comment)
        {
            Regex regex = new Regex("(https?://(?:[\\w-]+\\.)+[\\w-]+(?:/[\\w-./?%&=]*)?)");

            return regex.Split(comment).ToList();
        }

        private void GenerateCommentUI(FlowLayoutPanel commentPanel, List<string> strings)
        {
            Regex regexImg = new Regex("https?://[^\\s<>\"]+?\\.(?:jpg|jpeg|gif|png|bmp|webp)");
            Regex regexLink = new Regex("https?://(?:[\\w-]+\\.)+[\\w-]+(?:/[\\w-./?%&=]*)?");
            

            foreach (string str in strings)
            {
                if(regexImg.IsMatch(str))
                {
                    Console.WriteLine(str);
                    var picBox = new PictureBox();
                    picBox.Width = 50;
                    picBox.Height = 50;
                    picBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    picBox.LoadAsync(str);
                    commentPanel.Controls.Add(picBox);
                    continue;
                }

                if(regexLink.IsMatch(str))
                {
                    Console.WriteLine(str);
                    var linkLabel = new LinkLabel();
                    linkLabel.Text = str;
                    commentPanel.Controls.Add(linkLabel);
                    continue;
                }
                Console.WriteLine(str);
                var label = new Label();
                label.AutoSize = false;
                label.Width = 400;
                
                label.Text = str;
                commentPanel.Controls.Add(label);
            }

        }

        private void CommentItem_SizeChanged(object sender, EventArgs e)
        {
            
            var item = (CommentItem)sender;
            if(this.Parent?.Parent is Form)
            {
                return;
            }


            if(this.Parent?.Parent != null)
            {
                if(!item.isCollapsed)
                {
                    //this.Parent.Parent.Height = this.Parent.Parent.Height - item.Height;
                    //this.Parent.Height = this.Parent.Height - item.Height;
                    //return;
                }

                
                this.Parent.Parent.Height = this.Parent.Parent.Height + item.Height;
                this.Parent.Height = this.Parent.Height + item.Height;

            }
        }

        public void SizeChange(int commentCount)
        {
            this.Height = commentCount * 100;
            this.repliesLabel.Height = commentCount * 100;

        }

        private void CommentItem_Click(object sender, EventArgs e)
        {

        }

        private async void Label_Click(object sender, EventArgs e)
        {
            var label = (Label)sender;
            switch (label.Text)
            {
                case "⬆":
                    await presenter.Vote(VoteType.Up);
                    break;
                case "⬇":
                    await presenter.Vote(VoteType.Down);
                    break;
            }


        }

        public void VoteClick(VoteType type, int Count)
        {
            VoteLabel.Text = Count.ToString();


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

        public void LoadCommentFinish(GalleryCommentResponseModel.Datum[] data)
        {
            throw new NotImplementedException();
        }

        public void CreateCommentFinish(CommentModel model)
        {
            repliesPanel.Visible = true;
            this.repliesPanel.Controls.Add(new CommentItem(model));
            this.isCollapsed = true;
            repliesLabel.Text = $"-1replies";
            this.Height = this.Height + 110;
            this.repliesPanel.Height = 90;
            this.repliesPanel.Width = 400;

            this.data.Children.Add(
                new Datum { id = Convert.ToInt64(model.CommentId),
                            image_id = model.ImageId,
                            comment = model.Comment,
                            author = model.Author,
                            ups = 1,
                            vote = "up",
                            children = new Datum[0]});

            

        }

        public async Task CreateReply(CommentModel model)
        {
            
            model.ImageId = this.ImageId;
            await replyPresenter.CreateCommentAsync(model);
        }
    }
}
