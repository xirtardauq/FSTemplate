using System;
using System.IO;
using System.Web.Mvc;

namespace FSTemplate.Mvc
{
    public class FSViewEngine : IViewEngine
    {
        public FSViewEngine()
        {
            Config.ConfigStore.SetInstance(
                new Config.FSTemplateConfig(
                    new TemplateCache.DefaultCacheProvider(), ""));
        }

        public ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
        {
            throw new NotImplementedException();
        }

        public ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {            
            var template = $"~/Views/{controllerContext.RouteData.Values["controller"]}/{viewName}.fsx";
            var path = controllerContext.HttpContext.Server.MapPath(template);
            return new ViewEngineResult(new FSTemplateView(path, useCache), this);
        }

        public void ReleaseView(ControllerContext controllerContext, IView view)
        {            
        }
    }
}
