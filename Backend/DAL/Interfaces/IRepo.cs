using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepo<CLASS,ID,RETURNTYPE>
    {
        CLASS Get(ID id);
        RETURNTYPE ADD(CLASS obj);
        List<CLASS> Get();
        RETURNTYPE Update(ID id);
        bool Delete();

    }
}
