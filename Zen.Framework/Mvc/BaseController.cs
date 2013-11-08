using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Zen.Framework.Mvc
{
    public abstract class BaseController : Controller
    {
        /// <summary>
        /// 指定返回的View
        /// </summary>
        /// <param name="viewName"></param>
        /// <returns></returns>
        public ViewResult ZenView(string viewName)
        {
            return base.View(
                string.Format(
                    "~/Areas/{0}/Views/{1}.cshtml",
                    GetType().Namespace.Split('.').Last(t => t != "Controllers"),
                    viewName));
        }

        /// <summary>
        /// 按Controller名返回View
        /// </summary>
        /// <returns></returns>
        public ViewResult ZenView()
        {
            return this.ZenView(
                GetType().Name.Replace("Controller", string.Empty));
        }

    }
}
