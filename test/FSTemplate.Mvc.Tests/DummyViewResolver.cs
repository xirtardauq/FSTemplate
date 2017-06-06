using System;
using System.IO;

namespace FSTemplate.Mvc.Tests
{
    internal class DummyViewResolver : IViewResolver
    {
        public string Controller { get; private set; }
        public string View { get; private set; }

        public string Resolve(ViewResolverContext value)
        {
            Controller = value.controller;
            View = value.viewName;
            return Path.Combine(Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().Location), @"..\..\dummy.fsx");
        }
    }
}