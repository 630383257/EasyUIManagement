using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management.IDAL;
using Management.Models;

namespace Management.DAL
{
    public class SysLogRespository : IDisposable, ISysLogRespository
    {
        public int Create(SysLog sysLog)
        {
            using (ManagementSystemEntities db = new ManagementSystemEntities())
            {
                db.SysLog.Add(sysLog);
                return db.SaveChanges();
            }
        }

        public void Delete(ManagementSystemEntities db, string[] deleteCollection)
        {
            db.SysLog.RemoveRange(db.SysLog.Where(e => deleteCollection.Contains(e.Id)));
        }

        public void Dispose()
        {
        }

        public SysLog Get(string id)
        {
            using (ManagementSystemEntities db = new ManagementSystemEntities())
            {
                return db.SysLog.SingleOrDefault(e => e.Id == id);
            }
        }

        public IQueryable<SysLog> GetList(ManagementSystemEntities db)
        {
            return db.SysLog.AsQueryable();
        }
    }
}
