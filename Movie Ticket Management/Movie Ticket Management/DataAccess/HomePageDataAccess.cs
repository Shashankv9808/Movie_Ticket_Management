using AjaxControlToolkit;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

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
                    using (SqlCommand command = new SqlCommand("SELECT ID,Name,hero,heroin,director,story,gener,cost,rating,duration FROM movielist", connection))
                    {
                        connection.Open();
                        using (SqlDataReader rd = command.ExecuteReader())
                        {
                            while (rd.Read())
                            {
                                HomePageDataInfo info = new HomePageDataInfo()
                                {
                                    MovieID = (int)rd.GetDecimal(HomePageDataInfoFields.MovieID),
                                    MovieName = rd.GetString(HomePageDataInfoFields.MovieName),
                                    HeroName = rd.GetString(HomePageDataInfoFields.Hero),
                                    HeroinName = rd.GetString(HomePageDataInfoFields.Heroin),
                                    Director = rd.GetString(HomePageDataInfoFields.Director),
                                    Story = rd.GetString(HomePageDataInfoFields.Story),
                                    Genre = rd.GetString(HomePageDataInfoFields.Genre),
                                    Cost = rd.GetString(HomePageDataInfoFields.Cost),
                                    Rating = rd.GetDecimal(HomePageDataInfoFields.Rating),
                                    Duration = rd.GetDecimal(HomePageDataInfoFields.Duration)
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