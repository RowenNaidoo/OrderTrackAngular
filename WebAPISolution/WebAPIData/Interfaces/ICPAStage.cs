using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIData.Interfaces
{
    public interface ICPAStage
    {
        CPAStage Insert(CPAStage cpastage);
        List<CPAStage> GetList();
        CPAStage GetByID(long Id);
        CPAStage Update(CPAStage cpastage);
        Boolean Delete(long id);
    }
}
