using AutoMapper;
using mns_games_web_app.Data;
using mns_games_web_app.Models.ViewModels;

namespace mns_games_web_app.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            //CreateMap<Quiz, QuizVM>().ReverseMap();
            CreateMap<Quiz, QuizVM>()
            .ForMember(dest => dest.ThemeName, opt => opt.MapFrom(src => src.Theme.Title));
        }
    }
}
