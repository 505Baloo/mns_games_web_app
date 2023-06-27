using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mns_games_web_app.Abstract.Interfaces;
using mns_games_web_app.Data;
using mns_games_web_app.Models;

namespace mns_games_web_app.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly IQuizRepository _quizRepository;
        private readonly IQuestionRepository _questionRepository;


        public QuestionsController(ApplicationDbContext context, IMapper mapper, IQuizRepository quizRepository, IQuestionRepository questionRepository)
        {
            _quizRepository = quizRepository;
            _mapper = mapper;
            _context = context;
            _questionRepository = questionRepository;
        }

        // GET: Questions
        public async Task<IActionResult> Index()
        {
            var questions = await _questionRepository.GetAllIncludesAsync(q => q.Quiz);
            var questionsVM = _mapper.Map<List<QuestionVM>>(questions);
            return View(questionsVM);
        }

        // GET: Questions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Questions == null)
            {
                return NotFound();
            }

            var question = await _context.Questions
                .Include(q => q.Quiz)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // GET: Questions/Create
        public async Task<IActionResult> Create()
        {
            var quizs = await _quizRepository.GetAllAsync();
            ViewData["QuizId"] = new SelectList(quizs, "Id", "Name");
            return View();
        }

        // POST: Questions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateQuestionVM createQuestionVM)
        {
            var correspondingQuiz = await _quizRepository.GetAsync(createQuestionVM.QuizId);

            if (ModelState.IsValid)
            {
                var questionToAdd = _mapper.Map<Question>(createQuestionVM);
                questionToAdd.Quiz = await _quizRepository.GetAsync(createQuestionVM.QuizId);
                await _questionRepository.AddAsync(questionToAdd);
                return RedirectToAction(nameof(Index));
            }
            var quizs = await _quizRepository.GetAllAsync();
            ViewData["QuizId"] = new SelectList(quizs, "Id", "Name");
            return View(createQuestionVM);
        }

        // GET: Questions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Questions == null)
            {
                return NotFound();
            }

            var question = await _context.Questions.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            ViewData["QuizId"] = new SelectList(_context.Quizzes, "Id", "AppUserId", question.QuizId);
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Duration,QuizId")] Question question)
        {
            if (id != question.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(question);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionExists(question.Id))
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
            ViewData["QuizId"] = new SelectList(_context.Quizzes, "Id", "AppUserId", question.QuizId);
            return View(question);
        }

        // GET: Questions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Questions == null)
            {
                return NotFound();
            }

            var question = await _context.Questions
                .Include(q => q.Quiz)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Questions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Questions'  is null.");
            }
            var question = await _context.Questions.FindAsync(id);
            if (question != null)
            {
                _context.Questions.Remove(question);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionExists(int id)
        {
          return (_context.Questions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
