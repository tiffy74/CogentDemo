using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models.PublishedContent;
using CogentDemo.Code.Models;
using Umbraco.Web.Models;
using Umbraco.Core.Models;

namespace CogentDemo.Code.Extensions
{
    public static partial class CogentExtensions
    {
        /// <summary>
        /// Check if the IPublished Content has a value
        /// </summary>
        /// <param name="content">The current content</param>
        /// <returns>If a value is set</returns>
        public static bool HasValue(this IPublishedContent content)
        {
            return content != null;
        }

        public static bool HasValue(this Link content)
        {
            return content != null && content.Url != "";
        }

        public static bool HasValue(this IPublishedElement content)
        {
            return content != null;
        }
    }
}
