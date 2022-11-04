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
    class PhonesRepository
    {
        public bool DoesPhoneExist(int PhoneNumber)
        {
            List<Phones> phones = GetAllExisting();
            foreach (Phones phone in phones)
            {
                if (phone.PhoneNumber == PhoneNumber)
                {
                    return true;
                }
            }
            return false;
        }
        public bool Permissions(Phones item)
        {
      
            if (item != null)
            {
                if (IsPlaceNull(item.ID) == false && item.ParentID == AuthenticationService.LoggedUser.ID)
                {
                    return true;
                }
            }
            return false;
           
        }
        public Phones GetPhone(int phoneNumber)
        {
            List<Phones> phones = GetAll();
            foreach (Phones phone in phones)
            {
                if (phone.PhoneNumber == phoneNumber)
                {
                    return phone;
                }
            }
            return null;
        }
        public List<Phones> GetAllExisting()
        {
            MyDbContext myDbContext = new MyDbContext();
            List<Phones> phones = myDbContext.Phone.ToList<Phones>();
          
            return phones;
        }
        public List<Phones> GetAll()
        {
            MyDbContext myDbContext = new MyDbContext();
            List<Phones> phones = myDbContext.Phone.ToList<Phones>();
            List<Phones> result = new List<Phones>();
            foreach (Phones phone in phones)
            {
                if (phone.ParentID == AuthenticationService.LoggedUser.ID)
                {
                    result.Add(phone);
                }
            }
            return result ;
        }
        public bool IsPlaceNull(int ID)
        {
            MyDbContext myDbContext = new MyDbContext();
            Phones phone = myDbContext.Phone.Find(ID);
            if (phone == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public void Add(Phones phone)
        {
            MyDbContext myDbContext = new MyDbContext();
            myDbContext.Phone.Add(phone);
            myDbContext.SaveChanges();
        }
        public void Delete(int ID)
        {
            MyDbContext myDbContext = new MyDbContext();
            Phones phone = myDbContext.Phone.Find(ID);
            ContactsRepository contactsRepository = new ContactsRepository();
            AuthenticationService.AuthenticatePhone(phone);
            contactsRepository.DeleteAllContacts();
            myDbContext.Phone.Remove(phone);
            myDbContext.SaveChanges();
        }
        
    }
}
