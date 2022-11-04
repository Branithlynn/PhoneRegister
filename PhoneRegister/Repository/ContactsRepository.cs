using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneRegister.Entity;
using PhoneRegister.Services;
using PhoneRegister.SQLEntity;

namespace PhoneRegister.Repository
{
    class ContactsRepository
    {
        public void AddContact(Contacts contact)
        {
            MyDbContext myDbContext = new MyDbContext();
            myDbContext.Contact.Add(contact);
            myDbContext.SaveChanges();
        }
        public void DeleteContact(int ID)
        {
            MyDbContext myDbContext = new MyDbContext();

            Contacts contact = myDbContext.Contact.Find(ID);
            myDbContext.Contact.Remove(contact);
            myDbContext.SaveChanges();
        }
        public bool Permissions(int ID)
        {
            MyDbContext myDbContext = new MyDbContext();
            Contacts contact = myDbContext.Contact.Find(ID);
            if (contact.ParentID == AuthenticationService.LoggedPhone.ID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Contacts GetByID(int ID)
        {
            MyDbContext myDbContext = new MyDbContext();
            Contacts contact = myDbContext.Contact.Find(ID);
            return contact;
        }
        public void EditContact(Contacts contact, string name)
        {
      
            Contacts updatedContact = contact;
            updatedContact.ContactName = name;
            DeleteContact(contact.ID);
            AddContact(updatedContact);

        }
        public List<Contacts> GetAllContacts()
        {
            MyDbContext myDbContext = new MyDbContext();
            List<Contacts> contacts = myDbContext.Contact.ToList<Contacts>();
            List<Contacts> result = new List<Contacts>();
            foreach (Contacts contact in contacts)
            {
                if (contact.ParentID == AuthenticationService.LoggedPhone.ID)
                {
                    result.Add(contact);
                }
            }
            return result;
        }
        public void DeleteAllContacts()
        {
            List<Contacts> contacts = GetAllContacts();
            foreach (Contacts contact in contacts)
            {
                DeleteContact(contact.ID);
            }
        }
    }
}
