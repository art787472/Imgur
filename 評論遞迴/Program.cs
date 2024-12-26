using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static 評論遞迴.Comments;

namespace 評論遞迴
{
    internal class Program
    {
        static void Main(string[] args)
        {
           string jsonString = @"{
    ""data"": [
        {
            ""id"": 2431140619,
            ""image_id"": ""f8W48gB"",
            ""comment"": ""love it, cornelius and i have the same energy atm"",
            ""author"": ""TheChunguskaEvent"",
            ""author_id"": 1407959,
            ""on_album"": true,
            ""album_cover"": ""SbNEtkU"",
            ""ups"": 2,
            ""downs"": 0,
            ""points"": 2,
            ""datetime"": 1733198414,
            ""parent_id"": 0,
            ""deleted"": false,
            ""vote"": null,
            ""platform"": ""api"",
            ""has_admin_badge"": false,
            ""children"": [
                {
                    ""id"": 2431140791,
                    ""image_id"": ""f8W48gB"",
                    ""comment"": ""I have the same energy, just wish he’d do it NOT in the cat tent but ce est la vie I suppose"",
                    ""author"": ""HRpurrfrock728"",
                    ""author_id"": 166995497,
                    ""on_album"": true,
                    ""album_cover"": ""SbNEtkU"",
                    ""ups"": 1,
                    ""downs"": 0,
                    ""points"": 1,
                    ""datetime"": 1733198541,
                    ""parent_id"": 2431140619,
                    ""deleted"": false,
                    ""vote"": null,
                    ""platform"": ""iphone"",
                    ""has_admin_badge"": false,
                    ""children"": []
                }
            ]
        },
        {
            ""id"": 2431140475,
            ""image_id"": ""f8W48gB"",
            ""comment"": ""Cornelius DGAF https://i.imgur.com/7KNNikX.png"",
            ""author"": ""TerribleAwful"",
            ""author_id"": 19917417,
            ""on_album"": true,
            ""album_cover"": ""SbNEtkU"",
            ""ups"": 2,
            ""downs"": 0,
            ""points"": 2,
            ""datetime"": 1733198323,
            ""parent_id"": 0,
            ""deleted"": false,
            ""vote"": null,
            ""platform"": ""desktop"",
            ""has_admin_badge"": false,
            ""children"": [
                {
                    ""id"": 2431140887,
                    ""image_id"": ""f8W48gB"",
                    ""comment"": ""Tbh he’s a teeny bit high on cbd but you are right he does not give a fuck"",
                    ""author"": ""HRpurrfrock728"",
                    ""author_id"": 166995497,
                    ""on_album"": true,
                    ""album_cover"": ""SbNEtkU"",
                    ""ups"": 1,
                    ""downs"": 0,
                    ""points"": 1,
                    ""datetime"": 1733198603,
                    ""parent_id"": 2431140475,
                    ""deleted"": false,
                    ""vote"": null,
                    ""platform"": ""iphone"",
                    ""has_admin_badge"": false,
                    ""children"": []
                }
            ]
        }
    ],
    ""success"": true,
    ""status"": 200
}";

           Comments data =  JsonConvert.DeserializeObject<Comments>(jsonString);
           Datum[] comments =  data.data;
           PrintComment(comments);
        }

        static void PrintComment(Comments.Datum[] commentData)
        {
            
            foreach(var data in commentData)
            {
                Console.WriteLine(data.comment);
                if(data.children.Length == 0)
                {
                    break;
                }

                Console.Write("\t");
                PrintComment(data.children);
            }
        }
    }
}
