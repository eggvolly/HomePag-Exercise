using MyHomePage.DateBase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyHomePage.Service
{
    public class NewsService
    {
        public News Get(string id)
        {
            HomePageEntities db = new HomePageEntities();

            var newsEntity = db.News.Where(x => x.RecId.Equals(Guid.Parse(id))).FirstOrDefault();
            if(newsEntity != null)
            {
                return newsEntity;
            }
            else
            {
                throw new ApplicationException();
            }
        }


        public List<News> GetList()
        {
            HomePageEntities db = new HomePageEntities();

            var newsList = db.News.OrderByDescending(x=>x.CreateTime).ToList();
            if (newsList != null && newsList.Count > 0)
            {
                return newsList;
            }
            else
            {
                throw new ApplicationException();
            }
        }

        public bool Add(News data)
        {
            if(data == null)
            {
                return false;
            }

            data.RecId = Guid.NewGuid();
            data.CreateTime = DateTime.Now;
            try
            {
                HomePageEntities db = new HomePageEntities();
                db.News.Add(data);
                db.SaveChanges();

                return true;
            }
            catch
            {
                throw;
            }

        }
    }
}