using Imgur.Contract;
using Imgur.Models;
using imgurAPI;
using imgurAPI.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Imgur.Presenter
{
    internal class VotePresenter : IVotePresenter
    {
        IVoteView galleryItem;
        
        public BasicDataModel data { get; set; } = new BasicDataModel();

        private VoteType voteState;
        private ImgurContext context;
        public VotePresenter(IVoteView galleryItem, GalleryModel.Datum data)
        {
            this.galleryItem = galleryItem;
            this.data.id = data.id;
            this.data.images = data.images;
            this.data.title = data.title;
            this.context = new ImgurContext();

            voteState = VoteString((string)data.vote);
        }

        public async Task Vote(VoteType type)
        {
                        
            switch (type)
            {
                case VoteType.Up:
                    VoteUp();
                    break;
                case VoteType.Down:
                    VoteDown();
                    break;
            }
            await VoteApiAsync(voteState, data.id);
            var (ups, downs) = await context.Gallery.Votes(data.id);
            
            galleryItem.VoteClick(this.voteState, ups);
        }

        private int VoteUp()
        {
            int count = 0;
            
            switch (voteState)
            {
                case VoteType.Unvote:
                    
                    
                    voteState = VoteType.Up;
                    break;
                case VoteType.Up:
                    

                    
                    voteState = VoteType.Unvote;
                    break;
                case VoteType.Down:
                    
                    
                    voteState = VoteType.Up;
                    break;
            }

            

            return count;
        }

        private  int VoteDown()
        {
            int count = 0;
            
            switch (voteState)
            {
                case VoteType.Unvote:
                    
                    
                    voteState = VoteType.Down;
                    break;
                case VoteType.Up:
                    
                    
                    voteState = VoteType.Down;

                    break;
                case VoteType.Down:
                   

                    
                    voteState = VoteType.Unvote;
                    break;
            }

             

            return count;
        }

        private async Task VoteApiAsync(VoteType voteType, string imageId)
        {
            CommentModel model = new CommentModel()
            {
                ImageId = imageId,
                Vote = VoteString(voteType)
            };
            var reponse = await context.Gallery.Voting(model);
            
        }

        private string VoteString(VoteType voteType)
        {
            switch (voteType)
            {
                
                case VoteType.Up:
                    return "up";
                case VoteType.Down:
                    return "down";
                case VoteType.Veto:
                    return "veto";
                case VoteType.Unvote:
                    return "veto";
            }
            return "up";
        }

        public static VoteType VoteString(string voteType)
        {
            if (voteType == null)
                return VoteType.Unvote;
            switch (voteType)
            {

                case "up":
                    return VoteType.Up;
                case "down":
                    return VoteType.Down;
                case "veto":
                    return VoteType.Unvote;
            }
            return VoteType.Up;
        }
    }
}
