using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 評論遞迴
{
    internal class Comments
    {
        public Datum[] data { get; set; }
        public bool success { get; set; }
        public int status { get; set; }

        public class Datum
        {
            public long id { get; set; }
            public string image_id { get; set; }
            public string comment { get; set; }
            public string author { get; set; }
            public int author_id { get; set; }
            public bool on_album { get; set; }
            public string album_cover { get; set; }
            public int ups { get; set; }
            public int downs { get; set; }
            public int points { get; set; }
            public int datetime { get; set; }
            public long parent_id { get; set; }
            public bool deleted { get; set; }
            public object vote { get; set; }
            public string platform { get; set; }
            public bool has_admin_badge { get; set; }
            public Datum[] children { get; set; }
        }
    }
}
