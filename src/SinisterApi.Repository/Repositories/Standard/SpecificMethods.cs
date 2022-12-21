using SinisterApi.Domain.Entities.Interfaces;
using System.Linq.Expressions;

namespace SinisterApi.Repository.Repositories.Standard
{
    public abstract class SpecificMethods<TEntity> where TEntity : class, IIdentityEntity
    {
        #region ProtectedMethods
        protected abstract IQueryable<TEntity> GenerateQuery(Expression<Func<TEntity, bool>> filter = null,
                                                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                params string[] includeProperties);

        protected abstract IEnumerable<TEntity> GetYieldManipulated(IEnumerable<TEntity> entities, Func<TEntity, TEntity> DoAction);
        #endregion ProtectedMethods
    }
}
