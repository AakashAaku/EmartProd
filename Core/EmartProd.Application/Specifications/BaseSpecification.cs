using System.Linq.Expressions;

namespace EmartProd.Application.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {
        }

        public BaseSpecification(Expression<Func<T,bool>> spec)
        {
           Criteria = spec;
        }

        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes {get;} = [];
    
        protected void AddInclude(Expression<Func<T,object>> includeSpec)
        {
            Includes.Add(includeSpec);
        } 
    }
}