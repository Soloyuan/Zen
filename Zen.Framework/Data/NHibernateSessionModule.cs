using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Zen.Framework.Data
{
    public class NHibernateSessionModule : IHttpModule
    {
    //    private HttpApplication app;
       // private ISessionFactoryProvider sfp;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Init(HttpApplication context)
        {
            throw new NotImplementedException();
        }
    }
}
