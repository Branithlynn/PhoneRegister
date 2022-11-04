using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneRegister.Entity;
using PhoneRegister.Tools;
using PhoneRegister.Services;
using PhoneRegister.Views;
using PhoneRegister.Repository;

namespace PhoneRegister.Views
{
    class PhoneManagementView
    {
        public void Show()
        {
            while (true)
            {
                PhoneManagementViewEnum choice = RenderMenu();

                try
                {
                    switch (choice)
                    {
                        case PhoneManagementViewEnum.AddContact:
                            {
                                AddContact();
                                break;
                            }
                        case PhoneManagementViewEnum.SeeMyContacts:
                            {
                                Console.Clear();
                                ShowAll();
                                Console.Write("Press any key to continue: ");
                                Console.ReadKey(true);
                                break;
                            }
                        case PhoneManagementViewEnum.EditContact:
                            {
                                EditContact();
                                break;
                            }
                        case PhoneManagementViewEnum.DeleteContact:
                            {
                                DeleteContact();
                                break;
                            }
                        case PhoneManagementViewEnum.DeleteAllContacts:
                            {
                                DeleteAllContacts();
                                
                                break;
                            }
                        case PhoneManagementViewEnum.Exit:
                            {
                                PhoneView phoneView = new PhoneView();
                                phoneView.Show();
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

        private PhoneManagementViewEnum RenderMenu()
        {
            while (true)
            {

                Console.Clear();
                Console.WriteLine("PhoneManagementView :");
                Console.WriteLine("[A]dd Contact");
                Console.WriteLine("[D]elete Contact");
                Console.WriteLine("[C]hange Contact Name");
                Console.WriteLine("[S]ee my Contacts");
                Console.WriteLine("De[L]ete all Contacts");
                Console.WriteLine("E[X]it");


                string choice = Console.ReadLine();
                switch (choice.ToUpper())
                {

                    case "A":
                        {
                            return PhoneManagementViewEnum.AddContact;
                        }
                    case "D":
                        {
                            return PhoneManagementViewEnum.DeleteContact;
                        }
                    case "L":
                        {
                            return PhoneManagementViewEnum.DeleteAllContacts;
                        }
                    case "S":
                        {
                            return PhoneManagementViewEnum.SeeMyContacts;
                        }
                    case "C":
                        {
                            return PhoneManagementViewEnum.EditContact;
                        }
                    case "X":
                        {
                            return PhoneManagementViewEnum.Exit;
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
        public void AddContact()
        {
            Console.Clear();
            Console.WriteLine("Add contact: ");
            Console.Write("Contact Number: ");
            int number = Convert.ToInt32(Console.ReadLine());
            PhonesRepository phonesRepository = new PhonesRepository();
            if (phonesRepository.DoesPhoneExist(number))
            {
                Console.Write("Contact Name: ");
                string name = Console.ReadLine();
                Contacts contact = new Contacts();
                contact.ParentID = AuthenticationService.LoggedPhone.ID;
                contact.ContactName = name;
                contact.ContactNumber = number;
                ContactsRepository contactsRepository = new ContactsRepository();
                contactsRepository.AddContact(contact);
                Console.WriteLine("Contact added! ");
            }
            else
            {
                Console.WriteLine("Phone with this number doesn't exist");
            }
            Console.Write("Press any key to continue: ");
            Console.ReadKey(true);
        }
        public void ShowAll()
        {
            ContactsRepository contactsRepository = new ContactsRepository();
            List<Contacts> contacts = contactsRepository.GetAllContacts();
            foreach (Contacts contact in contacts)
            {
                Console.WriteLine("Contact ID: " + contact.ID+ ", Contact Name: "+ contact.ContactName+", Contact Number: "+ contact.ContactNumber);
                Console.WriteLine("---------------------------------------------------------------------------------");
            }
            
        }
        public void DeleteContact()
        {
            Console.Clear();
            ShowAll();
            Console.WriteLine("Delete Contact");
            Console.Write("Contact ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            ContactsRepository contactsRepository = new ContactsRepository();
            if (contactsRepository.Permissions(id))
            {
                contactsRepository.DeleteContact(id);
                Console.WriteLine("Contact deleted! ");
            }
            else
            {
                Console.WriteLine("Wrong ID! ");
            }
            Console.Write("Press any key to continue: ");
            Console.ReadKey(true);
        }
        public void EditContact()
        {
            Console.Clear();
            ShowAll();
            Console.WriteLine("Change Name: ");
            Console.Write("Contact ID");
            int id = Convert.ToInt32(Console.ReadLine());
            ContactsRepository contactsRepository = new ContactsRepository();
            if (contactsRepository.Permissions(id))
            {
                Contacts contact = contactsRepository.GetByID(id);
                Console.WriteLine("Current name: "+contact.ContactName);
                Console.Write("New name: ");
                string newName = Console.ReadLine();
                contactsRepository.EditContact(contact, newName);
                Console.WriteLine("Name changed to {"+ newName+"} .");
            }
            else
            {
                Console.WriteLine("Contact doesn't belong to this user.");
            }
            Console.Write("Press any key to continue: ");
            Console.ReadKey(true);
        }
        public void DeleteAllContacts()
        {
            Console.Clear();
            Console.WriteLine("Are you sure you want to delete your contacts? Y/N");
            string choice = Console.ReadLine();
            switch (choice.ToUpper())
            {
                case "Y":
                    {
                        ContactsRepository contactsRepository = new ContactsRepository();
                        contactsRepository.DeleteAllContacts();
                        Console.WriteLine("Contacts deleted! ");
                        break;
                    }
                case "N":
                    {
                        Console.WriteLine("Contacts not deleted");
                        Console.Write("Press any key to continue: ");
                        Console.ReadKey(true);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Wrong choice. ");
                        Console.Write("Press any key to continue: ");
                        Console.ReadKey(true);
                        break;
                    }
            }
        }
    }
}
