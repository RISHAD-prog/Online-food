using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class RegistrationRepo : Repos, IRepo<Registration, int, Registration>, Authentication<Registration>
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

        public Registration AuthUser(string email, string pass)
        {
            var data = db.registrations.FirstOrDefault(x => x.Email.Equals(email) && x.Password.Equals(pass));
            return data;
        }

        public bool Delete()
        {
            throw new NotImplementedException();
        }

        public bool existingUser(Registration user)
        {
            var data = db.registrations.FirstOrDefault(x => x.Email.Equals(user.Email) && x.Password.Equals(user.Password));
            return data != null;
        }

        public Registration Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Registration> Get()
        {
            throw new NotImplementedException();
        }

        public Registration Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
