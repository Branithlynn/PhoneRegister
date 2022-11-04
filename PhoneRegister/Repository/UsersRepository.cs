using PhoneRegister.Entity;
using PhoneRegister.SQLEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneRegister.Repository
{
    class UsersRepository
    {
        public User GetByUserNameAndPassword(string Name, string Password)
        {
            List<User> users = GetAll();
            foreach (User user in users)
            {
                if (user.Name == Name && user.Password == Password)
                {
                    return user;
                }
            }
            return null;
        }
        public bool DoesUserNameExist(string Name)
        {
            List<User> users = GetAll();
            foreach (User user in users)
            {
                if (user.Name == Name)
                {
                    return true;
                }
            }
            return false;
        }
        public List<User> GetAll()
        {
            MyDbContext userDomain = new MyDbContext();
            List<User> users = userDomain.Users.ToList<User>();
            return users;
        }
        public bool IsPlaceNull(int ID)
        {
            MyDbContext userDomain = new MyDbContext();
            User user = userDomain.Users.Find(ID);
            if (user == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Add(User user)
        {
            MyDbContext userDomain = new MyDbContext();
            userDomain.Users.Add(user);
            userDomain.SaveChanges();
        }
        public void Delete(int ID)
        {
            MyDbContext userDomain = new MyDbContext();
            if (IsPlaceNull(ID) == false)
            {
                User user = userDomain.Users.Find(ID);
                userDomain.Users.Remove(user);
                userDomain.SaveChanges();
            }
        }
    }
}
