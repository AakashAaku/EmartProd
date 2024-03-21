using EmartProd.Application.Interfaces;
using EmartProd.Application.Specifications;
using EmartProd.Domain.Entities;
using EmartProd.Infrastructure.EmartContext;
using Microsoft.EntityFrameworkCore;

namespace EmartProd.Infrastructure.Repositories
{

    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly EmartProdContext _context;
        public GenericRepository(EmartProdContext context)
        {
               this._context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
            return await  ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> GetListAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> specification)
        {
           return ContextSpecificationBuilder<T>.BuildQuery(_context.Set<T>().AsQueryable(),specification);
        }
    }
}