using System;
using NHibernate;

namespace Database.Repositories
{
    using Models;

    public class BaseRepository
    {
        static public bool Add(BaseModel obj)
        {
            if (!obj.isNewRecord)
            {
                return false;
            }
            using (ISession session = Helper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(obj);
                    transaction.Commit();
                }
            }
            return true;
        }

        static public bool Update(BaseModel obj)
        {
            if (obj.isNewRecord)
            {
                return false;
            }
            using (ISession session = Helper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(obj);
                    transaction.Commit();
                }
            }
            return true;
        }

        static public bool Delete(BaseModel obj)
        {
            if (obj.isNewRecord)
            {
                return false;
            }
            using (ISession session = Helper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(obj);
                    transaction.Commit();
                }
            }
            return true;
        }
    }
}
