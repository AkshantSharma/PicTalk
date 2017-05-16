using System.Collections.Generic;
using PicTalk.Models.ModelResponses;
using PicTalk.Services;

namespace PicTalk.ViewModels
{
    
    public class HomeViewModel
    {
        public List<MoviesModelResponse> MoviesmodelResponse;

        public HomeViewModel()
        {
            MoviesmodelResponse = new MoviesService().MoviesModelResponse;
        }
    }
}
