using Imgur.Models;
using imgurAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imgur.Contract
{
    public interface GallerySearchView
    {
        void SearchFinished(GalleryModel.Datum[] data);
        void PageChangeFinish(GalleryModel.Datum[] data);
    }

    public interface GallerySearchPresenter
    {
        GalleryModel.Datum[] data { get; set; }
        void Search(ContentFormType type, string q);
        void SelectPage(int page);
    }
}
