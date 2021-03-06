﻿using System.Web.Mvc;
using System.Web.Routing;

namespace Beer
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			RouteConfig.RegisterRoutes(RouteTable.Routes);
		}

		protected void Application_Error()
		{
			var exception = Server.GetLastError();
			Server.ClearError();

			//_Logger.Error(exception);

			Response.Redirect("/Error");
		}
	}
}
