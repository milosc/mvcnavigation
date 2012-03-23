﻿// # Copyright © 2012, Arnold Zokas
// # All rights reserved. 

using System.Web.Mvc;
using Machine.Specifications;
using MvcNavigation.Configuration.Advanced;
using MvcNavigation.Specifications.SpecUtils;

namespace MvcNavigation.Specifications.HtmlHelperExtensionSpecs
{
	[Subject(typeof(HtmlHelperExtensions))]
	public class when_menu_is_requested
	{
		static MvcHtmlString menu;

		Because of = () =>
		{
			NavigationConfiguration.Initialise(
			                                   new Node<TestController>(c => c.RootAction(),
			                                                            new Node<TestController>(c => c.Action1()),
			                                                            new Node<TestController>(c => c.Action2())));

			RendererConfiguration.MenuRenderer = (html, model, maxLevels) =>
			{
				const string template = "<ul>@Model.Title</ul>";

				var executionResult = InMemoryRazorEngine.Execute(template, model, typeof(INode).Assembly);
				return new MvcHtmlString(executionResult.RuntimeResult);
			};

			var htmlHelper = new HtmlHelper(new ViewContext(), new ViewPage());
			menu = htmlHelper.Menu();
		};

		It should_generate_menu =
			() => menu.ToString().ShouldEqual("<ul>RootAction</ul>");
	}
}