using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using Umbraco.Web;
using Umbraco.Web.Mvc;
using Umbraco.Web.WebApi;
using Umbraco.Web.Trees;
using Umbraco.Web.Models.Trees;
using System.Collections.Generic;
using System;
using umbraco.BusinessLogic.Actions;
using umbraco;
using System.Net.Http.Formatting;
using System.Linq;

namespace CogentDemo.Code.SurfaceControllers
{
    [Tree("content", "navigationAlias", "Navigation")]
    public class NavTreeController : TreeController
    {

        protected override TreeNodeCollection GetTreeNodes(string id, FormDataCollection queryStrings)
        {
                var umbracoHelper = new UmbracoHelper(UmbracoContext.Current);
                var pages = umbracoHelper.TypedContentAtRoot().First().Descendants().ToList();

                // create our node collection
                TreeNodeCollection nodes = new TreeNodeCollection();

                // loop through our favourite things and create a tree item for each one
                foreach (var page in pages)
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
            // create a Menu Item Collection to return so people can interact with the nodes in your tree
            var menu = new MenuItemCollection();

            //examine the node id, and only add these actions for some items
            if (!id.EndsWith(".md"))
            {
                menu.Items.Add<ActionNew>("Create");
                menu.Items.Add<ActionRefresh>("Reload Nodes");
            }

            //add these to all
            menu.Items.Add<ActionMove>("Rename");
            menu.Items.Add<ActionDelete>("Delete");

            return menu;
        }
    }
}
