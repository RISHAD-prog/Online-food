using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class RegistrationRepo : Repos, IRepo<Registration, int, Registration>, Authentication<Registration>, IAdminInterface<Registration,int,Registration>
    {
        public Registration ADD(Registration obj)
        {
            db.registrations.Add(obj);
            if(db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }

        public Registration AdminUpdate(Registration obj, int id)
        {
            throw new NotImplementedException();
        }

        public Registration AuthUser(string email, string pass)
        {
            var data = db.registrations.FirstOrDefault(x => x.Email.Equals(email) && x.Password.Equals(pass));
            return data;
        }

        
        public bool Delete(int id)
        {
            var data = Get(id);
            db.registrations.Remove(data);
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }


        public bool existingUser(Registration user)
        {
            var data = db.registrations.FirstOrDefault(x => x.Email.Equals(user.Email) && x.Password.Equals(user.Password));
            return data != null;
        }

        public Registration Get(int id)
        {
            return db.registrations.Find(id);
        }

        public List<Registration> Get()
        {
            return db.registrations.ToList();
        }

        public Registration Update(Registration registration)
        {
            var data = Get(registration.ID);
            db.Entry(data).CurrentValues.SetValues(registration);
            if (db.SaveChanges() > 0)
            {
                return registration;
            }
            return null;
        }
    }
}
