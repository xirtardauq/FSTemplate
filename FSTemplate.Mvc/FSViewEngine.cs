using System.Web.Mvc;

namespace FSTemplate.Mvc
{
    public class FSViewEngine : IViewEngine
    {
        public ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
        {            
            return new ViewEngineResult(new FSTemplateView(""), this);
        }

        public ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {            
            var template = $"~/Views/{controllerContext.RouteData.Values["controller"]}/{viewName}.fsx";
            var path = controllerContext.HttpContext.Server.MapPath(template);
            return new ViewEngineResult(new FSTemplateView(path), this);
        }

        public void ReleaseView(ControllerContext controllerContext, IView view)
        {            
        }
    }
}
