using PicTalk.Models.ModelResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicTalk.Services
{
    public class MoviesService
    {
        public List<MoviesModelResponse> MoviesModelResponse;
        public MoviesService()
        {
            MoviesModelResponse =
                  new List<MoviesModelResponse>
            {
                new MoviesModelResponse
                {
                    ID = 1,
                    Logo = "http://orig03.deviantart.net/4386/f/2016/017/8/1/batman_vs_superman_icon_by_jeorgebgeorge-d9o9nwx.png",
                    Name = "Khaidi No 150",
                    Reactions = new List<Reaction>
                                {
                                    new Reaction
                                    {
                                        Image = "image_1",
                                        MovieID = 1,
                                        Tag = "Happy",
                                        UID = 1
                                    },
                                    new Reaction
                                    {
                                        Image = "image_2",
                                        MovieID = 1,
                                        Tag = "Happy",
                                        UID = 2
                                    },
                                    new Reaction
                                    {
                                        Image = "image_3",
                                        MovieID = 1,
                                        Tag = "Wink",
                                        UID = 3
                                    },
                                },
                    Release = new DateTime(2017,01,11)
                },
                new MoviesModelResponse
                {
                    ID = 1,
                    Logo = "http://a316.phobos.apple.com/us/r30/Purple1/v4/8b/ec/20/8bec203c-b7d5-8214-8323-6b9f32d26788/mzl.ytvxhekz.512x512-75.png",
                    Name = "La La Land",
                    Reactions = new List<Reaction>
                                {

                                 new Reaction
                                    {
                                        Image = "image_1",
                                        MovieID = 1,
                                        Tag = "Happy",
                                        UID = 1
                                    },
                                    new Reaction
                                    {
                                        Image = "image_2",
                                        MovieID = 1,
                                        Tag = "Happy",
                                        UID = 2
                                    },
                                    new Reaction
                                    {
                                        Image = "image_3",
                                        MovieID = 1,
                                        Tag = "Wink",
                                        UID = 3
                                    },
                                },
                    Release = new DateTime(2016,02,14)//La La Land 14/2/2016
                },
                new MoviesModelResponse
                {
                    ID = 1,
                    Logo = "http://is5.mzstatic.com/image/thumb/Purple111/v4/9d/f9/8d/9df98da9-da24-84ec-6544-89346c238be4/source/512x512bb.jpg",
                    Name = "The Ghazi Attack",
                    Reactions = new List<Reaction>
                                {
                                   new Reaction
                                    {
                                        Image = "image_1",
                                        MovieID = 1,
                                        Tag = "Happy",
                                        UID = 1
                                    },
                                    new Reaction
                                    {
                                        Image = "image_2",
                                        MovieID = 1,
                                        Tag = "Happy",
                                        UID = 2
                                    },
                                    new Reaction
                                    {
                                        Image = "image_3",
                                        MovieID = 1,
                                        Tag = "Wink",
                                        UID = 3
                                    },
                                },
                    Release = new DateTime(2017,02,17)//17/02/2017
                },
                new MoviesModelResponse
                {
                    ID = 1,
                    Logo = "http://orig03.deviantart.net/4386/f/2016/017/8/1/batman_vs_superman_icon_by_jeorgebgeorge-d9o9nwx.png",
                    Name = " Fast & Furious 8",
                    Reactions = new List<Reaction>
                                {
                                    new Reaction
                                    {
                                        Image = "image_1",
                                        MovieID = 1,
                                        Tag = "Happy",
                                        UID = 1
                                    },
                                    new Reaction
                                    {
                                        Image = "image_2",
                                        MovieID = 1,
                                        Tag = "Happy",
                                        UID = 2
                                    },
                                    new Reaction
                                    {
                                        Image = "image_3",
                                        MovieID = 1,
                                        Tag = "Wink",
                                        UID = 3
                                    },
                                },
                    Release = new DateTime(2017,04,14)//14/4/2017
                },
                new MoviesModelResponse
                {
                    ID = 1,
                    Logo = "http://a316.phobos.apple.com/us/r30/Purple1/v4/8b/ec/20/8bec203c-b7d5-8214-8323-6b9f32d26788/mzl.ytvxhekz.512x512-75.png",
                    Name = "Bahubali 2 The conclusion",
                    Reactions = new List<Reaction>
                                {
                         new Reaction
                                    {
                                        Image = "image_1",
                                        MovieID = 1,
                                        Tag = "Happy",
                                        UID = 1
                                    },
                                    new Reaction
                                    {
                                        Image = "image_2",
                                        MovieID = 1,
                                        Tag = "Happy",
                                        UID = 2
                                    },
                                    new Reaction
                                    {
                                        Image = "image_3",
                                        MovieID = 1,
                                        Tag = "Wink",
                                        UID = 3
                                    },
                                },
                    Release = new DateTime(2017,04,28)// 28/04/2017
                    

                },
                new MoviesModelResponse
                {
                    ID = 1,
                    Logo = "http://is5.mzstatic.com/image/thumb/Purple111/v4/9d/f9/8d/9df98da9-da24-84ec-6544-89346c238be4/source/512x512bb.jpg",
                    Name = " Half Girlfriend",
                    Reactions = new List<Reaction>
                                {
                                new Reaction
                                    {
                                        Image = "image_1",
                                        MovieID = 1,
                                        Tag = "Happy",
                                        UID = 1
                                    },
                                    new Reaction
                                    {
                                        Image = "image_2",
                                        MovieID = 1,
                                        Tag = "Happy",
                                        UID = 2
                                    },
                                    new Reaction
                                    {
                                        Image = "image_3",
                                        MovieID = 1,
                                        Tag = "Wink",
                                        UID = 3
                                    },
                                },
                    Release = new DateTime(2017,05,19)//19/05/2017
                           
        

                },
                new MoviesModelResponse
                {
                    ID = 1,
                    Logo = "http://orig03.deviantart.net/4386/f/2016/017/8/1/batman_vs_superman_icon_by_jeorgebgeorge-d9o9nwx.png",
                    Name = "Jagga Jasoos",
                    Reactions = new List<Reaction>
                                {
                                  new Reaction
                                    {
                                        Image = "image_1",
                                        MovieID = 1,
                                        Tag = "Happy",
                                        UID = 1
                                    },
                                    new Reaction
                                    {
                                        Image = "image_2",
                                        MovieID = 1,
                                        Tag = "Happy",
                                        UID = 2
                                    },
                                    new Reaction
                                    {
                                        Image = "image_3",
                                        MovieID = 1,
                                        Tag = "Wink",
                                        UID = 3
                                    },
                                },
                    Release = new DateTime(2017,07,14)//14/7/2017
                },
             
            };
        }

    }
}
