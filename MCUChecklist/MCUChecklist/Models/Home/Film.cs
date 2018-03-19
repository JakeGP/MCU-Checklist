using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCUChecklist.Models
{
    public class Film
    {
        public int FilmID { get; set; }
        public string FilmName { get; set; }
        public string FilmRelease { get; set; }
        public string FilmLength { get; set; }
        public string FilmRating { get; set; }
        public string FilmDirector { get; set; }
        public string FilmCast { get; set; }
        public int FilmWatchOrder { get; set; }
        public string FilmSynopsis { get; set; }


        public bool IsSeries { get; set; }
        public int? SeriesCount { get; set; }
        public int? SeriesNumber { get; set; }
        public int? EpisodeCount { get; set; }


        public string FilmImageUrl { get; set; }
        public bool FilmLiked { get; set; }
        public bool FilmWatched { get; set; }
    }
}