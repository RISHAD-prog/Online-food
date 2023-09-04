using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Token
    {
        public int Id { get; set; }
        public System.DateTime CreationTime { get; set; }
        public System.DateTime ExpirationTime { get; set; }
        public string TKey { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
