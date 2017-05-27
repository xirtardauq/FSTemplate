using System;
using System.IO;
using System.Web.Mvc;

namespace FSTemplate.Mvc
{
    internal class FSTemplateView : IView
    {
        private string path;
        private FSTemplateRenderer renderer;

        public FSTemplateView(string path, bool useCache)
        {
            this.path = path;
            renderer = new FSTemplateRenderer(useCache);
        }

        public void Render(System.Web.Mvc.ViewContext viewContext, TextWriter writer)
        {
            var context = new ViewContext(viewContext.TempData, viewContext.ViewData, viewContext.ViewData.Model);
            var fileInfo = new FileInfo(path);
            var res = renderer.Render(fileInfo, context);
            var result = renderer.ResultOrThrow(res);

            writer.Write(result);
            writer.Close();
        }
    }
}