using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Movie_Ticket_Management.DataAccess
{
    internal static class MovieDetailsDataAccess
    {
        private readonly static string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["DatabaseConnectString"].ConnectionString;
        internal static List<MovieTableInfos> GetMovieDataList()
        {
            List<MovieTableInfos> all_movie_list = new List<MovieTableInfos>();
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    using (SqlCommand command = new SqlCommand("spGetAllMovieDetails", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        using (SqlDataReader rd = command.ExecuteReader())
                        {
                            while (rd.Read())
                            {
                                MovieTableInfos info = new MovieTableInfos()
                                {
                                    MovieID = (int)rd.GetInt64(HomePageDataInfoFields.MovieID),
                                    MovieName = rd.GetString(HomePageDataInfoFields.MovieName),
                                    HeroName = rd.GetString(HomePageDataInfoFields.Hero),
                                    HeroinName = rd.GetString(HomePageDataInfoFields.Heroin),
                                    DirectorName = rd.GetString(HomePageDataInfoFields.Director),
                                    StoryWriterName = rd.GetString(HomePageDataInfoFields.Story),
                                    Genre = rd.GetString(HomePageDataInfoFields.Genre),
                                    Cost = rd.GetDecimal(HomePageDataInfoFields.Cost),
                                    Rating = rd.GetDecimal(HomePageDataInfoFields.Rating),
                                    Duration = rd.GetDecimal(HomePageDataInfoFields.Duration),
                                    ImageSize = rd.GetInt32(HomePageDataInfoFields.ImageSize),
                                    ImageData = Convert.ToBase64String((byte[])rd.GetSqlBinary(HomePageDataInfoFields.ImageData))
                                };
                                all_movie_list.Add(info);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string exception = ex.Message;
            }
            return all_movie_list;
        }
        internal static MovieTableInfos GetMovieDataByID(long movieID)
        {
            MovieTableInfos movie_data = new MovieTableInfos();
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    using (SqlCommand command = new SqlCommand("spGetMovieDetailsByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MovieID", movieID);
                        connection.Open();
                        using (SqlDataReader rd = command.ExecuteReader())
                        {
                            if (rd.Read())
                            {
                                movie_data.MovieID = (int)rd.GetInt64(HomePageDataInfoFields.MovieID);
                                movie_data.MovieName = rd.GetString(HomePageDataInfoFields.MovieName);
                                movie_data.HeroName = rd.GetString(HomePageDataInfoFields.Hero);
                                movie_data.HeroinName = rd.GetString(HomePageDataInfoFields.Heroin);
                                movie_data.DirectorName = rd.GetString(HomePageDataInfoFields.Director);
                                movie_data.StoryWriterName = rd.GetString(HomePageDataInfoFields.Story);
                                movie_data.Genre = rd.GetString(HomePageDataInfoFields.Genre);
                                movie_data.Cost = rd.GetDecimal(HomePageDataInfoFields.Cost);
                                movie_data.Rating = rd.GetDecimal(HomePageDataInfoFields.Rating);
                                movie_data.Duration = rd.GetDecimal(HomePageDataInfoFields.Duration);
                                movie_data.ImageSize = rd.GetInt32(HomePageDataInfoFields.ImageSize);
                                movie_data.ImageData = Convert.ToBase64String((byte[])rd.GetSqlBinary(HomePageDataInfoFields.ImageData));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string exception = ex.Message;
            }
            return movie_data;
        }
        internal static List<MovieSeatSatus> GetSeatStatusDataByMovieID(long movieID)
        {
            List<MovieSeatSatus> movie_seat_status_list = new List<MovieSeatSatus>();
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    using (SqlCommand command = new SqlCommand("spGetMovieSeatStatusDetails", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MovieID", movieID);
                        connection.Open();
                        using (SqlDataReader rd = command.ExecuteReader())
                        {
                            while (rd.Read())
                            {
                                MovieSeatSatus seat_status_data = new MovieSeatSatus
                                {
                                    SeatStatusID = rd.GetInt64(MovieSeatSatusDataInfoFields.SeatStatusID),
                                    MovieID = rd.GetInt64(MovieSeatSatusDataInfoFields.MovieID),
                                    s1 = rd.GetString(MovieSeatSatusDataInfoFields.s1),
                                    s2 = rd.GetString(MovieSeatSatusDataInfoFields.s2),
                                    s3 = rd.GetString(MovieSeatSatusDataInfoFields.s3),
                                    s4 = rd.GetString(MovieSeatSatusDataInfoFields.s4),
                                    s5 = rd.GetString(MovieSeatSatusDataInfoFields.s5),
                                    s6 = rd.GetString(MovieSeatSatusDataInfoFields.s6),
                                    s7 = rd.GetString(MovieSeatSatusDataInfoFields.s7),
                                    s8 = rd.GetString(MovieSeatSatusDataInfoFields.s8),
                                    s9 = rd.GetString(MovieSeatSatusDataInfoFields.s9),
                                    s10 = rd.GetString(MovieSeatSatusDataInfoFields.s10),
                                    s11 = rd.GetString(MovieSeatSatusDataInfoFields.s11),
                                    s12 = rd.GetString(MovieSeatSatusDataInfoFields.s12),
                                    s13 = rd.GetString(MovieSeatSatusDataInfoFields.s13),
                                    s14 = rd.GetString(MovieSeatSatusDataInfoFields.s14),
                                    s15 = rd.GetString(MovieSeatSatusDataInfoFields.s15),
                                    s16 = rd.GetString(MovieSeatSatusDataInfoFields.s16),
                                    s17 = rd.GetString(MovieSeatSatusDataInfoFields.s17),
                                    s18 = rd.GetString(MovieSeatSatusDataInfoFields.s18),
                                    s19 = rd.GetString(MovieSeatSatusDataInfoFields.s19),
                                    s20 = rd.GetString(MovieSeatSatusDataInfoFields.s20),
                                    s21 = rd.GetString(MovieSeatSatusDataInfoFields.s21),
                                    s22 = rd.GetString(MovieSeatSatusDataInfoFields.s22),
                                    s23 = rd.GetString(MovieSeatSatusDataInfoFields.s23),
                                    s24 = rd.GetString(MovieSeatSatusDataInfoFields.s24),
                                    s25 = rd.GetString(MovieSeatSatusDataInfoFields.s25),
                                    s26 = rd.GetString(MovieSeatSatusDataInfoFields.s26),
                                    s27 = rd.GetString(MovieSeatSatusDataInfoFields.s27),
                                    s28 = rd.GetString(MovieSeatSatusDataInfoFields.s28),
                                    s29 = rd.GetString(MovieSeatSatusDataInfoFields.s29),
                                    s30 = rd.GetString(MovieSeatSatusDataInfoFields.s30),
                                    MovieDateTime = rd.GetDateTime(MovieSeatSatusDataInfoFields.MovieDateTime)
                                };
                                movie_seat_status_list.Add(seat_status_data);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string exception = ex.Message;
            }
            return movie_seat_status_list;
        }
    }
}