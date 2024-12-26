using Imgur.Models;
using imgurAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imgur.Contract
{
    public interface ICommentView
    {
        void LoadCommentFinish(GalleryCommentResponseModel.Datum[] data);
        void CreateCommentFinish(CommentModel model);
    }

    public interface ICommentPresenter
    {
        BasicDataModel data { get; set; }
        Task LoadCommentAsync(string commentSort, string galleryHash);
        Task CreateCommentAsync(CommentModel model);
    }
}
