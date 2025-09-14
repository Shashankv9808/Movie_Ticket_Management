using BangloreTalkies.Data;
using BangloreTalkies.Models;
using Microsoft.AspNetCore.Mvc;

namespace BangloreTalkies.Controllers
{
    public class MoviesController : Controller
    {
        SampleData sampleData = new SampleData();
        public IActionResult Index(string language = null, string genre = null)
        {
            ViewBag.CurrentLocation = "Bangalore"; // This would come from user session/location service

            MoviesViewModel model = new()
            {
                PremieringThisWeek = sampleData.GetPremieringMovies(),
                NowShowing = sampleData.GetNowShowingMovies(),
                ComingSoon = sampleData.GetComingSoonMovies(),
                HindiMovies = sampleData.GetMoviesByLanguage("Hindi"),
                EnglishMovies = sampleData.GetMoviesByLanguage("English"),
                RegionalMovies = sampleData.GetRegionalMovies(),
                HeroMovies = sampleData.GetHeroSliderMovies()
            };

            // Apply filters if provided
            if (!string.IsNullOrEmpty(language))
            {
                model.PremieringThisWeek = model.PremieringThisWeek.Where(m => m.Language.Equals(language, StringComparison.OrdinalIgnoreCase)).ToList();
                model.NowShowing = model.NowShowing.Where(m => m.Language.Equals(language, StringComparison.OrdinalIgnoreCase)).ToList();
                model.ComingSoon = model.ComingSoon.Where(m => m.Language.Equals(language, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrEmpty(genre))
            {
                model.PremieringThisWeek = model.PremieringThisWeek.Where(m => m.Genre.Contains(genre, StringComparison.OrdinalIgnoreCase)).ToList();
                model.NowShowing = model.NowShowing.Where(m => m.Genre.Contains(genre, StringComparison.OrdinalIgnoreCase)).ToList();
                model.ComingSoon = model.ComingSoon.Where(m => m.Genre.Contains(genre, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            return View(model);
        }
        [HttpPost]
        public JsonResult ToggleMovieLike(int movieId)
        {
            // In a real application, this would update the database
            // For now, we'll just return a success response
            return Json(new { success = true, movieId = movieId });
        }

        [HttpPost]
        public JsonResult SetMovieNotification(int movieId)
        {
            // In a real application, this would save notification preference
            return Json(new { success = true, movieId = movieId, message = "Notification set successfully" });
        }
    }
}
