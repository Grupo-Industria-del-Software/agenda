using Application.Interfaces.Types;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TypeRepository : ITypeRepository
    {
        private readonly DbAgendaContext _context;

        public TypeRepository(DbAgendaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Domain.Entities.Type>> GetAllAsync()
        {
            return await _context.Types.ToListAsync();
        }

        public async Task<Domain.Entities.Type?> GetByIdAsync(int id)
        {
            return await _context.Types.FindAsync(id);
        }

        public async Task AddAsync(Domain.Entities.Type type)
        {
            _context.Types.Add(type);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Domain.Entities.Type type)
        {
            _context.Types.Update(type);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var type = await _context.Types.FindAsync(id);

            if (type == null)
                return false;

            _context.Types.Remove(type);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
