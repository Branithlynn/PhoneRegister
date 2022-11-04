using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneRegister.Entity;
using PhoneRegister.Repository;
using PhoneRegister.Services;
using PhoneRegister.Tools;

namespace PhoneRegister.Views
{
    class PhoneView
    {
        public void Show()
        {
            while (true)
            {
                PhoneViewEnum choice = RenderMenu();

                try
                {
                    switch (choice)
                    {
                        case PhoneViewEnum.AddPhone:
                            {
                                AddPhone();
                                break;
                            }
                        case PhoneViewEnum.DeletePhone:
                            {
                                DeletePhone();
                                break;
                            }
                        case PhoneViewEnum.SeeMyPhoes:
                            {
                                SeeMyPhones();
                                break;
                            }
                        case PhoneViewEnum.Exit:
                            {
                                return;
                            }
                        case PhoneViewEnum.PhoneManagement:
                            {
                                PhoneManagement();
                                break;
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

        private PhoneViewEnum RenderMenu()
        {
            while (true)
            {

                Console.Clear();
                Console.WriteLine("UserView :");
                Console.WriteLine("[A]dd Phone");
                Console.WriteLine("[D]elete Phone");
                Console.WriteLine("[P]hone Management");
                Console.WriteLine("[S]ee my Phones");
                Console.WriteLine("E[X]it");


                string choice = Console.ReadLine();
                switch (choice.ToUpper())
                {

                    case "A":
                        {
                            return PhoneViewEnum.AddPhone;
                        }
                    case "D":
                        {
                            return PhoneViewEnum.DeletePhone;
                        }
                    case "P":
                        {
                            return PhoneViewEnum.PhoneManagement;
                        }
                    case "S":
                        {
                            return PhoneViewEnum.SeeMyPhoes;
                        }
                    case "X":
                        {
                            return PhoneViewEnum.Exit;
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
        public void AddPhone()
        {
            Console.Clear();
            Console.WriteLine("Add Phone");
            Console.Write("Phone Number: ");
            int phoneNumber = Convert.ToInt32(Console.ReadLine());
            PhonesRepository phonesRepository = new PhonesRepository();
            if (phonesRepository.DoesPhoneExist(phoneNumber) == false)
            {
                Phones phone = new Phones();
                phone.ParentID = AuthenticationService.LoggedUser.ID;
                phone.PhoneNumber = phoneNumber;
                phonesRepository.Add(phone);
                Console.WriteLine("Phone added! ");
            }
            else
            {
                Console.WriteLine("Phone already exists.");
            }

            Console.Write("Press any key to continue: ");
            Console.ReadKey(true);
        }
        public void DeletePhone()
        {
            Console.Clear();
            Console.WriteLine("Delete Phone");
            Console.Write("Phone Number: ");
            int phoneNumber = Convert.ToInt32(Console.ReadLine());
            PhonesRepository phonesRepository = new PhonesRepository();
            Phones phone = phonesRepository.GetPhone(phoneNumber);
            if (phonesRepository.Permissions(phone))
            {
                phonesRepository.Delete(phone.ID);
                Console.WriteLine("Phone successfuly deleted ! ");
            }
            else
            {
                Console.WriteLine("Phone doesn't belong to this user.");
            }
            Console.Write("Press any key to continue: ");
            Console.ReadKey(true);
        }
        public void SeeMyPhones()
        {
            Console.Clear();
            PhonesRepository phonesRepository = new PhonesRepository();
            List < Phones > phones = phonesRepository.GetAll();
            foreach (Phones phone in phones)
            {
                Console.WriteLine("Phone ID: " + phone.ID+", Phone Owner ID: "+phone.ParentID+", Phone Number: "+ phone.PhoneNumber);
            }
            Console.Write("Press any key to continue: ");
            Console.ReadKey(true);
        }
        public void PhoneManagement()
        {
            Console.Clear();
            Console.WriteLine("PhoneManagement Login");
            Console.Write("Phone Number:");
            int number = Convert.ToInt32(Console.ReadLine());
            PhonesRepository phonesRepository = new PhonesRepository();
            try
            {
                Phones phone = phonesRepository.GetPhone(number);
                if (phonesRepository.Permissions(phone))
                {
                    AuthenticationService.AuthenticatePhone(phone);
                    PhoneManagementView phoneManagementView = new PhoneManagementView();
                    phoneManagementView.Show();
                }
                else
                {
                    Console.WriteLine("Phone doesn't belong to user or doesn't exist.");
                }

            }
            finally
            {
                Console.Write("Press any key to continue: ");
                Console.ReadKey(true);
            }
        }
    }
}
