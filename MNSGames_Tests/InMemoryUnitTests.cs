using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mns_games_web_app.Data;
using mns_games_web_app.Repositories;

namespace MNSGames_Tests
{
    [TestClass]
    public class UserRepositoryTests
    {
        private ApplicationDbContext _context;
        private QuizRepository _quizRepository;
        private UserManager<AppUser> _userManager;

        [TestInitialize]
        public void Initialize()
        {
            _context = ApplicationDbContextFactory.CreateDbContextForInMemory();
            _userManager = new UserManager<AppUser>(new UserStore<AppUser>(_context), null, null, null, null, null, null, null, null);
            _quizRepository = new QuizRepository(_context, null, null);
        }

        [TestMethod]
        public async Task CreateQuizAsync_ShouldCreateQuizWithUserAndTheme()
        {
            // Arrange
            var user = new AppUser
            {
                Nickname = "TestAppUser",
                Email = "TestAppUser@gmail.com",
                PasswordHash = "PlainTextPassword", // plain-text password for testing purposes
            };
            await _userManager.CreateAsync(user);

            var theme = new Theme
            {
                Title = "Test Theme",
            };

            _context.Themes.Add(theme);
            await _context.SaveChangesAsync();

            var quizToAdd = new Quiz
            {
                Name = "Test Quiz",
                AppUserId = user.Id, // user created above
                ThemeId = theme.Id, // theme created above
            };

            // Act
            await _quizRepository.AddAsync(quizToAdd);
            await _context.SaveChangesAsync(); // Save changes to the in-memory database

            // Assert
            var createdQuiz = await _context.Quizzes
                .Include(q => q.AppUser)
                .Include(q => q.Theme)
                .FirstOrDefaultAsync(q => q.Name == "Test Quiz");

            Assert.IsNotNull(createdQuiz); // To ensure the quiz was created
            Assert.AreEqual("Test Theme", createdQuiz.Theme.Title); // Check theme properties
            Assert.AreEqual("TestAppUser", createdQuiz.AppUser.Nickname); // Check user properties
            Assert.IsNotNull(createdQuiz.AppUser); // To ensure the user is associated with the quiz
            Assert.IsNotNull(createdQuiz.Theme); // To ensure the theme is associated with the quiz
            Assert.AreEqual(user.Id, createdQuiz.AppUserId); // To ensure quiz's userId matches created userId
            Assert.AreEqual(theme.Id, createdQuiz.ThemeId); // To ensure quiz's userId matches created userId
        }

        [TestMethod]
        public async Task UpdateQuizAsync_ShouldUpdateQuiz()
        {
            // Arrange
            var user = new AppUser
            {
                Nickname = "TestAppUser",
                Email = "TestAppUser@gmail.com",
                PasswordHash = "PlainTextPassword", // plain-text password for testing purposes
            };
            await _userManager.CreateAsync(user);

            var theme = new Theme
            {
                Title = "Test Theme",
            };

            var newTheme = new Theme
            {
                Title = "Updated Test Theme",
            };
            _context.Themes.AddRange(theme, newTheme);
            await _context.SaveChangesAsync();

            var quizToUpdate = new Quiz
            {
                Name = "Original Quiz",
                ThemeId = theme.Id,
                AppUserId = user.Id
            };

            await _quizRepository.AddAsync(quizToUpdate);
            await _context.SaveChangesAsync();

            // Modify the quiz
            quizToUpdate.Name = "Updated Quiz Name";
            quizToUpdate.ThemeId = newTheme.Id;

            // Act
            await _quizRepository.UpdateAsync(quizToUpdate);
            await _context.SaveChangesAsync(); // Save changes to the in-memory database

            // Assert
            var updatedQuiz = await _context.Quizzes.FindAsync(quizToUpdate.Id);
            Assert.IsNotNull(updatedQuiz); // Ensure the quiz was found
            Assert.AreEqual("Updated Quiz Name", updatedQuiz.Name); // Check if the name is updated correctly
            Assert.AreEqual(updatedQuiz.ThemeId, newTheme.Id); // Check if the updated quiz themeId matches second theme
            //...
        }

        [TestCleanup]
        public void Cleanup()
        {
            _context.Dispose();
        }
    }

}

