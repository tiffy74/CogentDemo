using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Umbraco.Web;
using Umbraco.Web.WebApi;
using CogentDemo.Code.Models;

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

            if (homeNode != null)
            {
                // here you might add filtering from your request
                foreach (var contentNode in homeNode.Descendants())
                {
                    response.Add(new Spotlight
                    {
                        SpotlightName = contentNode.Name,
                        Id = contentNode.Id,
                        Url = contentNode.Url
                    });
                }
            }

            return response;
        }
    }
}