using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMusicStore.Models;
using System.Collections;
using PagedList;
using PagedList.Mvc;


namespace MvcMusicStore.Controllers
{
    public abstract class MyBaseController : Controller
    {
        public abstract string Name { get; }
    }

    public class StoreController : MyBaseController
    {
        public static string namegen="212121";
        MusicStoreEntities storeDB = new MusicStoreEntities();
        //
        // GET: /Store/
        public override string Name { get { return "Store"; } }
        public ActionResult Index()
        {
            ViewBag.name = Name;
        var genres = storeDB.Genres.ToList();
       
            /*var genres = new List<Genre>{
                new Genre{ Name ="Diso"},
                new Genre{ Name ="Jazz"},
                new Genre{ Name ="Rock"}
            };*/
            return View(genres);
        }
        public ActionResult Browse(string genre, int? page)
        {   // Retrieve Genre and its Associated Albums from database
            ViewBag.name = Name;
            var genreModel = storeDB.Genres.Include("Albums").Single(g => g.Name == genre).Albums.ToList()
                .OrderByDescending(m => m.AlbumId).ToPagedList(page ?? 1, 20);
            
            string k = genre;
            namegen = k;
            ViewBag.genre = genre;
            
                return View(genreModel);
        }
        public ActionResult Details(int id)
        {
            ViewBag.name = Name;
            var album = storeDB.Albums.Find(id);

            return View(album);          
        }
        //
        // GET: /Store/GenreMenu
        [ChildActionOnly]
        public ActionResult GenreMenu()
        {   
            var genres = storeDB.Genres.ToList();
            ViewData["key"] = namegen;
            return PartialView(genres);
        }
	}
}