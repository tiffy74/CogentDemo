using Umbraco.Web.Mvc;
using System.Web.Mvc;
using CogentDemo.Code.Models;
using System.Collections.Generic;
using System;
using Umbraco.Core.Models;
using Umbraco.Web;
using System.Linq;

namespace CogentDemo.Code.Controllers
{
    class ArticleListController : SurfaceController
    {
        public ActionResult Index()
        {
            List<ArticleListModel> articles = GetAllArticles(0, 6);

            Session["NumberOfTweetsDisplayed"] = 6;

            return PartialView("~/Views/MoreArticles.cshtml", articles);
        }
        public ActionResult GetMoreArticles()
        {

            var articlesToSkip = Convert.ToInt32(Session["NumberOfArticlesDisplayed"]);

            List<ArticleListModel> articles = GetAllArticles(articlesToSkip, 6);

            Session["NumberOfArticlesDisplayed"] = articlesToSkip + 6;

            return PartialView("~/Views/articleFeed.cshtml", articles);
        }

        public List<ArticleListModel> GetAllArticles(int articlesToSkip = 0, int articlesToReturn = 6)
        {
            List<ArticleListModel> FetchArticles = new List<ArticleListModel>();

            IPublishedContent homePage = Umbraco.AssignedContentItem.AncestorOrSelf("home");
            IPublishedContent articles = homePage.Children.Where(x => x.DocumentTypeAlias == "articles" && x.IsVisible()).FirstOrDefault();
            IEnumerable<IPublishedContent> articleList = articles.Children.Where(x => x.IsVisible() && x.DocumentTypeAlias == "articlePost").OrderByDescending(x => x.GetPropertyValue<DateTime>("articleDate"));
            bool isHomePage = Umbraco.AssignedContentItem.Id == homePage.Id;
        }
    }
}
