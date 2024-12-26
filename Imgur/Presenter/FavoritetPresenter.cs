using imgurAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imgur.Contract;
using imgurAPI.Models;

namespace Imgur.Presenter
{
    public class FavoritetPresenter : IFavoritePresenter
    {
        private ImgurContext _context;
        private IFavoriteView _view;
        private string id;
        private bool isFavorite;

        public FavoritetPresenter(IFavoriteView view, GalleryModel.Datum data)
        {
            _context = new ImgurContext();
            _view = view;
            this.id = data?.images?[0].id;
            this.isFavorite = data != null ? data.favorite : true;
        }

        public async Task AddFavoriteAsync()
        {
            isFavorite = !isFavorite;
            await _context.Image.Favorete(id);
            _view.AddFavoriteFinish(isFavorite);
        }

        public async void GetFavorite(string username)
        {
            var data = await _context.Account.GetFavoriteImages(username);
            _view.GetFavoriteFinish(data);
        }
    }
}
