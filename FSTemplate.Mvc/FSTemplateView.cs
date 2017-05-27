using System;
using System.IO;
using System.Web.Mvc;

namespace FSTemplate.Mvc
{
    internal class FSTemplateView : IView
    {
        private string path;
        private FSTemplateRenderer renderer;

        public FSTemplateView(string path)
        {
            this.path = path;
            renderer = new FSTemplateRenderer();
        }

        public void Render(System.Web.Mvc.ViewContext viewContext, TextWriter writer)
        {
            var context = new ViewContext(viewContext.TempData, viewContext.ViewData, viewContext.ViewData.Model);
            var res = renderer.Render(path, context);
            var result = renderer.ResultOrThrow(res);

            writer.Write(result);
            writer.Close();
        }
    }
}