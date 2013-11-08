using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using MvcContrib.PortableAreas;

namespace Zen.Framework.Mvc
{
    /// <summary>
    /// 支持MVC的嵌入资源路由
    /// </summary>
    public abstract class MvcRegistration : PortableAreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return GetType().Namespace.Split('.').Last();
            }
        }

        public override void RegisterArea(AreaRegistrationContext context, IApplicationBus bus)
        {
            //嵌入资源
            context.MapRoute(
                name: AreaName + "_ResourceRoute",
                url: AreaName + "/resource/{resourceName}",
                defaults: new { controller = "EmbeddedResource", action = "Index" },
                namespaces: new[] { "MvcContrib.PortableAreas" }
             );

            //Js脚本
            context.MapRoute(
                name: AreaName + "_Scripts",
                url: AreaName + "/Scripts/{resourceName}",
                defaults: new { controller = "EmbeddedResource", action = "Index", resourcePath = "Scripts" },
                namespaces: new[] { "MvcContrib.PortableAreas" }
            );

            //Styles脚本
            context.MapRoute(
                name: AreaName + "_Styles",
                url: AreaName + "/Styles/{resourceName}",
                defaults: new { controller = "EmbeddedResource", action = "Index", resourcePath = "Styles" },
                namespaces: new[] { "MvcContrib.PortableAreas" }
            );


            //View
            context.MapRoute(
                name: AreaName + "_Default",
                url: AreaName + "/{controller}/{action}"
                );
            RegisterAreaEmbeddedResources();
        }
    }
}
