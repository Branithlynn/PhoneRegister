using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneRegister.Entity;
using PhoneRegister.Repository;
using PhoneRegister.Services;
using PhoneRegister.Views;

namespace PhoneRegister
{
    class Program
    {
        static void Main(string[] args)
        {
            while (AuthenticationService.LoggedUser == null)
            {
                Console.Clear();
                Console.WriteLine("Main menu:");
                Console.WriteLine("[R]egister");
                Console.WriteLine("[L]ogin");
                string userChoice = Console.ReadLine();
                switch (userChoice.ToUpper())
                {
                    case "R":
                        {
                            RegisterView registerView = new RegisterView();
                            registerView.Register();
                            break;
                        }
                    case "L":
                        {
                            LoginView loginView = new LoginView();
                            loginView.Login();
                            UserView userView = new UserView();
                            userView.Show();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Wrong Choice!");
                            Console.ReadKey(true);
                            break;
                        }
                }
            }
        }
    }
}
