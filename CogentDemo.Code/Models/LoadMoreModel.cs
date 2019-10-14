using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CogentDemo.Code.DocumentTypes;

namespace CogentDemo.Code.Models
{
    public class LoadMoreModel
    {
        public int UmbracoNodeId { get; set; }
        public Article Article { get; set; }
        public int ItemsToShow { get; set; }
        public DateTime ArticleDate { get; set; }
        public string Url { get; set; }

    }
}
