using imgurAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imgur.Contract
{
    
        public interface IFavoritePresenter
        {
            Task AddFavoriteAsync();
            void GetFavorite(string username);
            
        }

        public interface IFavoriteView
        {
            void AddFavoriteFinish(bool isFavorite);
            void GetFavoriteFinish(GalleryModel.Datum[] data);
        
        }
    
}
