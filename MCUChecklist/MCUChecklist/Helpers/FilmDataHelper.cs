using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using MCUChecklist.Models;

namespace MCUChecklist.Helpers
{
    public class FilmDataHelper
    {
        public static List<Film> GetFilms()
        {
            List<Film> films = new List<Film>();

            string connString = ConfigurationManager.AppSettings["SqlConnectionString"];

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["SqlConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand("MCUCAdmin.GetFilms", conn))
                {
                    conn.Open();

                    using(SqlDataReader rdr = command.ExecuteReader())
                    {
                        while(rdr.Read())
                        {
                            films.Add(new Film()
                            {
                                FilmID = Convert.ToInt32(rdr["FilmID"]),
                                FilmName = (string)rdr["FilmName"],
                                FilmRelease = (string)rdr["FilmRelease"],
                                FilmLength = (string)rdr["FilmLength"],
                                FilmRating = (string)rdr["FilmRating"],
                                FilmDirector = (string)rdr["FilmDirector"],
                                FilmCast = (string)rdr["FilmCast"],
                                FilmWatchOrder = (rdr["FilmWatchOrder"] as int?).GetValueOrDefault(),
                                FilmSynopsis = (string)rdr["FilmSynopsis"],
                                IsSeries = rdr.GetBoolean(rdr.GetOrdinal("IsSeries")),
                                SeriesCount = (rdr["SeriesCount"] as int?).GetValueOrDefault(),
                                SeriesNumber = (rdr["SeriesNumber"] as int?).GetValueOrDefault(),
                                EpisodeCount = (rdr["EpisodeCount"] as int?).GetValueOrDefault()
                            });
                        }
                    }
                }

                return films;
            }
        }
    }
}