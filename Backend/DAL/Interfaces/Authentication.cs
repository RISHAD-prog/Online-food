using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface Authentication<CLASS>
    {
        bool existingUser(CLASS user);
        CLASS AuthUser(string email, string pass);
    }
}
