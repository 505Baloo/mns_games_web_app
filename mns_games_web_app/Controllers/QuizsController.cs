using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mns_games_web_app.Abstract.Interfaces;
using mns_games_web_app.Data;
using mns_games_web_app.Models;

namespace mns_games_web_app.Controllers
{
    [Authorize]
    public class QuizsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IThemeRepository _themeRepository;
        private readonly IQuizRepository _quizRepository;
        private readonly UserManager<AppUser> _userManager;


        public QuizsController(IQuizRepository quizRepository, IThemeRepository themeRepository, IMapper mapper, UserManager<AppUser> userManager)
        {
            _quizRepository = quizRepository;
            _themeRepository = themeRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        // GET: Quizs
        public async Task<IActionResult> Index()
        {
            var quizs = await _quizRepository.GetAllIncludesAsync(q => q.Theme, q => q.AppUser);
            var quizsVM = _mapper.Map<List<QuizVM>>(quizs);
            return View(quizsVM);
        }

        // GET: Quizs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var quiz = await _quizRepository.GetIncludesAsync(id, q => q.Theme, q => q.AppUser, q => q.Questions);

            if (quiz == null)
                return NotFound();

            DetailsQuizVM detailsQuizVM = _mapper.Map<DetailsQuizVM>(quiz);

            return View(detailsQuizVM);
        }

        // GET: Quizs/Create
        public async Task<IActionResult> Create()
        {
            var themes = await _themeRepository.GetAllAsync();
            ViewData["ThemeId"] = new SelectList(themes, "Id", "Title");
            return View();
        }

        // POST: Quizs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateQuizVM createQuizVM)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var theme = await _themeRepository.GetAsync(createQuizVM.ThemeId);

                if (user == null)
                    return RedirectToAction("Login", "Account");

                if (theme == null)
                    ModelState.AddModelError(string.Empty, "Please select a valid theme.");

                var quiz = _mapper.Map<Quiz>(createQuizVM);
                quiz.AppUserId = user.Id;
                quiz.Theme = theme;
                await _quizRepository.AddAsync(quiz);

                return RedirectToAction(nameof(Index));
            }

            var themes = await _themeRepository.GetAllAsync();
            ViewData["ThemeId"] = new SelectList(themes, "Id", "Title");

            return View(createQuizVM);
        }


        // GET: Quizs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var quiz = await _quizRepository.GetIncludesAsync(id, q => q.Theme, q => q.AppUser);

            if (quiz == null)
                return NotFound();
            
            var themes = await _themeRepository.GetAllAsync();
            ViewData["ThemeId"] = new SelectList(themes, "Id", "Title", quiz.ThemeId);
            var editQuizVM = _mapper.Map<EditQuizVM>(quiz);

            return View(editQuizVM);
        }

        // POST: Quizs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditQuizVM editQuizVM)
        {
            if (id != editQuizVM.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var quiz = _mapper.Map<Quiz>(editQuizVM);
                    await _quizRepository.UpdateAsync(quiz);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await QuizExists(editQuizVM.Id))
                        return NotFound();
                    else
                        throw;
                }
            }
            var themes = await _themeRepository.GetAllAsync();
            ViewData["ThemeId"] = new SelectList(themes, "Id", "Title", editQuizVM.ThemeId);

            return View(editQuizVM);
        }

        // POST: Quizs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _quizRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> QuizExists(int id)
        {
            return await _quizRepository.Exists(id);
        }
    }
}
