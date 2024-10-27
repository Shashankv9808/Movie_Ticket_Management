using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Movie_Ticket_Management.DataAccess
{
    internal static class HomePageDataAccess
    {
        private readonly static string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["DatabaseConnectString"].ConnectionString;
        internal static List<HomePageDataInfo> GetMovieDataList()
        {
            List<HomePageDataInfo> all_movie_list = new List<HomePageDataInfo>();
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    using (SqlCommand command = new SqlCommand("spGetAllMovieDetails", connection))
                    {
                        connection.Open();
                        using (SqlDataReader rd = command.ExecuteReader())
                        {
                            while (rd.Read())
                            {
                                HomePageDataInfo info = new HomePageDataInfo()
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
    }
}