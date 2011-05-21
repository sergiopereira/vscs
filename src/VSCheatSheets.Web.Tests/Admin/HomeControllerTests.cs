#region Copyright notice
// Copyright (c) 2011, Sergio Pereira, sergiopereira.com
// 
// The author doesn't speak legalese and doesn't want to even hear about it.
// Anyone is free to use this code as they wish as long as they assume total responsibility of such use and any damages caused by it.
// The author doesn't even care if you steal this code and never give proper attribution. 
// 
// THIS CODE WANTS TO BE FREE
#endregion

using System.Web.Mvc;
using NUnit.Framework;
using VSCheatSheets.Web.Areas.Site.Controllers;

namespace VSCheatSheets.Web.Tests.Admin {

	[TestFixture]
	public class HomeControllerTests {

		[Test]
		public void Index_UsesDefaultView() {
			var ctrl = new HomeController();
			var result = ctrl.Index() as ViewResult;
			
			Assert.AreEqual("", result.ViewName);
		}


	}
}