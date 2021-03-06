using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using MvcNavigation.Extensibility;
using MvcNavigation.IntegrationTests.Controllers;

namespace MvcNavigation.IntegrationTests
{
	public class ShopNode<TController, TAreaRegistration> : DynamicNode<TController, TAreaRegistration> where TController : IController where TAreaRegistration : AreaRegistration
	{
		public ShopNode(Expression<Action<TController>> action) : base(action)
		{
		}

		public ShopNode(Expression<Action<TController>> action, string title) : base(action, title)
		{
		}

		public override IList<INode> CreateChildNodes()
		{
			return new List<INode>
			{
				new Node<ProductController, ShopAreaRegistration>(c => c.Category(1), title: "Category 1 (dynamic)"),
				new Node<ProductController, ShopAreaRegistration>(c => c.Category(2), title: "Category 2 (dynamic)"),
				new Node<ProductController, ShopAreaRegistration>(c => c.Category(3), title: "Category 3 (dynamic)")
			};
		}
	}
}