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
            obj.BeforeValidate();
            if (!obj.isValid)
            {
                return false;
            }
            obj.AfterValidate();
            obj.BeforeCreate();
            obj.BeforeSave();
            using (ISession session = Helper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(obj);
                    transaction.Commit();
                }
            }
            obj.AfterSave();
            obj.AfterCreate();
            return true;
        }

        static public bool Update(BaseModel obj)
        {
            if (obj.isNewRecord)
            {
                return false;
            }
            obj.BeforeValidate();
            if (!obj.isValid)
            {
                return false;
            }
            obj.AfterValidate();
            obj.BeforeSave();
            using (ISession session = Helper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(obj);
                    transaction.Commit();
                }
            }
            obj.AfterSave();
            return true;
        }

        static public bool Delete(BaseModel obj)
        {
            if (obj.isNewRecord)
            {
                return false;
            }
            obj.BeforeDelete();
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
