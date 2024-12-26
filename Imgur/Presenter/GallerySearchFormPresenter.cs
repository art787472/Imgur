using Imgur.Components;
using Imgur.Contract;
using Imgur.Models;
using Imgur.Views;
using imgurAPI;
using imgurAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Imgur.Presenter
{
    internal class GallerySearchFormPresenter : GallerySearchPresenter
    {
        private GallerySearchView form;
        private ImgurContext context = new ImgurContext();
        public GalleryModel.Datum[] data { get; set; }

        public GallerySearchFormPresenter(GallerySearchView form)
        {
            this.form = form;
        }

        public async void Search(ContentFormType type, string q)
        {
            if(type == ContentFormType.Search) 
            { 
                data = await context.Gallery.GallerySearch(q);
            
            }
            else if(type == ContentFormType.Favorite)
            {
                data = await context.Account.GetFavoriteImages(q);
            }
            
            
            form.SearchFinished(data);
        }

        public void SelectPage(int page)
        {
            form.PageChangeFinish(GetData(page));
        }

        private GalleryModel.Datum[] GetData(int page)
        {
            return data.Skip((page - 1) * 4).Take(4).ToArray();
        }

        public void SetData(GalleryModel.Datum[] data)
        {
            this.data = data;
        }
    }
}
