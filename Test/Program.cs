using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Database;
using Database.Models;
using Database.Repositories;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Helper.CreateIfNotExsit();

            UserRepository.Add(new User { Password = "test", Username = "test" });
            var user = new User { Password = "test2", Username = "test2" };
            UserRepository.Add(user);

            Console.WriteLine("Id: {0}", user.Id);

            user = UserRepository.GetById(1);
            Console.WriteLine("Name: {0}, Pass: {1}, Id: {2}", user.Username, user.Password, user.Id);
        }
    }
}
