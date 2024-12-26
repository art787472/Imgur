using Imgur.Contract;
using Imgur.Models;
using imgurAPI;
using imgurAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imgur.Presenter
{
    public class ReplyPresenter : ICommentPresenter
    {
        public BasicDataModel data { get; set; }
        private ImgurContext _context;
        private ICommentView _commentView;
        public ReplyPresenter(ICommentView view)
        {
            _commentView = view;
            _context = new ImgurContext();
        }

        public async Task CreateCommentAsync(CommentModel model)
        {
            var response = await _context.Comment.CreateReply(model);
            model.CommentId = response.data.id.ToString();
            model.Author = "art787472";
            model.Ups = 1;
            model.Vote = "up";
            _commentView.CreateCommentFinish(model);
        }

        public async Task LoadCommentAsync(string commentSort, string galleryHash)
        {
            throw new NotImplementedException();
        }
    }
}
