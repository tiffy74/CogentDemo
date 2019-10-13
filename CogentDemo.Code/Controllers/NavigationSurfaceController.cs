using Umbraco.Core.Models;
using Umbraco.Web.Mvc;
using System.Web.Mvc;
using CogentDemo.Code.Models;
using System.Collections.Generic;

namespace CogentDemo.Code.Controllers
{

    public class NavigationSurfaceController : SurfaceController
    {
        public const string PARTIAL_VIEW_FOLDER = "~/Views/Partials/Navigation/";

        public ActionResult RenderSiteNavigation()
        {
            List<NavigationList> nav = GetNavigationModel();
            return PartialView(string.Format("{0}SiteNavigation.cshtml", PARTIAL_VIEW_FOLDER), nav);
        }

        public List<NavigationList> GetNavigationModel()
        {
            int pageId = int.Parse(CurrentPage.Path.Split(',')[1]);
            IPublishedContent pageInfo = Umbraco.Content(pageId);
            var nav = new List <NavigationList>
            {
                new NavigationList(new NavigationLinkInfo(pageInfo.Url, pageInfo.Name))
            };
            nav.AddRange(GetSubNavigationList(pageInfo));
            return nav;
        }

        public List<NavigationList> GetSubNavigationList(dynamic page)
        {
            List<NavigationList> navList = null;
            var subPages = page.Children.Where("Visible");
            if (subPages != null && subPages.Any() && subPages.Count() > 0)
            {
                navList = new List<NavigationList>();
                foreach (var subPage in subPages)
                {
                    var listItem = new NavigationList(new NavigationLinkInfo(subPage.Url, subPage.Name))
                    {
                        NavItems = GetSubNavigationList(subPage)
                    };
                navList.Add(listItem);
                }
            }
        return navList;
        }
    }
}
            
