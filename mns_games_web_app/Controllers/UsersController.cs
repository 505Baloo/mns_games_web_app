using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using mns_games_web_app.Abstract.Interfaces;
using mns_games_web_app.Constants;
using mns_games_web_app.Data;
using mns_games_web_app.Models;

namespace mns_games_web_app.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IQuizRepository _quizRepository;

        public UsersController(UserManager<AppUser> userManager, IMapper autoMapper, IQuizRepository quizRepository)
        {
            _userManager = userManager;
            _mapper = autoMapper;
            _quizRepository = quizRepository;
        }
        
        // GET: UsersController
        public async Task<ActionResult> Index()
        {
            var users = await _userManager.GetUsersInRoleAsync(Roles.User);
            var usersListVm = _mapper.Map<List<AppUserListVM>>(users);
            return View(usersListVm);
        }

        public async Task<ActionResult> ViewQuizs(string id)
        {
            var appUserQuizsVM = await _quizRepository.GetAppUserQuizs(id);
            return View(appUserQuizsVM);
        }
    }
}
