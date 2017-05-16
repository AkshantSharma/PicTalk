using PicTalk.Droid.Models;
using System.Collections.Generic;

namespace PicTalk.Droid.Models
{
    public class MoviesModel
    {
            public int ID { get; set; }
            public string Logo { get; set; }
            public string Name { get; set; }
            public System.DateTime Release { get; set; }
            public List<Reaction> Reactions { get; set; }
     }
}