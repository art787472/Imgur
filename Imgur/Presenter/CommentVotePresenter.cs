using Imgur.Contract;
using Imgur.Models;
using imgurAPI;
using imgurAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imgur.Presenter
{
    public class CommentVotePresenter : IVotePresenter
    {
        IVoteView galleryItem;
        

        public BasicDataModel data { get; set; } = new BasicDataModel();

        private VoteType voteState;
        private ImgurContext context;
        public CommentVotePresenter(IVoteView galleryItem, GalleryCommentResponseModel.Datum data)
        {
            this.galleryItem = galleryItem;
            
            this.data.id = data.id.ToString();
            this.context = new ImgurContext();

            voteState = VoteString((string)data.vote);
        }
        public CommentVotePresenter(IVoteView galleryItem, string id)
        {
            this.galleryItem = galleryItem;

            this.data.id = id;
            this.context = new ImgurContext();

            voteState = VoteType.Up;
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
            var response = await context.Comment.Get(data.id);
            var ups = response.ups;

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

        private int VoteDown()
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
                
                CommentId = imageId,
                Vote = VoteString(voteType)
            };
            var reponse = await context.Comment.Vote(model);

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

        private VoteType VoteString(string voteType)
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
