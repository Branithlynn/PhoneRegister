using PhoneRegister.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneRegister.Repository;

namespace PhoneRegister.Services
{
    class AuthenticationService
    {
        public static User LoggedUser { get; private set; }

        public static void AuthenticateUser(string username, string password)
        {
            UsersRepository userRepo = new UsersRepository();
            AuthenticationService.LoggedUser = userRepo.GetByUserNameAndPassword(username, password);
        }

        public static Phones LoggedPhone { get; private set; }

        public static void AuthenticatePhone(Phones phone)
        {
            AuthenticationService.LoggedPhone = phone;
        }
    }
}
