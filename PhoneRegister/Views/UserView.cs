using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneRegister.Tools;

namespace PhoneRegister.Views
{
    class UserView
    {
        public void Show()
        {
            while (true)
            {
                UserViewEnum choice = RenderMenu();

                try
                {
                    switch (choice)
                    {
                        case UserViewEnum.PhonesView:
                            {
                                PhoneView phoneView = new PhoneView();
                                phoneView.Show();
                                break;
                            }
                        case UserViewEnum.Exit:
                            {
                                return;
                            }
                    }
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                    Console.ReadKey(true);
                }
            }
        }

        private UserViewEnum RenderMenu()
        {
            while (true)
            {

                Console.Clear();
                Console.WriteLine("UserView :");
                Console.WriteLine("[P]honeView");
                Console.WriteLine("E[X]it");


                string choice = Console.ReadLine();
                switch (choice.ToUpper())
                {

                    case "P":
                        {
                            return UserViewEnum.PhonesView;
                        }
                    case "X":
                        {
                            return UserViewEnum.Exit;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid choice.");
                            Console.ReadKey(true);
                            break;
                        }
                }
            }
        }
    }
}
