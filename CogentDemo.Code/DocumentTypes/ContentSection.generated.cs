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
	// Mixin content Type 1327 with alias "contentSection"
	/// <summary>Content Section</summary>
	public partial interface IContentSection : IPublishedContent
	{
		/// <summary>nestedContent</summary>
		IEnumerable<IPublishedContent> NestedContent { get; }
	}

	/// <summary>Content Section</summary>
	[PublishedContentModel("contentSection")]
	public partial class ContentSection : PublishedContentModel, IContentSection
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "contentSection";
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

		public ContentSection(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<ContentSection, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}

		///<summary>
		/// nestedContent
		///</summary>
		[ImplementPropertyType("nestedContent")]
		public IEnumerable<IPublishedContent> NestedContent
		{
			get { return GetNestedContent(this); }
		}

		/// <summary>Static getter for nestedContent</summary>
		public static IEnumerable<IPublishedContent> GetNestedContent(IContentSection that) { return that.GetPropertyValue<IEnumerable<IPublishedContent>>("nestedContent"); }
	}
}
