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
    public class CommentPresenter : ICommentPresenter
    {

        private ImgurContext _context;
        private ICommentView _commentView;
        public BasicDataModel data { get; set; } = new BasicDataModel();
        

        public CommentPresenter(ICommentView view, GalleryModel.Datum data)
        {
            this._context = new ImgurContext();
            this._commentView = view;
            this.data.id = data.id;
        }


        public async Task CreateCommentAsync(CommentModel model)
        {
            model.ImageId = this.data.id;
            var response = await _context.Comment.Create(model);
            model.CommentId = response.data.id.ToString();
            model.Author = "art787472";
            model.Ups = 1;
            model.Vote = "up";
            _commentView.CreateCommentFinish(model);
        }

        public async Task LoadCommentAsync(string commentSort, string galleryHash)
        {
            var data = await _context.Gallery.Comment(commentSort, galleryHash);
            _commentView.LoadCommentFinish(data);
        }
    }
}
