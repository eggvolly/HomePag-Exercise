using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHomePage.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyHomePage.DateBase;
namespace MyHomePage.Service.Tests
{
    [TestClass()]
    public class NewsServiceTests
    {
        [TestMethod()]
        public void AddTest()
        {
            News data = new News();
            data.Title = "Toshiba shares slide on renewed earnings delay";
            data.Content = "The extension still needs regulatory approval. Failure to obtain that will mean Toshiba has to submit earnings by 27 March or face delisting from the stock exchange.";

            var target = new NewsService();
            Assert.IsTrue(target.Add(data));
        }
    }
}
