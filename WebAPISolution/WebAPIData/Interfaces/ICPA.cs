using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIData.Interfaces
{
    public interface ICPA
    {
        CPA Insert(CPA cpa);
        List<CPA> GetList();
        CPA GetByID(long Id);
        CPA Update(CPA cpa);
        Boolean Delete(long id);
    }
}
