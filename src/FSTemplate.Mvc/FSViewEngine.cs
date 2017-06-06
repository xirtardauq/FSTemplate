using System;
using System.IO;
using System.Web.Mvc;

namespace FSTemplate.Mvc
{
    public class FSViewEngine : IViewEngine
    {
        public ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
        {
            throw new NotImplementedException();
        }

        public ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            var context = new ViewResolverContext(
                                controllerContext.RequestContext.RouteData.Values["controller"].ToString(), 
                                viewName);

            string path = Config.ConfigStore.GetInstance().ViewResolver.Resolve(context);
            return new ViewEngineResult(new FSTemplateView(path, useCache), this);
        }

        public void ReleaseView(ControllerContext controllerContext, IView view)
        {            
        }
    }
}
