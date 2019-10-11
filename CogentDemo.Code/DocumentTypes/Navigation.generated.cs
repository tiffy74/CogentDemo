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
	// Mixin content Type 1343 with alias "navigation"
	/// <summary>Navigation</summary>
	public partial interface INavigation : IPublishedContent
	{
		/// <summary>Brand Link</summary>
		Umbraco.Web.Models.Link BrandLink { get; }

		/// <summary>Brand Logo</summary>
		IPublishedContent BrandLogo { get; }

		/// <summary>Main Navigation</summary>
		IEnumerable<Umbraco.Web.Models.Link> MainNavigation { get; }

		/// <summary>siteTitle</summary>
		string SiteTitle { get; }
	}

	/// <summary>Navigation</summary>
	[PublishedContentModel("navigation")]
	public partial class Navigation : PublishedContentModel, INavigation
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "navigation";
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

		public Navigation(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<Navigation, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}

		///<summary>
		/// Brand Link
		///</summary>
		[ImplementPropertyType("brandLink")]
		public Umbraco.Web.Models.Link BrandLink
		{
			get { return GetBrandLink(this); }
		}

		/// <summary>Static getter for Brand Link</summary>
		public static Umbraco.Web.Models.Link GetBrandLink(INavigation that) { return that.GetPropertyValue<Umbraco.Web.Models.Link>("brandLink"); }

		///<summary>
		/// Brand Logo
		///</summary>
		[ImplementPropertyType("brandLogo")]
		public IPublishedContent BrandLogo
		{
			get { return GetBrandLogo(this); }
		}

		/// <summary>Static getter for Brand Logo</summary>
		public static IPublishedContent GetBrandLogo(INavigation that) { return that.GetPropertyValue<IPublishedContent>("brandLogo"); }

		///<summary>
		/// Main Navigation
		///</summary>
		[ImplementPropertyType("mainNavigation")]
		public IEnumerable<Umbraco.Web.Models.Link> MainNavigation
		{
			get { return GetMainNavigation(this); }
		}

		/// <summary>Static getter for Main Navigation</summary>
		public static IEnumerable<Umbraco.Web.Models.Link> GetMainNavigation(INavigation that) { return that.GetPropertyValue<IEnumerable<Umbraco.Web.Models.Link>>("mainNavigation"); }

		///<summary>
		/// siteTitle
		///</summary>
		[ImplementPropertyType("siteTitle")]
		public string SiteTitle
		{
			get { return GetSiteTitle(this); }
		}

		/// <summary>Static getter for siteTitle</summary>
		public static string GetSiteTitle(INavigation that) { return that.GetPropertyValue<string>("siteTitle"); }
	}
}