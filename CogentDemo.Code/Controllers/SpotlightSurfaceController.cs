using System.Collections.Generic;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using CogentDemo.Code.Models;

using System.Linq;
using System.Web.Configuration;
using System;
using Umbraco.Web;

namespace CogentDemo.Code.Controllers
{
    public class SpotlightSurfaceController : SurfaceController
    {
        public const string PARTIAL_VIEW_FOLDER = "~/Views/Shared/";
        public ActionResult RenderSpotlights()
        {
            List<LoadMoreModel> Spotlights = GetAllSpots(0, 6);
            Session["NumberOfLightsDisplayed"] = 6;
            return PartialView(PARTIAL_VIEW_FOLDER + "RenderSpotlights.cshtml", Spotlights);
        }

        public ActionResult RenderMoreSpotlights()
        {
            var lightsToSkip = Convert.ToInt32(Session["NumberOfLightsDisplayed"]);
            List<LoadMoreModel> Spotlights = GetAllSpots(lightsToSkip, 6);
            Session["NumberOfLightsDisplayed"] = lightsToSkip +6;
            return PartialView(PARTIAL_VIEW_FOLDER + "ArticleItemList.cshtml", Spotlights);
        }

        public List<LoadMoreModel> GetAllSpots(int lightsToSkip = 0, int lightsToReturn = 6)
        {
            var response = new List<LoadMoreModel>();
            var _umbracoHelper = new UmbracoHelper(UmbracoContext.Current);

            var homeNode = _umbracoHelper.TypedContentAtRoot().FirstOrDefault();
            var articlesPage = homeNode.Children.Where(x => x.DocumentTypeAlias == "articles" && x.IsVisible()).FirstOrDefault();
            var articleList = articlesPage.Children.Where(x => x.IsVisible() && x.DocumentTypeAlias == "articlePost").OrderByDescending(x => x.GetPropertyValue<DateTime>("articleDate"));

            if (articleList != null)
            {
                // here you might add filtering from your request
                foreach (var contentNode in articlesPage.Descendants().Skip(lightsToSkip).Take(lightsToReturn))
                {
                    response.Add(new LoadMoreModel
                    {
                        SpotlightName = contentNode.Name,
                        Id = contentNode.Id,
                        Url = contentNode.Url,
                        SpotlightHeading = contentNode.HasValue("headerTitle") ? contentNode.GetPropertyValue<string>("headerTitle") : contentNode.Name,
                        SpotlightText = contentNode.HasValue("headerSubTitle") ? contentNode.GetPropertyValue<string>("headerSubTitle") : contentNode.Name,
                        ImageUrl = contentNode.HasValue("headerImage") ? contentNode.GetPropertyValue<string>("headerImage") : contentNode.Url
                    }
                    );
                }
            }
            return response;
        }
    }
}
