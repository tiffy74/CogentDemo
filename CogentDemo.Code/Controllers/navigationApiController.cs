using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Umbraco.Web;
using Umbraco.Web.WebApi;
using CogentDemo.Code.Models;
using Umbraco.Web.Editors;

namespace CogentDemo.Code.SurfaceControllers
{
    [Route("api/[controller]")]
    public class NavigationApiController : UmbracoApiController
    {
        [HttpGet]
        public List<NavItem> GetNavItems([FromUri] NavigationApiRequestModel request)
        {
            var response = new List<NavItem>();
            var _umbracoHelper = new UmbracoHelper(UmbracoContext.Current);

            var homeNode = _umbracoHelper.TypedContentAtRoot().FirstOrDefault();

            if (homeNode != null)
            {
                // here you might add filtering from your request
                foreach (var contentNode in homeNode.Descendants())
                {
                    response.Add(new NavItem
                    {
                        NodeName = contentNode.Name
                    });
                }
            }

            return response;
        }
    }
}
