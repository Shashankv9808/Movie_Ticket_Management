namespace BangloreTalkies.Models
{
    public class HomePageViewModel
    {
        public List<MovieItem> FeaturedMovies { get; set; } = new List<MovieItem>();
        public List<EventItem> UpcomingEvents { get; set; } = new List<EventItem>();
        public List<ActivityItem> Activities { get; set; } = new List<ActivityItem>();
        public List<MovieItem> EnglishMovies { get; set; } = new List<MovieItem>();

    }

    public class MoviesViewModel
    {
        public List<MovieItem> HindiMovies { get; set; } = new List<MovieItem>();
        public List<MovieItem> EnglishMovies { get; set; } = new List<MovieItem>();
        public List<MovieItem> RegionalMovies { get; set; } = new List<MovieItem>();
        public List<MovieItem> PremieringThisWeek { get; set; } = new List<MovieItem>();
        public List<MovieItem> NowShowing { get; set; } = new List<MovieItem>();
        public List<MovieItem> ComingSoon { get; set; } = new List<MovieItem>();
        public List<MovieItem> HeroMovies { get; set; } = new List<MovieItem>();
    }

    public class MovieDetailsViewModel
    {
        public MovieItem Movie { get; set; } = new MovieItem();
        public List<ShowtimeItem> Showtimes { get; set; } = new List<ShowtimeItem>();
        public List<MovieItem> SimilarMovies { get; set; } = new List<MovieItem>();
    }

    public class EventsViewModel
    {
        public List<EventItem> MusicEvents { get; set; } = new List<EventItem>();
        public List<EventItem> SportsEvents { get; set; } = new List<EventItem>();
        public List<EventItem> ComedyShows { get; set; } = new List<EventItem>();
    }

    public class ActivitiesViewModel
    {
        public List<ActivityItem> WaterParks { get; set; } = new List<ActivityItem>();
        public List<ActivityItem> AdventureActivities { get; set; } = new List<ActivityItem>();
        public List<ActivityItem> KidsActivities { get; set; } = new List<ActivityItem>();
    }

    public class MovieItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Rating { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = "/images/placeholder-movie.jpg";
        public string Genre { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
        public string ReleaseDate { get; set; } = string.Empty;
        public string Director { get; set; } = string.Empty;
        public string Cast { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string TrailerUrl { get; set; } = string.Empty;
        public double ImdbRating { get; set; } = 0;
        public bool IsLiked { get; set; } = false;
        public double Distance { get; set; } = 0;
        public string Location { get; set; } = string.Empty;
        public List<string> Languages { get; set; } = new List<string>();
        public List<string> Formats { get; set; } = new List<string>();
        public bool IsBookingOpen { get; set; } = true;
        public bool HasSubtitles { get; set; } = false;
        public int LikeCount { get; set; } = 0;
        public int ReviewCount { get; set; } = 0;
    }

    public class ShowtimeItem
    {
        public int Id { get; set; }
        public string CinemaName { get; set; } = string.Empty;
        public string Distance { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public List<string> Times { get; set; } = new List<string>();
        public List<string> Formats { get; set; } = new List<string>();
        public bool AllowsCancellation { get; set; } = false;
        public bool HasFoodAndBeverage { get; set; } = false;
        public string Amenities { get; set; } = string.Empty;
        public Dictionary<string, decimal> PriceByFormat { get; set; } = new Dictionary<string, decimal>();
    }

    public class EventItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public string Venue { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = "/images/placeholder-event.jpg";
        public string Description { get; set; } = string.Empty;
        public bool IsLiked { get; set; } = false;
        public double Distance { get; set; } = 0;
        public string Offer { get; set; } = string.Empty;
        public bool IsFeatured { get; set; } = false;
        public string Artist { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
        public string AgeRestriction { get; set; } = string.Empty;
        public bool AllowsCancellation { get; set; } = true;
        public int LikeCount { get; set; } = 0;
        public int InterestedCount { get; set; } = 0;
    }

    public class ActivityItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Offer { get; set; } = string.Empty;
        public string Time { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = "/images/placeholder-activity.jpg";
        public string Category { get; set; } = string.Empty;
        public bool IsLiked { get; set; } = false;
        public double Distance { get; set; } = 0;
        public string Description { get; set; } = string.Empty;
        public bool HasDiscount { get; set; } = false;
        public string Duration { get; set; } = string.Empty;
        public string AgeGroup { get; set; } = string.Empty;
        public bool RequiresBooking { get; set; } = true;
        public string Amenities { get; set; } = string.Empty;
        public int LikeCount { get; set; } = 0;
        public double Rating { get; set; } = 0;
        public int ReviewCount { get; set; } = 0;
    }

    public class SearchResultsViewModel
    {
        public string Query { get; set; } = string.Empty;
        public string Category { get; set; } = "all";
        public List<MovieItem> Movies { get; set; } = new List<MovieItem>();
        public List<EventItem> Events { get; set; } = new List<EventItem>();
        public List<ActivityItem> Activities { get; set; } = new List<ActivityItem>();
        public int TotalResults { get; set; }
        public string Location { get; set; } = string.Empty;
        public Dictionary<string, int> CategoryCounts { get; set; } = new Dictionary<string, int>();
    }

    // Filter and sorting models
    public class MovieFilters
    {
        public List<string> Languages { get; set; } = new List<string>();
        public List<string> Genres { get; set; } = new List<string>();
        public List<string> Formats { get; set; } = new List<string>();
        public List<string> Ratings { get; set; } = new List<string>();
        public string SortBy { get; set; } = "popularity"; // popularity, price, rating, release_date
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }

    public class EventFilters
    {
        public List<string> Categories { get; set; } = new List<string>();
        public List<string> Venues { get; set; } = new List<string>();
        public string SortBy { get; set; } = "date"; // date, price, popularity
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public bool OnlyWithOffers { get; set; } = false;
    }

    public class ActivityFilters
    {
        public List<string> Categories { get; set; } = new List<string>();
        public List<string> AgeGroups { get; set; } = new List<string>();
        public string SortBy { get; set; } = "popularity"; // popularity, price, rating, distance
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public bool OnlyWithOffers { get; set; } = false;
        public bool OnlyHighRated { get; set; } = false;
    }

    // Booking related models
    public class BookingRequest
    {
        public int MovieId { get; set; }
        public int ShowtimeId { get; set; }
        public int CinemaId { get; set; }
        public string ShowTime { get; set; } = string.Empty;
        public DateTime ShowDate { get; set; }
        public List<string> SelectedSeats { get; set; } = new List<string>();
        public string Format { get; set; } = "2D";
        public decimal TotalAmount { get; set; }
    }

    public class NotificationRequest
    {
        public int ItemId { get; set; }
        public string ItemType { get; set; } = string.Empty; // movie, event, activity
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public bool EmailNotification { get; set; } = true;
        public bool SmsNotification { get; set; } = false;
    }

    // API Response models
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T Data { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
    }

    public class PaginatedResult<T>
    {
        public List<T> Items { get; set; } = new List<T>();
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
    }

    // User preferences and settings
    public class UserPreferences
    {
        public string PreferredLocation { get; set; } = string.Empty;
        public List<string> PreferredLanguages { get; set; } = new List<string>();
        public List<string> PreferredGenres { get; set; } = new List<string>();
        public List<string> PreferredFormats { get; set; } = new List<string>();
        public bool EmailNotifications { get; set; } = true;
        public bool SmsNotifications { get; set; } = false;
        public bool PushNotifications { get; set; } = true;
        public string Theme { get; set; } = "light"; // light, dark, auto
        public List<int> LikedMovies { get; set; } = new List<int>();
        public List<int> LikedEvents { get; set; } = new List<int>();
        public List<int> LikedActivities { get; set; } = new List<int>();
    }

    // Hero Slider specific models
    public class HeroSliderSettings
    {
        public bool AutoPlay { get; set; } = true;
        public int AutoPlayInterval { get; set; } = 6000; // milliseconds
        public bool ShowArrows { get; set; } = true;
        public bool ShowDots { get; set; } = true;
        public bool EnableSwipe { get; set; } = true;
        public bool EnableKeyboard { get; set; } = true;
        public bool PauseOnHover { get; set; } = true;
        public int TransitionDuration { get; set; } = 600; // milliseconds
        public string TransitionEffect { get; set; } = "slide"; // slide, fade
    }
}