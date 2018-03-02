using Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.IDAL
{
    public interface IHomeRepository
    {
        List<SysModule> GetMenuByPersonId(string moduleId);
    }
}
