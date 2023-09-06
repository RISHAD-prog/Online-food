using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class RegistrationService
    {
        public static RegistrationDTO Add(RegistrationDTO registration)
        {
            var config = Service.Mapping<RegistrationDTO, Registration>();
            var mapper = new Mapper(config);
            var data = mapper.Map<Registration>(registration);
            var checkDB = DataAccessFactory.CheckUser().existingUser(data);
            if(checkDB == true)
            {
                return null;
            }
            var add = DataAccessFactory.UserRegistration().ADD(data);
            if(add != null)
            {
                return mapper.Map<RegistrationDTO>(add);
            }
            return null;
        }
        public static UsersDTO GetUsers()
        {
            var data = DataAccessFactory.UserRegistration().Get();
            if(data != null)
            {
                var config = Service.OneTimeMapping<Registration, UsersDTO>();
                var mapper = new Mapper(config);
                return mapper.Map<UsersDTO>(data);
            }
            return null;
        }
        public static UsersDTO GetUsers(int id)
        {
            var data = DataAccessFactory.UserRegistration().Get(id);
            if (data != null)
            {
                var config = Service.OneTimeMapping<Registration, UsersDTO>();
                var mapper = new Mapper(config);
                return mapper.Map<UsersDTO>(data);
            }
            return null;
        }
        public static UsersDTO EditUserDeatails(UsersDTO users, int id)
        {
            var config = Service.OneTimeMapping<UsersDTO,Registration>();
            var mapper = new Mapper(config);
            var Userdetails= mapper.Map<Registration>(users);
            var data = DataAccessFactory.UserRegistration().Update(Userdetails, id);
            if(data != null)
            {
                return users;
            }
            return null;
        }
    }
}
