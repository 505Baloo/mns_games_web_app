using AutoMapper;
using mns_games_web_app.Data;
using mns_games_web_app.Models;
using mns_games_web_app.Models.ViewModels;

namespace mns_games_web_app.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Theme, ThemeVM>().ReverseMap();
            CreateMap<Quiz, CreateQuizVM>().ReverseMap();
            CreateMap<Quiz, QuizVM>().ReverseMap();
            CreateMap<Quiz, DetailsQuizVM>().ReverseMap();
            CreateMap<Quiz, EditQuizVM>().ReverseMap();
        }
    }
}
