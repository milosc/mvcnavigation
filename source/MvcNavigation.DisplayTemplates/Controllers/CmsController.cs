﻿using System.Web.Mvc;

namespace MvcNavigation.IntegrationTests.Controllers
{
	public class CmsController : Controller
	{
		public ActionResult Dashboard()
		{
			return View();
		}

		public ActionResult Pages()
		{
			return View();
		}

		public ActionResult Users()
		{
			return View();
		}
	}
}