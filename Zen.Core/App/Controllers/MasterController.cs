using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zen.Framework.Mvc;

namespace Zen.Core.App.Controllers
{
    public class MasterController : BaseController
    {
        public new ActionResult View()
        {
            return ZenView();
        }

    }
}
