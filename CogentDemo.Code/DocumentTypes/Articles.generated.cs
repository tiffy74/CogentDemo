//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder v3.0.10.102
//
//   Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.ModelsBuilder;
using Umbraco.ModelsBuilder.Umbraco;

namespace CogentDemo.Code.DocumentTypes
{
	/// <summary>Articles</summary>
	[PublishedContentModel("articles")]
	public partial class Articles : Layout, IListingPageBase
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "articles";
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

		public Articles(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<Articles, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}

		///<summary>
		/// Title
		///</summary>
		[ImplementPropertyType("listTitle")]
		public string ListTitle
		{
			get { return this.GetPropertyValue<string>("listTitle"); }
		}

		///<summary>
		/// Items Per Row
		///</summary>
		[ImplementPropertyType("itemsPerRow")]
		public object ItemsPerRow
		{
			get { return CogentDemo.Code.DocumentTypes.ListingPageBase.GetItemsPerRow(this); }
		}
	}
}