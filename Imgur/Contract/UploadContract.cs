using Imgur.Models;
using imgurAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imgur.Contract
{
    public interface IUploadPresenter
    {
        Task<bool> Upload(ImageUploadRequest model);
        void GetAlbums(string username);
    }

    public interface IUploadView
    {
        void UploadFinish(bool isSuccess);
        
        void GetAlblumsFinish(List<KeyValuePair<string, string>> titles);
    }
}
