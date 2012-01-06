﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers
{
    public class StoreController : Controller
    {
        //
        // GET: /Store/
        MusicStoreEntities storeDB = new MusicStoreEntities();

        public ActionResult Index()
        {
            var genres = storeDB.Genres.ToList();
            return View(genres);
    
        }
        //
        // GET: /Store/Browse
        public ActionResult Browse(string genre)
        {
            // Retrieve Genre and its Associated Albums from database
            var genreModel = storeDB.Genres.Include("Albums").Single(g => g.Name == genre);
            return View(genreModel);
        }
        //
        // GET: /Store/Details/5
        public ActionResult Details(int id)
        {
            var album = storeDB.Albums.Find(id);
            return View(album);
        }

    }
}
