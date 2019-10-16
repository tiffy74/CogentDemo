using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CogentDemo.Code.DocumentTypes;

namespace CogentDemo.Code.Models
{
    class ArticleListModel
    {
        public int UmbracoNodeId { get; set; }
        public Article Article { get; set; }
        public int ItemsToShow { get; set; }
        public int NumberOfArticles { get; set; }
        public List<ArticlePost> ArticlePosts { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Image { get; set; }
        public string Url { get; set; }
    }
}
