using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mns_games_web_app.Data;
using mns_games_web_app.Models;
using mns_games_web_app.Models.ViewModels;

namespace mns_games_web_app.Controllers
{
    public class QuizsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;


        public QuizsController(ApplicationDbContext context, IMapper mapper, UserManager<AppUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        // GET: Quizs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Quizzes.Include(q => q.Theme).Include(q => q.AppUser);

            var quizs = _mapper.Map<List<QuizVM>>(await applicationDbContext.ToListAsync());
            return View(quizs);
        }

        // GET: Quizs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Quizzes == null)
            {
                return NotFound();
            }

            var quiz = await _context.Quizzes
                .Include(q => q.Theme)
                .Include(q => q.AppUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quiz == null)
            {
                return NotFound();
            }
            DetailsQuizVM detailsQuizVM = _mapper.Map<DetailsQuizVM>(quiz);
            return View(detailsQuizVM);
        }

        // GET: Quizs/Create
        public IActionResult Create()
        {
            ViewData["ThemeId"] = new SelectList(_context.Themes, "Id", "Title");
            return View();
        }

        // POST: Quizs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateQuizVM createQuizVM)
        {
            if (ModelState.IsValid)
            {
                // get connected user
                var user = await _userManager.GetUserAsync(User);
                if(user != null)
                {
                    // convert to actual data entity
                    var quiz = _mapper.Map<Quiz>(createQuizVM);
                    quiz.AppUserId = user.Id;
                    _context.Add(quiz);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                foreach (var entry in ModelState)
                {
                    if (entry.Value.Errors.Any())
                    {
                        var errorMessage = entry.Value.Errors.First().ErrorMessage;
                        // Log or display the error message
                    }
                }
            }
            ViewData["ThemeId"] = new SelectList(_context.Themes, "Id", "Title", createQuizVM.ThemeId);
            return View(createQuizVM);
        }

        // GET: Quizs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Quizzes == null)
            {
                return NotFound();
            }

            var quiz = await _context.Quizzes.FindAsync(id);
            if (quiz == null)
            {
                return NotFound();
            }
            ViewData["ThemeId"] = new SelectList(_context.Themes, "Id", "Id", quiz.ThemeId);
            var editQuizVM = _mapper.Map<EditQuizVM>(quiz);
            return View(editQuizVM);
        }

        // POST: Quizs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditQuizVM editQuizVM)
        {
            if (id != editQuizVM.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var quiz = _mapper.Map<Quiz>(editQuizVM);
                    _context.Update(quiz);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuizExists(editQuizVM.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(editQuizVM);
        }

        // GET: Quizs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Quizzes == null)
            {
                return NotFound();
            }

            var quiz = await _context.Quizzes
                .Include(q => q.Theme)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quiz == null)
            {
                return NotFound();
            }

            return View(quiz);
        }

        // POST: Quizs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Quizzes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Quizzes'  is null.");
            }
            var quiz = await _context.Quizzes.FindAsync(id);
            if (quiz != null)
            {
                _context.Quizzes.Remove(quiz);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuizExists(int id)
        {
          return (_context.Quizzes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
