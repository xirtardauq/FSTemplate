﻿using FSTemplate.Mvc;
using System.Web.Mvc;
using System.Web.Routing;

namespace FSTemplate.Sample.Mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            FSTemplateBootstrapper.Bootstrap();            
            ViewEngines.Engines.Add(new FSViewEngine());
        }
    }
}
