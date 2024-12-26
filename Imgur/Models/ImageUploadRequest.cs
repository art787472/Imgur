using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imgur.Models
{
    public class ImageUploadRequest
    {
        public Stream Image { get; set; }

        

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public bool IsPublic { get; set; }

        public string AlbumId { get; set; }
    }
}
