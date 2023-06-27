using AutoMapper;
using mns_games_web_app.Data;
using mns_games_web_app.Models;

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
            CreateMap<AppUser, AppUserListVM>().ReverseMap();
            CreateMap<AppUser, AppUserQuizsVM>().ReverseMap();
            CreateMap<Question, QuestionVM>().ReverseMap();
            CreateMap<Question, CreateQuestionVM>().ReverseMap();
        }
    }
}
