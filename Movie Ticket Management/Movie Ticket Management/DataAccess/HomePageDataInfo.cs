using System;

namespace Movie_Ticket_Management.DataAccess
{
    public class HomePageDataInfo
    {
        public Int64 MovieID { get; set; }
        public string MovieName { get; set; }
        public string HeroName { get; set; }
        public string HeroinName { get; set; }
        public string DirectorName { get; set; }
        public string StoryWriterName { get; set; }
        public string Genre { get; set; }
        public decimal Cost { get; set; }
        public decimal Rating { get; set; }
        public decimal Duration { get; set; }
        public int ImageSize { get; set; }
        public string ImageData { get; set; }
    }
    public struct HomePageDataInfoFields
    {
        public const int MovieID = 0;
        public const int MovieName = 1;
        public const int Hero = 2;
        public const int Heroin = 3;
        public const int Director = 4;
        public const int Story = 5;
        public const int Genre = 6;
        public const int Cost = 7;
        public const int Rating = 8;
        public const int Duration = 9;
        public const int ImageSize = 10;
        public const int ImageData = 11;
    }
}