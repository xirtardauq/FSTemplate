using FSTemplate;
using NUnit.Framework;
using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace FSTemplate.Mvc.Tests
{
    [TestFixture]
    public class Integration
    {
        [Test]
        public void Template_ShouldBeProperlyRendered_WhenValidParametersArePassed()
        {
            var engine = new FSViewEngine();
            var viewResolver = new DummyViewResolver();

            var routeData = new System.Web.Routing.RouteData();
            routeData.Values.Add("controller", "Some");
            var controllerContext = new ControllerContext { RouteData = routeData };

            Config.ConfigStore.SetInstance(
                new Config.FSTemplateConfig(
                    new TemplateCache.DefaultCacheProvider(),
                    viewResolver));

            var result = engine.FindView(controllerContext, "View", "", true);

            Assert.NotNull(result);

            var view = result.View;

            var stream = new MemoryStream();
            var textWriter = new StreamWriter(stream);

            view.Render(
                new System.Web.Mvc.ViewContext(controllerContext, new FSTemplateView("", true), new ViewDataDictionary(), new TempDataDictionary(), textWriter),
                textWriter);

            var res = new string(stream.ToArray().Select(Convert.ToChar).ToArray());

            Assert.AreEqual("<div>Hello World</div>", res);
        }
    }
}
