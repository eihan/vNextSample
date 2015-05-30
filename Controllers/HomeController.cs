using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Serilog;

using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;

using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private static ILogger _log;
        private static IMongoDatabase _mongoDB;
        public HomeController(ILogger log, IMongoDatabase mongoDB)
        {
            _log = log;
            _mongoDB = mongoDB;
        }
        
        public IActionResult Index()
        {
            _log.Information("Logging Test");
            _log.Warning("Logging Test");
            
            var tweets = _mongoDB.GetCollection<TweetModel>("tweets");
            
            var filter = new BsonDocument();
            
            var allTweets = tweets.Find(filter)
                .ToListAsync();
            allTweets.Wait();
            
            foreach(var tweet in allTweets.Result)
            {
                _log.Information("data: {@tweet}", tweet);    
            }
            
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}