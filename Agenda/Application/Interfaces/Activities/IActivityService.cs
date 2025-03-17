using Application.DTOs.Activities;
using System.Threading.Tasks;

namespace Application.Interfaces.Activities
{
    public interface IActivityService
    {
        Task<IEnumerable<ActivityResponseDTO>> GetAllAsync();
        Task<ActivityResponseDTO?> GetByIdAsync(int id);
        Task<ActivityResponseDTO> CreateAsync(ActivityRequestDTO dto);
        Task<bool> UpdateAsync(int id, ActivityRequestDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<bool> StartTaskAsync(int activityId, int taskId);
        Task<bool> FinishTaskAsync(int activityId, int taskId);
        Task<bool> UpdateTaskAsync(int activityId, int taskId, TaskRequestDTO dto);
        Task<TaskResponseDTO> AddTaskToActivityAsync(int activityId, TaskRequestDTO dto);
        Task<bool> DeleteTaskFromActivityAsync(int activityId, int taskId);
    }
}
