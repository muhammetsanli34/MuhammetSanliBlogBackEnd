using Business.Abstract; 
using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new User { Email = "muhammetsanli34@gmail.com", FirstName = "Muhammet", LastName = "Şanlı" };
            IUserService userService = new UserManager(new EfUserDal());
            var result=userService.Add(user);
            Console.WriteLine(result.Message + " " + result.Success);
        }
    }
}
