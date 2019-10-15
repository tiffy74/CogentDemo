using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Umbraco.Web;
using Umbraco.Web.WebApi;
using CogentDemo.Code.Models;

// Api url = /Umbraco/api/SpotlightApi/GetSpotlights

namespace CogentDemo.Code.Controllers
{
    [Route("api/[controller]")]
    public class SpotlightApiController : UmbracoApiController
    {
        [HttpGet]
        public List<Spotlight> GetSpotlights([FromUri] SpotlightApiRequestModel request)
        {
            var response = new List<Spotlight>();
            var _umbracoHelper = new UmbracoHelper(UmbracoContext.Current);

            var homeNode = _umbracoHelper.TypedContentAtRoot().FirstOrDefault();
            var articlesPage = homeNode.Children.Where(x => x.DocumentTypeAlias == "articles" && x.IsVisible()).FirstOrDefault();
            var articleList = articlesPage.Children.Where(x => x.IsVisible() && x.DocumentTypeAlias == "articlePost").OrderByDescending(x => x.GetPropertyValue<DateTime>("articleDate"));

            if (articleList != null)
            {
                // here you might add filtering from your request
                foreach (var contentNode in articlesPage.Descendants())
                {
                    response.Add(new Spotlight
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