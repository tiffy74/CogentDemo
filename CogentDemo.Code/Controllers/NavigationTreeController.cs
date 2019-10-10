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

using System.Net.Http.Formatting;


namespace CogentDemo.Code.Controllers
{
    [Tree("Navigation", "navigationTree", "Create Navigation")]
    [PluginController("Navigation")]
    public class ApprovalTreeController : TreeController
    {
        protected override TreeNodeCollection GetTreeNodes(string id, FormDataCollection queryStrings)
        {
            

            //check if we're rendering the root node's children
            var umbracoHelper = new UmbracoHelper(UmbracoContext.Current);
            var pages = umbracoHelper.TypedContentAtRoot().First().Descendants().ToList();

            // create our node collection
            TreeNodeCollection nodes = new TreeNodeCollection();
            var ctrl = new NavigationApiController();

            // loop through our favourite things and create a tree item for each one
            foreach (var page in ctrl)
            {
                // add each node to the tree collection using the base CreateTreeNode method
                // it has several overloads, using here unique Id of tree item, -1 is the Id of the parent node to create, eg the root of this tree is -1 by convention - the querystring collection passed into this route - the name of the tree node -  css class of icon to display for the node - and whether the item has child nodes
                var node = CreateTreeNode(page.ToString(), "-1", queryStrings, page.Name, "icon-presentation", false, "Navigation");
                nodes.Add(node);

            }
            return nodes;
        }

        protected override MenuItemCollection GetMenuForNode(string id, FormDataCollection queryStrings)
        {
            var menu = new MenuItemCollection();

            if (id == Constants.System.Root.ToInvariantString())
            {
                // root actions
                menu.Items.Add<RefreshNode, ActionRefresh>(
                    ApplicationContext.Services.TextService.Localize(ActionRefresh.Instance.Alias));
            }

            return menu;
        }
    }
}
