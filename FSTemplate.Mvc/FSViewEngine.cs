using System.Web.Mvc;

namespace FSTemplate.Mvc
{
    public class FSViewEngine : IViewEngine
    {
        public ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
        {
            return new ViewEngineResult(new FSTemplateView(), this);
        }

        public ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            return new ViewEngineResult(new FSTemplateView(), this);
        }

        public void ReleaseView(ControllerContext controllerContext, IView view)
        {
        }
    }
}
