using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicTalk.Models.ModelResponses
{
    public class MoviesModelResponse
    {
        public int ID { get; set; }
        public string Logo { get; set; }
        public string Name { get; set; }
        public System.DateTime Release { get; set; }
        public List<Reaction> Reactions { get; set; }
    }
    public class Reaction
    {
        public string Tag { get; set; }
        public string Image { get; set; }
        public int UID { get; set; }
        public int MovieID { get; set; }

    }
}
