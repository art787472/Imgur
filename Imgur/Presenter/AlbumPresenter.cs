using Imgur.Contract;
using imgurAPI;
using imgurAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imgur.Presenter
{
    public class AlbumPresenter : IAlbumPresenter
    {
        private ImgurContext _context;
        private IAlbumView _view;
        private GalleryModel.Datum album = null;
        public AlbumPresenter(IAlbumView view)
        {
            _context = new ImgurContext();
            _view = view;
        }
        public async Task<Action>  GetAlbum(string id)
        {
            album = await _context.Album.Get(id);
            return NotifyView;
        }

        public async Task GetAlbums(string username)
        {
            var model = new AccountAlbumModel() { UserName = username };
            var response = await _context.Account.GetAlbums(model);
            var titles = response.data.Select(x => new KeyValuePair<string, string>(x.id, x.title == null ? "untitle" : x.title)).ToList();
            _view.GetAlblumsFinish(titles);
        }

        private void NotifyView()
        {
            _view.GetAlbumFinish(album);
        }
    }
}
