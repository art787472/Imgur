using Imgur.Contract;
using Imgur.Models;
using imgurAPI;
using imgurAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Imgur.Presenter
{
    public class UploadPresenter : IUploadPresenter
    {
        private ImgurContext _context;
        private IUploadView _uploadView;

        public UploadPresenter(IUploadView uploadView)
        {
            _context = new ImgurContext();
            _uploadView = uploadView;
        }

        public async void GetAlbums(string username)
        {
            var model = new AccountAlbumModel() { UserName  = username };
            var response = await _context.Account.GetAlbums(model);
            var titles =  response.data.Select(x =>new KeyValuePair<string, string>(x.id ,x.title==null ? "untitle" : x.title) ).ToList();
            _uploadView.GetAlblumsFinish(titles);
        }

        public async Task<bool> Upload(ImageUploadRequest model)
        {
            var uploadModel = new ImageUploadModel();
            uploadModel.Title = model.Title;
            uploadModel.Description = model.Description;
            uploadModel.Type = "file";
            uploadModel.ImagePath = model.ImagePath;
            uploadModel.Image = model.Image;
            var response = await _context.Image.Upload(uploadModel);

            var shareResponse = true;
            if (model.IsPublic)
            {
                var shareImgModel = new GalleryShareModel();
                shareImgModel.Title = model.Title;
                shareImgModel.imageHash = response.data.id;
                shareResponse = await _context.Gallery.ShareImg(shareImgModel);
            }
            
            _uploadView.UploadFinish(response.success && shareResponse);
            return response.success && shareResponse;
        }
    }
}
