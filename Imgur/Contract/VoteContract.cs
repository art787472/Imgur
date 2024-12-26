using Imgur.Models;
using imgurAPI.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Imgur.Contract
{
    public interface IVoteView
    {
        void VoteClick(VoteType type,int Count);
    }

    public interface IVotePresenter
    {
        BasicDataModel data { get; set; }
        Task Vote(VoteType type);
        
    }
}
