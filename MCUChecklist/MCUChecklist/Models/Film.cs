using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCUChecklist.Models
{
    public class Film
    {
        public string FilmName { get; set; }
        public string FilmYear { get; set; }
        public string FilmImageUrl { get; set; }
        public bool FilmLiked { get; set; }
        public bool FilmWatched { get; set; }
    }
}