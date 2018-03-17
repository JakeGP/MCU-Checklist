using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MCUChecklist.Models;

namespace MCUChecklist.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Film> films = new List<Film>();

            string[] FilmNames = new string[] {
                "Iron Man",
                "The Incredible Hulk",
                "Iron Man 2",
                "Captain America: The First Avenger",
                "Thor",
                "The Avengers",
                "Iron Man 3",
                "Thor: The Dark World",
                "Captain America: The Winter Soldier",
                "Guardians of the Galaxy",
                "Avengers: Age of Ultron",
                "Ant-Man",
                "Captain America: Civil War",
                "Doctor Strange",
                "Guardians of the Galaxy 2",
                "Spider-Man: Homecoming",
                "Thor: Ragnarok",
                "Black Panther",
                "Avengers: Infinity War - Part I",
                "Ant-Man & the Wasp",
                "Captain Marvel",
                "Avengers: Infinity War - Part II",
            };

            string[] FilmUrls = new string[] {
                "http://www.duelinggenre.com/wp-content/uploads/2018/01/1-Iron-Man.jpg",
                "https://www.scifibloggers.com/wp-content/uploads/hulk-poster-e1427561166143.png",
                "http://cdn.collider.com/wp-content/image-base/Movies/I/Iron_Man_2/Slices/slice_iron_man_2_poster_cast_01.jpg",
                "http://comicsalliance.com/files/2011/07/finalcapposter.jpeg?w=980&q=75",
                "https://natashastander.files.wordpress.com/2013/11/thor-dark-world.jpg",
                "http://www.moviesonline.ca/wp-content/uploads/2011/10/avengers-590x309.png",
                "http://cdn1us.denofgeek.com/sites/denofgeekus/files/styles/main_wide/public/iron_man_3_tony_stark_and_pepper_potts-wallpaper-1600x900.jpg?itok=QZWUnLUL",
                "http://i0.wp.com/geektasticpodcast.com/wp-content/uploads/2013/11/thor-2-poster-2.jpg?resize=630%2C420",
                "https://i2.wp.com/thesefantasticworlds.com/wp-content/uploads/2014/03/captain-america-winter-soldier-poster-wide1.jpg?fit=758%2C474&ssl=1",
                "https://cdn.movieweb.com/img.news.tops/NExlPJRum1w0AE_1_b/Guardians-Of-Galaxy-2-China-Release-Date-Poster.jpg",
                "https://cdn1.thr.com/sites/default/files/2015/02/avengers_age_of_ultron_poster_detail.jpg",
                "http://cdn-static.denofgeek.com/sites/denofgeek/files/styles/main_wide/public/9/83//ant-man_lead.jpg?itok=0m1hhdek",
                "http://digitalspyuk.cdnds.net/17/27/980x490/landscape-1499442342-captain-america-civil-war-fight-poster.jpg",
                "http://cardiffstudentmedia.co.uk/quench/wp-content/uploads/sites/3/2016/11/doctor-strange-1366x768-marvel-2016-movies-101.jpg",
                "https://fm.cnbc.com/applications/cnbc.com/resources/img/editorial/2017/04/28/104436095-guardians-of-the-galaxy-vol-2-1366x768-guardians-of-the-galaxy-vol-2-6474.530x298.jpg?v=1493410734",
                "http://thoimoi.vn/stores/news_dataimages/vietlinh/022018/19/16/marvel-tung-suyt-mat-ban-quyen-tat-ca-sieu-anh-hung-vao-tay-sony-03-.1604.jpg",
                "https://www.sbs.com.au/popasia/sites/sbs.com.au.popasia/files/styles/full/public/thor_feat.jpg?itok=5YtZrpEa&mtime=1505957134",
                "http://static-26.sinclairstoryline.com/resources/media/d814c068-00e2-4fe5-906c-2affc0c3dbfd-large16x9_BlackPanther.jpg?1518198700251",
                "https://heroichollywood.b-cdn.net/wp-content/uploads/2018/03/Avengers-Infinity-War-1.jpg?x42694",
                "https://screenrant.com/wp-content/uploads/2017/07/Ant-Man-and-the-Wasp-Comic-Con-Poster-Cropped.jpeg",
                "https://d13ezvd6yrslxm.cloudfront.net/wp/wp-content/images/captainmarvel-infinitywar-promoposter-fanmade-frontpage-700x344.jpg",
                "https://i2.wp.com/cromossomonerd.com.br/wp-content/uploads/2018/01/vingadores-guerra-infinita.jpg?resize=1068%2C601&ssl=1",
            };

            bool[] FilmLiked = new bool[]
            {
                true,
                false,
                false,
                false,
                true,
                true,
                false,
                false,
                false,
                false,
                true,
                true,
                false,
                false,
                false,
                true,
                true,
                true,
                false,
                false,
                false,
                true
            };

            bool[] FilmWatched = new bool[] {
                false,
                false,
                false,
                false,
                true,
                true,
                false,
                false,
                false,
                true,
                true,
                true,
                false,
                false,
                false,
                true,
                true,
                false,
                false,
                false,
                true,
                true
            };

            for (int i = 0; i < FilmNames.Length; i ++)
            {
                Film newFilm = new Film();
                newFilm.FilmName = FilmNames[i];
                newFilm.FilmImageUrl = FilmUrls[i];
                newFilm.FilmLiked = FilmLiked[i];
                newFilm.FilmWatched = FilmWatched[i];
                films.Add(newFilm);
            }

            return View(new TilesModel() { Films = films });
        }
    }
}