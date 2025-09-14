using System.Diagnostics;
using BangloreTalkies.Models;
using Microsoft.AspNetCore.Mvc;

namespace BangloreTalkies.Controllers
{
    public class HomeController(ILogger<HomeController> logger) : Controller
    {
        private const string NowShowing = "Now Showing";
        private const string PremieringThisWeek = "Premiering This Week";
        private const string ComingSoon = "Coming Soon";
        private const string NotShowing = "Not Showing";
        private readonly ILogger<HomeController> _logger = logger;

        public IActionResult Index()
        {
            var model = new HomePageViewModel
            {
                FeaturedMovies = GetFeaturedMovies(),
                UpcomingEvents = GetUpcomingEvents(),
                Activities = GetActivities(),
                EnglishMovies = GetEnglishMovies()
            };
            return View(model);
        }

        public IActionResult Movies(string language = null, string genre = null, string format = null)
        {
            ViewBag.CurrentLocation = "Bangalore"; // This would come from user session/location service

            var model = new MoviesViewModel
            {
                PremieringThisWeek = GetPremieringMovies(),
                NowShowing = GetNowShowingMovies(),
                ComingSoon = GetComingSoonMovies(),
                HindiMovies = GetMoviesByLanguage("Hindi"),
                EnglishMovies = GetMoviesByLanguage("English"),
                RegionalMovies = GetRegionalMovies(),
                HeroMovies = GetHeroSliderMovies()
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

        public IActionResult Events()
        {
            var model = new EventsViewModel
            {
                MusicEvents = GetMusicEvents(),
                SportsEvents = GetSportsEvents(),
                ComedyShows = GetComedyShows()
            };
            return View(model);
        }

        public IActionResult Activities()
        {
            var model = new ActivitiesViewModel
            {
                WaterParks = GetWaterParks(),
                AdventureActivities = GetAdventureActivities(),
                KidsActivities = GetKidsActivities()
            };
            return View(model);
        }

        [HttpGet]
        public JsonResult Search(string query, string category = "all")
        {
            var results = new
            {
                Movies = category == "all" || category == "movies" ?
                    GetAllRecentMovies().Where(m => m.Title.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                                            m.Genre.Contains(query, StringComparison.OrdinalIgnoreCase)) : new List<MovieItem>(),
                Events = category == "all" || category == "events" ?
                    GetUpcomingEvents().Where(e => e.Title.Contains(query, StringComparison.OrdinalIgnoreCase)) : new List<EventItem>(),
                Activities = category == "all" || category == "activities" ?
                    GetActivities().Where(a => a.Title.Contains(query, StringComparison.OrdinalIgnoreCase)) : new List<ActivityItem>()
            };
            return Json(results);
        }

        // Movie-specific actions
        [HttpGet]
        public IActionResult MovieDetails(int id)
        {
            var movie = GetAllRecentMovies().FirstOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            var model = new MovieDetailsViewModel
            {
                Movie = movie,
                Showtimes = GetMovieShowtimes(id),
                SimilarMovies = GetSimilarMovies(movie.Genre, movie.Id)
            };

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

        // New method to get hero slider movies with rich data
        private List<MovieItem> GetHeroSliderMovies()
        {
            return GetAllRecentMovies().Where(movie => movie.Status == NowShowing || movie.Status == PremieringThisWeek || movie.Status == ComingSoon).Take(5).ToList();
        }

        private List<MovieItem> GetPremieringMovies()
        {
            return GetAllRecentMovies().Where(movie => movie.Status == PremieringThisWeek).ToList();
        }

        private List<MovieItem> GetNowShowingMovies()
        {
            return GetAllRecentMovies().Where(movie => movie.Status == NowShowing).ToList();
        }

        private List<MovieItem> GetComingSoonMovies()
        {
            return GetAllRecentMovies().Where(movie => movie.Status == ComingSoon).ToList();
        }

        private List<MovieItem> GetFeaturedMovies()
        {
            return GetPremieringMovies().Take(4).ToList();
        }

        private List<MovieItem> GetEnglishMovies()
        {
            return GetAllRecentMovies().Where(m => m.Language == "English").Take(6).ToList();
        }

        private List<MovieItem> GetMoviesByLanguage(string language)
        {
            return GetAllRecentMovies().Where(m => m.Language.Equals(language, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        private List<MovieItem> GetRegionalMovies()
        {
            return
            [
                new(){Id = 6,Title = "Pushpa 2",Rating = "UA16+",Language = "Telugu",Price = "₹250 onwards",Status = ComingSoon,Genre = "Action",Duration = "2h 45m",ReleaseDate = "15 Dec 2025"},
                new(){Id = 7,Title = "KGF Chapter 3",Rating = "UA16+",Language = "Kannada",Price = "₹300 onwards",Status = ComingSoon,Genre = "Action",Duration = "2h 50m",ReleaseDate = "25 Dec 2025"},
                new(){Id = 8,Title = "RRR 2",Rating = "UA13+",Language = "Telugu",Price = "₹350 onwards",Status = ComingSoon,Genre = "Period Drama",Duration = "3h 10m",ReleaseDate = "26 Mar 2025"},
                new(){Id = 9,Title = "Vikram 2",Rating = "UA16+",Language = "Tamil",Price = "₹280 onwards",Status = ComingSoon,Genre = "Action",Duration = "2h 35m",ReleaseDate = "14 Apr 2025"},
            ];
        }

        private List<MovieItem> GetAllRecentMovies()
        {
            //TODO: DB Call to fetch recent movies which are going to be shown or are showing. For now, returning a static list.
            var allMovies = new List<MovieItem> {
                new()
                {
                    Id = 1,
                    Title = "Mahavatar Narsimha",
                    Rating = "UA13+",
                    Language = "Kannada",
                    Genre = "Mythology Drama",
                    Price = "₹199 onwards",
                    Status = NowShowing,
                    Duration = "2h 35m",
                    Description = "Experience the divine epic of Lord Narsimha in stunning visuals and powerful storytelling that will touch your soul.",
                    ImageUrl = "/images/mahavatar-narsimha-poster.jpg",
                    TrailerUrl = "https://www.youtube.com/watch?v=p7eE_dn9u4k",
                    ImdbRating = 8.1,
                    Director = "Ashwin Kumar",
                    Cast = "Aditya Raj Sharma, Haripriya Matta, Priyanka Bhandari",
                    IsBookingOpen = true,
                    HasSubtitles = false,
                    Languages = new List<string> { "Kannada", "Hindi", "Telugu", "Tamil" },
                    Formats = new List<string> { "2D", "3D", "IMAX" },
                    LikeCount = 3450,
                    ReviewCount = 156
                },
                new()
                {
                    Id = 2,
                    Title = "Param Sundari",
                    Rating = "UA13+",
                    Language = "Hindi",
                    Genre = "Superhero Action",
                    Price = "₹450 onwards",
                    Status = NowShowing,
                    Duration = "2h 216m",
                    Description = "In Kerala's picturesque backwaters, a North Indian and South Indian find unexpected love. Their cultural differences spark a hilarious and chaotic romance, full of twists and turns. Two diverse worlds collide in a heartwarming story.",
                    ImageUrl = "/images/param-sundari-poster.jpg",
                    TrailerUrl = "https://youtu.be/fdWnfzsx-ks?list=RDfdWnfzsx-ks",
                    ImdbRating = 0,
                    Director = "Tushar Jalota",
                    Cast = "David Corenswet, Rachel Brosnahan, Nicholas Hoult",
                    IsBookingOpen = false,
                    HasSubtitles = true,
                    Languages = ["Hindi"],
                    Formats = ["2D", "3D", "IMAX", "Dolby Atmos"],
                    LikeCount = 10,
                    ReviewCount = 0,
                    ReleaseDate = "20 Aug 2025"
                },
                new()
                {
                    Id = 3,
                    Title = "War 2",
                    Rating = "UA16+",
                    Language = "Hindi",
                    Genre = "Action Thriller",
                    Price = "₹399 onwards",
                    Status = NotShowing,
                    Duration = "2h 30m",
                    Description = "The ultimate action thriller returns with more explosive sequences and heart-stopping moments that will redefine cinema.",
                    ImageUrl = "/images/war-2-poster.jpg",
                    TrailerUrl = "https://youtube.com/watch?v=example2",
                    ImdbRating = 8.5,
                    ReleaseDate = "15 Sep 2025",
                    Director = "Siddharth Anand",
                    Cast = "Hrithik Roshan, Tiger Shroff, Deepika Padukone",
                    IsBookingOpen = false,
                    HasSubtitles = true,
                    Languages = new List<string> { "Hindi", "English", "Tamil", "Telugu" },
                    Formats = new List<string> { "2D", "3D", "IMAX", "4DX" },
                    LikeCount = 5670,
                    ReviewCount = 0
                },
                new()
                {
                    Id = 4,
                    Title = "Vash Level 2",
                    Rating = "A",
                    Language = "Hindi",
                    Genre = "Supernatural Horror",
                    Price = "₹249 onwards",
                    Status = NotShowing,
                    Duration = "2h 05m",
                    Description = "Twelve years after saving his daughter Arya from a dark force, Atharva learns it never left her. When strange events begin again, he must fight to save her once more.",
                    ImageUrl = "/images/vash-level-2-poster.jpg",
                    TrailerUrl = "https://youtu.be/CtrOP7Ji55s",
                    ImdbRating = 8.0,
                    Director = "Rajesh Kumar",
                    Cast = "Vikram Sharma, Priya Patel, Rajesh Khanna",
                    IsBookingOpen = true,
                    HasSubtitles = true,
                    Languages = ["Hindi", "English"],
                    Formats = ["2D", "IMAX"],
                    LikeCount = 1250,
                    ReviewCount = 89
                },
                new()
                {
                    Id = 5,
                    Title = "The Roses",
                    Rating = "A",
                    Language = "English",
                    Price = "₹320 onwards",
                    Status = NotShowing,
                    Genre = "Romance, Comedy",
                    Duration = "1h 58m",
                    Description = "A tinderbox of competition and resentments underneath the façade of a picture-perfect couple is ignited when the husband's professional dreams come crashing down.",
                    ImageUrl = "/images/the-roses-poster.jpg",
                    TrailerUrl = "https://youtu.be/XkgMaS5gbaA",
                    ImdbRating = 7.5,
                    Director = "Jay Roach",
                    Cast = "Olivia Colman, Benedict Cumberbatch, Kate McKinnon",
                    IsBookingOpen = true,
                    HasSubtitles = true,
                    Languages = ["English", "Hindi"],
                    Formats = ["2D", "IMAX", "Dolby Atmos"],
                    LikeCount = 890,
                    ReviewCount = 45,
                    ReleaseDate = "31 Aug 2025"
                },
                new()
                {
                    Id = 6,
                    Title = "Pushpa 2",
                    Rating = "UA16+",
                    Language = "Telugu",
                    Price = "₹250 onwards",
                    Status = ComingSoon,
                    Genre = "Action",
                    Duration = "2h 45m",
                    Description = "Twelve years after saving his daughter Arya from a dark force, Atharva learns it never left her. When strange events begin again, he must fight to save her once more.",
                    ImageUrl = "/images/pushpa2-poster.jpg",
                    TrailerUrl = "https://youtu.be/CtrOP7Ji55s",
                    ImdbRating = 8.0,
                    Director = "Rajesh Kumar",
                    Cast = "Vikram Sharma, Priya Patel, Rajesh Khanna",
                    IsBookingOpen = true,
                    HasSubtitles = true,
                    Languages = ["Telugu","Hindi","Tamil","Kannada"],
                    Formats = ["2D", "IMAX", "Dolby Atmos"],
                    LikeCount = 1250,
                    ReviewCount = 89,
                    ReleaseDate = "15 Dec 2025"
                },
                new(){
                    Id = 7,
                    Title = "KGF Chapter 2",
                    Rating = "UA16+",
                    Language = "Kannada",
                    Price = "₹300 onwards",
                    Status = ComingSoon,
                    Genre = "Action",
                    Duration = "2h 50m",
                    Description = "Twelve years after saving his daughter Arya from a dark force, Atharva learns it never left her. When strange events begin again, he must fight to save her once more.",
                    ImageUrl = "/images/KGF2-poster.png",
                    TrailerUrl = "https://youtu.be/CtrOP7Ji55s",
                    ImdbRating = 8.0,
                    Director = "Rajesh Kumar",
                    Cast = "Vikram Sharma, Priya Patel, Rajesh Khanna",
                    IsBookingOpen = true,
                    HasSubtitles = true,
                    Languages = ["Telugu","Hindi","Tamil","Kannada"],
                    Formats = ["2D", "IMAX", "Dolby Atmos"],
                    LikeCount = 1250,
                    ReviewCount = 89,
                    ReleaseDate = "25 Dec 2024"
                },
                new(){
                    Id = 8,
                    Title = "RRR",
                    Rating = "UA13+",
                    Language = "Telugu",
                    Price = "₹350 onwards",
                    Status = ComingSoon,
                    Genre = "Period Drama",
                    Duration = "3h 10m",
                    Description = "Twelve years after saving his daughter Arya from a dark force, Atharva learns it never left her. When strange events begin again, he must fight to save her once more.",
                    ImageUrl = "/images/RRR-poster.jpg",
                    TrailerUrl = "https://youtu.be/CtrOP7Ji55s",
                    ImdbRating = 8.0,
                    Director = "Rajesh Kumar",
                    Cast = "Vikram Sharma, Priya Patel, Rajesh Khanna",
                    IsBookingOpen = true,
                    HasSubtitles = true,
                    Languages = ["Telugu","Hindi","Tamil","Kannada"],
                    Formats = ["2D", "IMAX", "Dolby Atmos"],
                    LikeCount = 1250,
                    ReviewCount = 89,
                    ReleaseDate = "26 Mar 2025"
                },
                new()
                {
                    Id = 9,
                    Title = "Vikram",
                    Rating = "UA16+",
                    Language = "Tamil",
                    Price = "₹280 onwards",
                    Status = NowShowing,
                    Genre = "Action",
                    Duration = "2h 35m",
                    Description = "Twelve years after saving his daughter Arya from a dark force, Atharva learns it never left her. When strange events begin again, he must fight to save her once more.",
                    ImageUrl = "/images/Vikram-poster.jpg",
                    TrailerUrl = "https://youtu.be/CtrOP7Ji55s",
                    ImdbRating = 8.0,
                    Director = "Rajesh Kumar",
                    Cast = "Vikram Sharma, Priya Patel, Rajesh Khanna",
                    IsBookingOpen = true,
                    HasSubtitles = true,
                    Languages = ["Telugu","Hindi","Tamil","Kannada"],
                    Formats = ["2D", "IMAX", "Dolby Atmos"],
                    LikeCount = 1250,
                    ReviewCount = 89,
                    ReleaseDate = "14 Apr 2025"
                },
                new()
                {
                    Id = 10,
                    Title = "Mission Kashmir 2",
                    Rating = "UA16+",
                    Language = "Hindi",
                    Genre = "Action",
                    Price = "₹350 onwards",
                    Status = PremieringThisWeek,
                    Duration = "2h 25m",
                    Description="A police officer adopts the son and sole survivor of a family he has massacred while pursuing a terrorist. After some time the foster son finds out what the stepfather did.",
                    ImageUrl = "/images/Mission-Kashmir-2-poster.jpg",
                    TrailerUrl = "https://www.youtube.com/watch?v=i45bkyPvud8",
                    ImdbRating = 6.6,
                    Director = "Vidhu Vinod Chopra",
                    Cast = "Sanjay Dutt, Hrithik Roshan. Preity G Zinta",
                    IsBookingOpen = true,
                    HasSubtitles = true,
                    Languages = ["Hindi", "Telugu", "Tamil"],
                    Formats = ["2D", "3D", "IMAX"],
                    LikeCount = 3450,
                    ReviewCount = 156,
                    ReleaseDate = "01 Sep 2025"
                },
                new()
                {
                    Id = 11,
                    Title = "Su From So",
                    Rating = "UA13+",
                    Language = "Kannada",
                    Genre = "Horror, Comedy",
                    Price = "₹250 onwards",
                    Status = PremieringThisWeek,
                    Duration = "2h 10m",
                    Description="In a quiet village, a boy's innocent crush unleashes strange events that have everyone convinced he's brought a ghost along with his feelings.",
                    ImageUrl = "/images/su-from-so-poster.jpg",
                    TrailerUrl = "https://www.youtube.com/watch?v=fTX5VxC8eMg",
                    ImdbRating = 8.8,
                    Director = "J.P. Tuminadu",
                    Cast = "Raj B. Shetty, Shanil Guru, J.P. Tuminadu",
                    IsBookingOpen = true,
                    HasSubtitles = true,
                    Languages = ["Kannada", "Hindi"],
                    Formats = ["2D", "3D", "IMAX", "Dolby Atmos"],
                    LikeCount = 11780,
                    ReviewCount = 1325,
                    ReleaseDate = "25 July 2025"
                },
                new()
                {
                    Id = 12,
                    Title = "Superman",
                    Rating = "UA13+",
                    Language = "English",
                    Price = "₹450 onwards",
                    Status = ComingSoon,
                    Genre = "Superhero",
                    Duration = "2h 20m",
                    ImageUrl = "/images/Superman-poster.jpg",
                    Description = "Twelve years after saving his daughter Arya from a dark force, Atharva learns it never left her. When strange events begin again, he must fight to save her once more.",
                    TrailerUrl = "https://youtu.be/CtrOP7Ji55s",
                    ImdbRating = 8.0,
                    Director = "Rajesh Kumar",
                    Cast = "Vikram Sharma, Priya Patel, Rajesh Khanna",
                    IsBookingOpen = true,
                    HasSubtitles = true,
                    Languages = ["Telugu","Hindi","Tamil","Kannada"],
                    Formats = ["2D", "IMAX", "Dolby Atmos"],
                    LikeCount = 1250,
                    ReviewCount = 89,
                    ReleaseDate = "11 Jul 2025"
                },
                new()
                {
                    Id = 13,
                    Title = "The Fantastic Four: First Steps",
                    Rating = "UA13+",
                    Language = "English",
                    Price = "₹420 onwards",
                    Status = ComingSoon,
                    Genre = "Superhero",
                    Duration = "2h 15m",
                    ImageUrl = "/images/Fantastic-Four-poster.jpg",
                    Description = "Twelve years after saving his daughter Arya from a dark force, Atharva learns it never left her. When strange events begin again, he must fight to save her once more.",
                    TrailerUrl = "https://youtu.be/CtrOP7Ji55s",
                    ImdbRating = 8.0,
                    Director = "Rajesh Kumar",
                    Cast = "Vikram Sharma, Priya Patel, Rajesh Khanna",
                    IsBookingOpen = true,
                    HasSubtitles = true,
                    Languages = ["Telugu","Hindi","Tamil","Kannada"],
                    Formats = ["2D", "IMAX", "Dolby Atmos"],
                    LikeCount = 1250,
                    ReviewCount = 89,
                    ReleaseDate = "25 Jul 2025"
                },
                new()
                {
                    Id = 14,
                    Title = "Lilo & Stitch",
                    Rating = "U",
                    Language = "English",
                    Price = "₹280 onwards",
                    Status = PremieringThisWeek,
                    Genre = "Animation",
                    Duration = "1h 30m",
                    Description = "Twelve years after saving his daughter Arya from a dark force, Atharva learns it never left her. When strange events begin again, he must fight to save her once more.",
                    ImageUrl = "/images/Lilo&-Stitch-poster.jpg",
                    TrailerUrl = "https://youtu.be/CtrOP7Ji55s",
                    ImdbRating = 8.0,
                    Director = "Rajesh Kumar",
                    Cast = "Vikram Sharma, Priya Patel, Rajesh Khanna",
                    IsBookingOpen = true,
                    HasSubtitles = true,
                    Languages = ["Telugu","Hindi","Tamil","Kannada"],
                    Formats = ["2D", "IMAX", "Dolby Atmos"],
                    LikeCount = 1250,
                    ReviewCount = 89,
                    ReleaseDate = "23 May 2025"
                },
                new()
                {
                    Id = 15,
                    Title = "The Bad Guys 2",
                    Rating = "UA13+",
                    Language = "English",
                    Price = "₹300 onwards",
                    Status = ComingSoon,
                    Genre = "Animation",
                    Duration = "1h 40m",
                    Description = "Twelve years after saving his daughter Arya from a dark force, Atharva learns it never left her. When strange events begin again, he must fight to save her once more.",
                    ImageUrl = "/images/The-Bad-Guys-2-poster.jpg",
                    TrailerUrl = "https://youtu.be/CtrOP7Ji55s",
                    ImdbRating = 8.0,
                    Director = "Rajesh Kumar",
                    Cast = "Vikram Sharma, Priya Patel, Rajesh Khanna",
                    IsBookingOpen = true,
                    HasSubtitles = true,
                    Languages = ["Telugu","Hindi","Tamil","Kannada"],
                    Formats = ["2D", "IMAX", "Dolby Atmos"],
                    LikeCount = 1250,
                    ReviewCount = 89,
                    ReleaseDate = "01 Aug 2025"
                },
                new()
                {
                    Id = 16,
                    Title = "Jurassic World Rebirth",
                    Rating = "UA13+",
                    Language = "English",
                    Price = "₹380 onwards",
                    Status = NowShowing,
                    Genre = "Adventure",
                    Duration = "2h 18m",
                    Description = "Twelve years after saving his daughter Arya from a dark force, Atharva learns it never left her. When strange events begin again, he must fight to save her once more.",
                    ImageUrl = "/images/Jurassic-World-Rebirth-poster.jpg",
                    TrailerUrl = "https://youtu.be/CtrOP7Ji55s",
                    ImdbRating = 8.0,
                    Director = "Rajesh Kumar",
                    Cast = "Vikram Sharma, Priya Patel, Rajesh Khanna",
                    IsBookingOpen = true,
                    HasSubtitles = true,
                    Languages = ["Telugu","Hindi","Tamil","Kannada"],
                    Formats = ["2D", "IMAX", "Dolby Atmos"],
                    LikeCount = 1250,
                    ReviewCount = 89,
                    ReleaseDate = "02 Jul 2025"
                },
                new()
                {
                    Id = 17,
                    Title = "Mirai",
                    Rating = "UA13+",
                    Language = "Telugu",
                    Genre = "Sci-Fi, Action",
                    Price = "₹500 onwards",
                    Status = PremieringThisWeek,
                    Duration = "2h 49m",
                    Description="A warrior is tasked with the protection nine sacred scriptures that can turn any mortal into a deity.",
                    ImageUrl = "/images/mirai-poster.jpg",
                    TrailerUrl = "https://www.youtube.com/watch?v=3tP5XqHg3bM",
                    ImdbRating = 8.8,
                    Director = "Karthik Gattamneni, Anil Anand",
                    Cast = "Teja Sajja, Manoj Kumar Manchu, Ritika Nayak",
                    IsBookingOpen = true,
                    HasSubtitles = true,
                    Languages = ["Telugu", "Hindi"],
                    Formats = ["2D", "3D", "IMAX", "Dolby Atmos"],
                    LikeCount = 11780,
                    ReviewCount = 1325,
                    ReleaseDate = "20 Oct 2025"
                },
            };
            return allMovies;
        }

        private List<ShowtimeItem> GetMovieShowtimes(int movieId)
        {
            return new List<ShowtimeItem>
            {
                new ShowtimeItem { Id = 1, CinemaName = "PVR Elan Town Centre", Distance = "6.7 km", Times = new List<string> { "10:30 AM", "1:45 PM", "5:00 PM", "8:15 PM", "11:30 PM" }, AllowsCancellation = true },
                new ShowtimeItem { Id = 2, CinemaName = "INOX World Mark", Distance = "4.4 km", Times = new List<string> { "11:00 AM", "2:15 PM", "5:30 PM", "8:45 PM" }, AllowsCancellation = true },
                new ShowtimeItem { Id = 3, CinemaName = "Cinepolis Airia Mall", Distance = "6.9 km", Times = new List<string> { "10:15 AM", "1:30 PM", "4:45 PM", "8:00 PM", "11:15 PM" }, AllowsCancellation = false },
                new ShowtimeItem { Id = 4, CinemaName = "Wave Cinemas", Distance = "5.3 km", Times = new List<string> { "12:00 PM", "3:15 PM", "6:30 PM", "9:45 PM" }, AllowsCancellation = true }
            };
        }

        private List<MovieItem> GetSimilarMovies(string genre, int excludeId)
        {
            return GetAllRecentMovies()
                .Where(m => m.Genre.Contains(genre, StringComparison.OrdinalIgnoreCase) && m.Id != excludeId)
                .Take(4)
                .ToList();
        }

        // Existing methods for events and activities...
        private List<EventItem> GetUpcomingEvents()
        {
            return new List<EventItem>
            {
                new EventItem { Title = "Zamna India | Gurugram", Date = "Sat, 29 Nov, 5:00 PM", Venue = "Venue to be announced, Gurugram", Price = "₹3000 onwards", Category = "Music" },
                new EventItem { Title = "Rolling Loud India", Date = "22 Nov - 23 Nov, 3PM", Venue = "Loud Park, Kharghar, Mumbai", Price = "₹6000 onwards", Category = "Music Festival" },
                new EventItem { Title = "Sunburn Arena ft. Martin Garrix", Date = "15 Dec, 8:00 PM", Venue = "DLF CyberHub, Gurugram", Price = "₹4500 onwards", Category = "Electronic" },
                new EventItem { Title = "NH7 Weekender", Date = "3 Dec - 4 Dec, 4:00 PM", Venue = "Parade Grounds, Pune", Price = "₹2500 onwards", Category = "Music Festival" }
            };
        }

        private List<EventItem> GetMusicEvents()
        {
            return GetUpcomingEvents().Where(e => e.Category.Contains("Music")).ToList();
        }

        private List<EventItem> GetSportsEvents()
        {
            return new List<EventItem>
            {
                new EventItem { Title = "DPL 2025: Finals", Date = "Sun, 31 Aug, 7:00 PM", Venue = "Arun Jaitley Stadium, Delhi/NCR", Price = "₹299 onwards", Category = "Sports" },
                new EventItem { Title = "RDS Boxing Showdown", Date = "Sun, 28 Sep, 5:00 PM", Venue = "Titiksha Public School, Delhi/NCR", Price = "₹249 onwards", Category = "Sports" }
            };
        }

        private List<EventItem> GetComedyShows()
        {
            return new List<EventItem>
            {
                new EventItem { Title = "Comedy Non-Stop at Noida Sec 18", Date = "Daily, Multiple slots", Venue = "Comedy Club Sector 18 Noida, Noida", Price = "₹299 onwards", Category = "Comedy" },
                new EventItem { Title = "Late Night Comedy Show", Date = "Sat, 30 Aug – Sun, 31 Aug, 9:00 PM", Venue = "Owncomedyhouse, Noida", Price = "₹199", Category = "Comedy" }
            };
        }

        private List<ActivityItem> GetActivities()
        {
            return new List<ActivityItem>
            {
                new ActivityItem { Title = "Chokhi Dhani | Sonipat", Offer = "50% off up to ₹300", Time = "Daily, 6:00 PM onwards", Location = "Chokhi Dhani Sonipat, Haryana", Price = "₹700 onwards" },
                new ActivityItem { Title = "Splash Water World I Rohtak", Offer = "50% off up to ₹300", Time = "Every Sun, Fri & Sat, 10:00 AM to 6:00 PM", Location = "Splash Water World, Rohtak", Price = "₹600 onwards" },
                new ActivityItem { Title = "Just Chill Water Park", Offer = "50% off up to ₹300", Time = "Daily, 9:30 AM onwards", Location = "Just Chill Water Park, Delhi/NCR", Price = "₹500 onwards" },
                new ActivityItem { Title = "RTF Paragliding | Delhi NCR", Offer = "50% off up to ₹700", Time = "Daily, Multiple slots", Location = "Rush To Fly, Gurgaon", Price = "₹2500 onwards" }
            };
        }

        private List<ActivityItem> GetWaterParks()
        {
            return GetActivities().Where(a => a.Title.Contains("Water")).ToList();
        }

        private List<ActivityItem> GetAdventureActivities()
        {
            return GetActivities().Where(a => a.Title.Contains("Paragliding") || a.Title.Contains("Adventure")).ToList();
        }

        private List<ActivityItem> GetKidsActivities()
        {
            return new List<ActivityItem>
            {
                new ActivityItem { Title = "KIDZ FUNTALE: Kids Play Zone", Offer = "50% off up to ₹300", Time = "Daily, 11:00 AM onwards", Location = "Kidz Funtale South Delhi, Delhi/NCR", Price = "₹1100" },
                new ActivityItem { Title = "Little Joyz Play Area", Offer = "50% off up to ₹300", Time = "Daily, 10:00 AM onwards", Location = "Little JoyZ, Noida", Price = "₹600 onwards" }
            };
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
