using System.Web.Http;
using System.Net.Http.Formatting;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using Umbraco.Web;
using Umbraco.Web.Mvc;
using Umbraco.Web.WebApi;
using Umbraco.Web.Trees;
using Umbraco.Web.Models.Trees;
using umbraco.BusinessLogic.Actions;
using System.Linq;
using System.Web.Mvc;
using CogentDemo.Code.Models;
using System.Collections.Generic;

namespace CogentDemo.Code.SurfaceControllers
{

    public class NavigationSurfaceController : SurfaceController
    {
        private const string Partial_Views_Path = "Views/Partials/Navigation/";
        public ActionResult RenderHeader()
        {
            return PartialView(string.Format("{0}NavSection.cshtml", Partial_Views_Path));
        }

        public List<NavigationList> GetNavigationModel()
        {
            int pageId = int.Parse(CurrentPage.Path.Split(',')[1]);
            IPublishedContent pageInfo = Umbraco.Content(pageId);
            var nav = new MenuItemList<NavigationList>
            {
                new NavigationList(new NavigationLinkInfo(pageInfo.Url, pageInfo.Name))
            };

            return nav;
        }

        public List<NavigationList> GetSubNavigationList(dynamic page)
        {
            List<NavigationList> navList = null;
            var subPages = page.Children.Where("Visible");
            if (subPages != null && subPages.Any() && subPages.Count() > 0)
            {
                navList = new List<NavigationList>
                foreach (var subPage in subPages) ; NavItems = GetSubNavigationList(subPage);
            }
        }

    }

            //check if we're rendering the root node's children
            
}
