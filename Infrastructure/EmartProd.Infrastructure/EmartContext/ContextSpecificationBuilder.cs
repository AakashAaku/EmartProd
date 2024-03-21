using EmartProd.Application.Specifications;
using EmartProd.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmartProd.Infrastructure.EmartContext
{
    public class ContextSpecificationBuilder<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> BuildQuery(IQueryable<TEntity> inputQuery,
        ISpecification<TEntity> Spec)
        {
            var query = inputQuery;
            if(Spec.Criteria !=null)
            {
                query = query.Where(Spec.Criteria);
            }

            query = Spec.Includes.Aggregate(query, (current,include)=> current.Include(include));
            return query;
        }
        
    }
}