using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mns_games_web_app.Abstract.Interfaces;
using mns_games_web_app.Data;
using mns_games_web_app.Models;
using mns_games_web_app.Models.ViewModels;

namespace mns_games_web_app.Repositories
{
    public class QuizRepository : BasicRepository<Quiz>, IQuizRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public QuizRepository(ApplicationDbContext context, UserManager<AppUser> userManager, IMapper mapper) : base(context)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<AppUserQuizsVM> GetAppUserQuizs(string userId)
        {
            var quizs = await _context.Quizzes.Include(q => q.Theme).Where(u => u.AppUserId == userId).ToListAsync();
            var user = await _userManager.FindByIdAsync(userId);
            
            var appUserQuizsModel = _mapper.Map<AppUserQuizsVM>(user);
            appUserQuizsModel.Quizs = _mapper.Map<List<QuizVM>>(quizs);

            return appUserQuizsModel;
        }
    }
}
