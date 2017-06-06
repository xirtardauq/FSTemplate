using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSTemplate.Mvc
{
    public class FSTemplateBootstrapper
    {
        public static void Bootstrap()
        {
            Config.ConfigStore.SetInstance(
                new Config.FSTemplateConfig(
                    new TemplateCache.DefaultCacheProvider(),
                    new ViewResolver("~/Views/{controller}/{view}.fsx")));
        }
    }
}
