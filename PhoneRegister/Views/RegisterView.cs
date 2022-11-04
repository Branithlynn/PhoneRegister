using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneRegister.Repository;
using PhoneRegister.Entity;

namespace PhoneRegister.Views
{
    class RegisterView
    {
        public void Register()
        {
            Console.Clear();
            Console.WriteLine("RegisterView");
            Console.Write("Username: ");
            string Username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            UsersRepository userRepository = new UsersRepository();
            if (userRepository.DoesUserNameExist(Username) == false)
            {
                User user = new User();
                user.Name = Username;
                user.Password = password;
                userRepository.Add(user);
                Console.WriteLine("Used has been registered");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey(true);
            }
            else
            {
                Console.WriteLine("User already exists.");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey(true);
            }
        }
    }
}
