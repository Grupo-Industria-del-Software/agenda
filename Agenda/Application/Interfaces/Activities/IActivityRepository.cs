using Domain.AggregateRoots.Activities;
using Task = System.Threading.Tasks.Task;

namespace Application.Interfaces.Activities
{
    public interface IActivityRepository
    {
        Task<IEnumerable<Activity>> GetAllAsync();
        Task<Activity?> GetByIdAsync(int id);
        Task AddAsync(Activity activity);
        Task<bool> UpdateAsync(Activity activity);
        Task<bool> DeleteAsync(int id);
    }
}