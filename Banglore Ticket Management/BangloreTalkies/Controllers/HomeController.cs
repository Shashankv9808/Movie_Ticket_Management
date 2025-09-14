using System.Diagnostics;
using BangloreTalkies.Data;
using BangloreTalkies.Models;
using Microsoft.AspNetCore.Mvc;

namespace BangloreTalkies.Controllers
{
    public class HomeController(ILogger<HomeController> logger) : Controller
    {
        
        private readonly ILogger<HomeController> _logger = logger;
        SampleData sampleData = new SampleData();

        public IActionResult Index()
        {
            var model = new HomePageViewModel
            {
                FeaturedMovies = sampleData.GetFeaturedMovies(),
                UpcomingEvents = sampleData.GetUpcomingEvents(),
                Activities = sampleData.GetActivities(),
                EnglishMovies = sampleData.GetEnglishMovies()
            };
            return View(model);
        }

        public IActionResult Movies(string language = null, string genre = null, string format = null)
        {
            ViewBag.CurrentLocation = "Bangalore"; // This would come from user session/location service

            var model = new MoviesViewModel
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

            return View("Movies", model);
        }

        public IActionResult Events()
        {
            var model = new EventsViewModel
            {
                MusicEvents = sampleData.GetMusicEvents(),
                SportsEvents = sampleData.GetSportsEvents(),
                ComedyShows = sampleData.GetComedyShows()
            };
            return View(model);
        }

        public IActionResult Activities()
        {
            var model = new ActivitiesViewModel
            {
                WaterParks = sampleData.GetWaterParks(),
                AdventureActivities = sampleData.GetAdventureActivities(),
                KidsActivities = sampleData.GetKidsActivities()
            };
            return View(model);
        }

        [HttpGet]
        public JsonResult Search(string query, string category = "all")
        {
            var results = new
            {
                Movies = category == "all" || category == "movies" ?
                    sampleData.GetAllRecentMovies().Where(m => m.Title.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                                            m.Genre.Contains(query, StringComparison.OrdinalIgnoreCase)) : new List<MovieItem>(),
                Events = category == "all" || category == "events" ?
                    sampleData.GetUpcomingEvents().Where(e => e.Title.Contains(query, StringComparison.OrdinalIgnoreCase)) : new List<EventItem>(),
                Activities = category == "all" || category == "activities" ?
                    sampleData.GetActivities().Where(a => a.Title.Contains(query, StringComparison.OrdinalIgnoreCase)) : new List<ActivityItem>()
            };
            return Json(results);
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


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
