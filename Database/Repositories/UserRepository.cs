using System;
using System.Linq;

using NHibernate;
using NHibernate.Linq;

using Database.Models;

namespace Database.Repositories
{
    public class UserRepository : BaseRepository
    {
        public static User GetById(Int64 id)
        {
            using (var session = Helper.OpenSession())
            {
                try
                {
                    var query = (from user in session.Query<User>() where user.Id == id select user).Single();
                    return query;
                }
                catch
                {
                    return null;
                }
            }
        }

        public static User GetByUsername(string username)
        {
            using (var session = Helper.OpenSession())
            {
                try
                {
                    var query = (from user in session.Query<User>() where user.Username == username select user).Single();
                    return query;
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
