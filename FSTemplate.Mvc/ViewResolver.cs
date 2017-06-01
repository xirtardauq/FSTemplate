using System.Web;

namespace FSTemplate.Mvc
{
    class ViewResolver : IViewResolver
    {
        private string viewPattern;

        public ViewResolver(string viewPattern)
        {
            this.viewPattern = viewPattern;
        }

        public string Resolve(ViewResolverContext resolverContext)
        {
            var templateUrl = Util.mapViewPath(viewPattern, resolverContext);
            return HttpContext.Current.Server.MapPath(templateUrl);
        }
    }
}
