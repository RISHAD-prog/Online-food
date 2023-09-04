using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class AuthRepo : Repos, IRepo<Token, string, Token>
    {
        public Token ADD(Token obj)
        {
            db.tokens.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }

        public bool Delete(string TKey)
        {
            var data = Get(TKey);
            if(data != null)
            {
                db.tokens.Remove(data);
                if(db.SaveChanges() > 0)
            {
                    return true;
                }
                return false;
            }
            return false;
        }

        public Token Get(string TKey)
        {
            return db.tokens.FirstOrDefault(x => x.TKey.Equals(TKey)); 
        }

        public List<Token> Get()
        {
            throw new NotImplementedException();
        }

        public Token Update(string id)
        {
            throw new NotImplementedException();
        }
    }
}
