using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Registration, int , Registration> UserRegistration()
        {
            return new RegistrationRepo();
        }
        public static Authentication<Registration> CheckUser()
        {
            return new RegistrationRepo();
        }
    }
}
