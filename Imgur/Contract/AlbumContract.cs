using imgurAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imgur.Contract
{
    public interface IAlbumPresenter
    {
        Task<Action> GetAlbum(string id);
        Task GetAlbums(string username);
    }

    public interface IAlbumView
    {
       void GetAlbumFinish(GalleryModel.Datum data);
        void GetAlblumsFinish(List<KeyValuePair<string, string>> titles);
    }
}
