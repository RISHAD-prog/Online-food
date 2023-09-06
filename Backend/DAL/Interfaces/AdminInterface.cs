using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAdminInterface<CLASS, ID, RETURNTYPE>
    {
        CLASS AdminUpdate(RETURNTYPE obj, ID id);
    }
}
