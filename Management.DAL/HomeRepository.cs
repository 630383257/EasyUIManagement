using Management.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management.Models;
namespace Management.DAL
{
    public class HomeRepository : IHomeRepository, IDisposable
    {

        public List<SysModule> GetMenuByPersonId(string moduleId)
        {
            using (var db = new ManagementSystemEntities())
            {
                var menus =
                (
                    from m in db.SysModule
                    where m.ParentId == moduleId
                    where m.Id != "0"
                    select m
                          ).Distinct().OrderBy(a => a.Sort).ToList();
                return menus;
            }
        }


        public void Dispose()
        {

        }
    }
}
