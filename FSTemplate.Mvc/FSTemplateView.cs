using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using FSTemplate;

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

        public void Render(ViewContext viewContext, TextWriter writer)
        {
            var res = renderer.Render(path);
            writer.Write(res);
            writer.Close();
        }
    }
}