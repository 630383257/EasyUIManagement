using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management.Models;
namespace Management.IDAL
{
    public interface ISysLogRespository
    {
        int Create(SysLog sysLog);
        void Delete(ManagementSystemEntities db, string[] deleteCollection);
        IQueryable<SysLog> GetList(ManagementSystemEntities db);
        SysLog Get(string id);
    }
}
