﻿using MyHomePage.DateBase;
using MyHomePage.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyHomePage.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var service = new NewsService();
            var viewList = service.GetList();
            ViewBag.NewsCount = viewList.Count();

            return View();
        }

        public ActionResult NewsList()
        {
            var service = new NewsService();
            var viewList = service.GetList();

            return PartialView("_NewsList", viewList);
        }

        [HttpGet]
        public ActionResult AddNews()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNews(News data)
        {
            if(data == null)
            {
                return View("Index");
            }

            var service = new NewsService();
            var viewList = service.Add(data);

            System.Threading.Thread.Sleep(1000);
            return View("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}