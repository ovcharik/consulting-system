using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

using Database.Models;

namespace Database
{
    public class Helper
    {
        public Helper() { }

        private static ISessionFactory _sessionFactory;
        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    var conf = new Configuration();
                    conf.Configure();
                    conf.AddAssembly(typeof(User).Assembly);
                    _sessionFactory = conf.BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        public static void CreateDatabase()
        {
            var conf = new Configuration();
            conf.Configure();
            conf.AddAssembly(typeof(User).Assembly);
            var schema = new SchemaExport(conf);
            schema.Create(false, true);
        }

        public static bool isExist
        {
            get
            {
                return false;
            }
        }

        public static void CreateIfNotExsit()
        {
            if (!isExist)
            {
                CreateDatabase();
            }
        }
    }
}
