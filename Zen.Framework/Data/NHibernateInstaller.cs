using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Zen.Framework.Data
{
    public class NHibernateInstaller
    {
        //数据库连接字符串
        private readonly string connectionString =
            System.Configuration.ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;

        //配置
        private NHibernate.Cfg.Configuration GetConfiguration()
        {
            NHibernate.Cfg.Configuration cfg = FluentNHibernate.Cfg.Fluently.Configure()

                                   .Database(FluentNHibernate.Cfg.Db.OracleClientConfiguration.Oracle10
                                       .Dialect<NHibernate.Dialect.Oracle10gDialect>()
                                       .Driver<NHibernate.Driver.OracleClientDriver>()
                                       .QuerySubstitutions("true 1, false 0, yes 'Y', no 'N'")
                                       .UseOuterJoin()
                                       .IsolationLevel(System.Data.IsolationLevel.ReadCommitted)
                                       .ConnectionString(connectionString))

                                   .ProxyFactoryFactory<NHibernate.Bytecode.DefaultProxyFactoryFactory>()

                                   .Mappings(m => m.FluentMappings
                                       .AddFromAssembly(Assembly.Load("OIT.OA.Infrastructure.Data"))
                                       .AddFromAssembly(Assembly.Load("OIT.SNCS.Infrastructure.Data"))
                                      )

                                   .BuildConfiguration();
            
            return cfg;
        }
    }
}
