using ISSTest.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSTest.Core.Repository
{
    public interface IRepository
    {
        List<IssModel> SaveIss(IssModel issModel);

        List<IssModel> GetAll();
    }
}
