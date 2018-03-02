using Management.Common;
using Management.IBLL;
using Management.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Attributes;
using Management.Models;
namespace Management.BLL
{
    public class SysLogBLL:ISysLogBLL
    {
        [Dependency]
        public ISysLogRespository logRepository { get; set; }


        public List<SysLog> GetList(ref GridPager pager, string queryStr)
        {
            ManagementSystemEntities db = new ManagementSystemEntities();
            List<SysLog> query = null;
            IQueryable<SysLog> list = logRepository.GetList(db);
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                list = list.Where(a => a.Message.Contains(queryStr) || a.Module.Contains(queryStr));
                pager.totalRows = list.Count();
            }
            else
            {
                pager.totalRows = list.Count();
            }

            if (pager.order == "desc")
            {
                query = list.OrderByDescending(c => c.CreateTime).Skip((pager.page - 1) * pager.rows).Take(pager.rows).ToList();
            }
            else
            {
                query = list.OrderBy(c => c.CreateTime).Skip((pager.page - 1) * pager.rows).Take(pager.rows).ToList();
            }


            return query;
        }
        public SysLog GetById(string id)
        {
            return logRepository.Get(id);
        }
    }
}
