using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CogentDemo.Code.DocumentTypes;

namespace CogentDemo.Code.Models.ViewModels
{
    public class ArticlesViewModel
    {
        public int UmbracoNodeId { get; set; }
        public Article Article { get; set; }
        public int ItemsToShow { get; set; }
        public List<ArticlePost> ArticlePosts { get; set; }
        public bool IsHalfWidth { get; set; }
        public bool HasPaging { get; set; }
    }
}