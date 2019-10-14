using System.Collections.Generic;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using CogentDemo.Code.Models;
using System.Linq;
using System.Web.Configuration;
using System;
using CogentDemo.Code.DocumentTypes;
using Umbraco.Core.Models;

namespace CogentDemo.Code.Controllers
{
    class LoadMoreController : SurfaceController
    {

        public ActionResult Index()
        {
            List<LoadMoreModel> articles = GetAllArticles(0, 6);

            Session["NumberOfArticlesDisplayed"] = 6;

            return PartialView("~/Views/SpotLight.cshtml", articles);
        }

        public ActionResult GetMoreArticles()
        {

            var ArticlesToSkip = Convert.ToInt32(Session["NumberOfArticlesDisplayed"]);

            List<LoadMoreModel> articles = GetAllArticles(ArticlesToSkip, 6);

            Session["NumberOfArticlesDisplayed"] = ArticlesToSkip + 6;

            return PartialView("~/Views/SpotLights.cshtml", articles);
        }

        public List<LoadMoreModel> GetAllArticles(int ArticlesToSkip = 0, int ArticlesToReturn = 6)
        {

            var searchResults = Search.SearchArticles("#loadMore");


            List<LoadMoreModel> FetchArticles = new List<LoadMoreModel>();


            foreach (var ArticlePost in searchResults.Skip(ArticlesToSkip).Take(ArticlesToReturn))
            {
                FetchArticles.Add(new LoadMoreModel()
                {

                    string title = item.GetPropertyValue<string>("headerTitle");
                    string description = item.GetPropertyValue<string>("headerSubTitle");
                    var imageUrl = item.GetPropertyValue<IPublishedContent>("headerImage").Url;

            });


            };

            return FetchArticles;
        }


    }
}
