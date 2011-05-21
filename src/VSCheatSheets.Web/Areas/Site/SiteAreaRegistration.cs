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

namespace VSCheatSheets.Web.Areas.Site {
	public class SiteAreaRegistration : AreaRegistration {
		public override string AreaName {
			get {
				return "Site";
			}
		}

		public override void RegisterArea(AreaRegistrationContext context) {
			
			context.MapRoute(
				"Site_default",
				"{controller}/{action}/{id}",
				new { action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}
