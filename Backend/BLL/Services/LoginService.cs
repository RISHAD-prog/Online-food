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
    public class LoginService
    {
        public static TokenDTO AuthUsers(string email, string password)
        {
            var checkDB = DataAccessFactory.CheckUser().AuthUser(email, password);

            if (checkDB != null)
            {
                var token = new Token();
                token.Email = email;
                token.CreationTime = DateTime.Now;
                token.ExpirationTime = DateTime.Now.AddHours(12);
                token.TKey = Guid.NewGuid().ToString();
                token.Role = "user";
                var AddUserToken = DataAccessFactory.AccessUserToken().ADD(token);
                if(AddUserToken != null)
                {
                    var config = Service.OneTimeMapping<Token, TokenDTO>();
                    var mapper = new Mapper(config);
                    var data = mapper.Map<Token>(AddUserToken);
                }
                return null;
            }
            return null;
        }

        public static bool IsValid(string token)
        {
            var UserToken = DataAccessFactory.AccessUserToken().Get(token);
            if (UserToken.ExpirationTime < DateTime.Now)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static TokenDTO Logout(string token)
        {
            var UserToken = DataAccessFactory.AccessUserToken().Get(token);
            if(UserToken != null)
            {
                
                var Data=DataAccessFactory.AccessUserToken().Delete(token);
                var config = Service.OneTimeMapping<Token, TokenDTO>();
                var mapper = new Mapper(config);
                return mapper.Map<TokenDTO>(Data);
            }
            return null;
        }
    }
}
