using SchoolBusModel.Entitys.abstrcut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShcoolBusDataAccess.Repositoriess.Abstructs
{
    public interface IBaseRepositories<T> where T : BaseEntity, new()
    {

        List<T> GetAllEntity();
        void Save();
        void Add(T entity);
        void Delete(T entity);
        T GetEntity(int id);

    }
}
