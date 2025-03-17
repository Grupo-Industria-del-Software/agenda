using Domain.AggregateRoots.Activities;
using Infrastructure.Persistence;
using Application.Interfaces.Activities;
using Microsoft.EntityFrameworkCore;
using Activity = Domain.AggregateRoots.Activities.Activity;
using Task = System.Threading.Tasks.Task;

namespace Infrastructure.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly DbAgendaContext _context;

        public ActivityRepository(DbAgendaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Activity>> GetAllAsync()
        {
            return await _context.Activities
                .Include(a => a.User)
                .Include(a => a.Type)
                .Include(a => a.Tasks)
                .ToListAsync();
        }

        public async Task<Activity?> GetByIdAsync(int id)
        {
            return await _context.Activities
                .Include(a => a.User)
                .Include(a => a.Type)
                .Include(a => a.Tasks)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task AddAsync(Activity activity)
        {
            _context.Activities.Add(activity);
            await _context.SaveChangesAsync();
        }


        public async Task<bool> UpdateAsync(Activity activity)
        {
            _context.Entry(activity).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var activity = await _context.Activities.FindAsync(id);
            if (activity is null) return false;

            _context.Activities.Remove(activity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}