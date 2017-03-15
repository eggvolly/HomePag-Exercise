using MyHomePage.DateBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyHomePage.Service
{
    public class ForumService
    {
        public List<ForumArticle> GetList()
        {
            try
            {
                HomePageEntities db = new HomePageEntities();

                var forumList = db.ForumArticle.OrderByDescending(x => x.CreateTime).ToList();
                if (forumList != null && forumList.Count() > 0)
                {
                    return forumList;
                }
            }
            catch
            {
                throw new ApplicationException();
            }

            return new List<ForumArticle>();

        }

        public void Add(ForumArticle data)
        {
            if (data == null)
            {
                return;
            }

            data.RecId = Guid.NewGuid();
            data.CreateTime = DateTime.Now;
            data.LikeCount = 0;
            data.UnlikeCount = 0;

            try
            {
                HomePageEntities db = new HomePageEntities();
                db.ForumArticle.Add(data);
                db.SaveChanges();
            }
            catch
            {
                throw new ApplicationException();
            }

        }

        public void AddCount(string recId, bool? isLike)
        {
            if(!isLike.HasValue || String.IsNullOrEmpty(recId))
            {
                return;
            }

            HomePageEntities db = new HomePageEntities();
            var entity = db.ForumArticle.Where(x => x.RecId.Equals(new Guid(recId))).FirstOrDefault();
            if(entity != null)
            {
                if(isLike.Value)
                {
                    entity.LikeCount = entity.LikeCount + 1;
                }
                else
                {
                    entity.UnlikeCount = entity.UnlikeCount + 1;
                }
                db.SaveChanges();
            }
            
        }
    }
}