using imgurAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imgur.Models
{
    public class BasicDataModel
    {
        public string id { get; set; }
        public int ups { get; set; }

        public string title { get; set; }
        public GalleryModel.Image[] images { get; set; }

        
    }
}
