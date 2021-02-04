using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace tmherronProfessionalSite.Contracts.HeyCurator
{
    public interface IRepositoryBaseHC<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindAllByCondition(Expression<Func<T, bool>> expression);
        T FindById(string id);
        // Insert
        void Create(T entity);
        // Replace
        void Update(T entity);
        void Delete(T entity);

    }
}
