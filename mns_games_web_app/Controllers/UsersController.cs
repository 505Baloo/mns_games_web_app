using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using mns_games_web_app.Abstract.Interfaces;
using mns_games_web_app.Constants;
using mns_games_web_app.Data;
using mns_games_web_app.Models;
using mns_games_web_app.Repositories;

namespace mns_games_web_app.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IQuizRepository _quizRepository;
        private readonly IThemeRepository _themeRepository;

        public UsersController(UserManager<AppUser> userManager, IMapper autoMapper, IQuizRepository quizRepository, IThemeRepository themeRepository)
        {
            _userManager = userManager;
            _mapper = autoMapper;
            _quizRepository = quizRepository;
            _themeRepository = themeRepository;
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

        // GET: UsersController/EditQuiz/5
        public async Task<ActionResult> EditQuiz(int id)
        {
            var quiz = await _quizRepository.GetIncludesAsync(id, q => q.Theme, q => q.AppUser);
            if (quiz == null)
            {
                return NotFound();
            }
            var themes = await _themeRepository.GetAllAsync();
            var editQuizVM = _mapper.Map<EditQuizVM>(quiz);
            ViewData["ThemeId"] = new SelectList(themes, "Id", "Title", editQuizVM.ThemeId);
            return View(editQuizVM);
        }

        //POST: UsersController/EditQuiz/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditQuiz(int id, EditQuizVM editQuizVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var quiz = await _quizRepository.GetAsync(editQuizVM.Id);
                    if (quiz == null)
                        return NotFound();

                    quiz.Name = editQuizVM.Name;
                    quiz.Duration = editQuizVM.Duration;
                    quiz.ThemeId = editQuizVM.ThemeId;
                    quiz.Theme = await _themeRepository.GetAsync(quiz.ThemeId);
                    await _quizRepository.UpdateAsync(quiz);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch(Exception ex) 
            {
                ModelState.AddModelError(string.Empty, "An error has occured! Please try again later.");
            }
            return View(editQuizVM);
        }
    }
}
