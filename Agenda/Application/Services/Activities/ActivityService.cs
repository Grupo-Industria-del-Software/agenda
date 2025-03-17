using Application.DTOs.Activities;
using Application.DTOs.Auth;
using Application.DTOs.TypesDTOs;
using Application.Interfaces.Activities;
using Domain.AggregateRoots.Activities;
using Domain.Entities;
using Task = Domain.AggregateRoots.Activities.Task;


namespace Application.Services.Activities
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activityRepository;

        public ActivityService(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public async Task<IEnumerable<ActivityResponseDTO>> GetAllAsync()
        {
            var activities = await _activityRepository.GetAllAsync();
            return activities.Select(a => new ActivityResponseDTO
            {
                Id = a.Id,
                StartDateTime = a.StartDateTime,
                EndDateTime = a.EndDateTime,
                Title = a.Title,
                Description = a.Description,
                Finished = a.Finished,
                UserId = a.UserId,
                TypeId = a.TypeId,
                User = a.User != null ? new UserResponseDTO
                {
                    Id = a.User.Id,
                    FirstName = a.User.FirstName,
                    LastName = a.User.LastName
                } : null,
                Type = a.Type != null ? new TypeResponseDTO
                {
                    Id = a.Type.Id,
                    Name = a.Type.Name
                } : null,
                Tasks = a.Tasks.Select(t => new TaskResponseDTO
                {
                    Id = t.Id,
                    ActivityId = t.ActivityId,
                    Description = t.Description,
                    StartDateTime = t.StartDateTime,
                    EndDateTime = t.EndDateTime,
                    Finished = t.Finished
                }).ToList()
            });
        }

        public async Task<ActivityResponseDTO?> GetByIdAsync(int id)
        {
            var activity = await _activityRepository.GetByIdAsync(id);
            return activity == null ? null : new ActivityResponseDTO
            {
                Id = activity.Id,
                StartDateTime = activity.StartDateTime,
                EndDateTime = activity.EndDateTime,
                Title = activity.Title,
                Description = activity.Description,
                Finished = activity.Finished,
                UserId = activity.UserId,
                TypeId = activity.TypeId,
                User = activity.User != null ? new UserResponseDTO
                {
                    Id = activity.User.Id,
                    FirstName = activity.User.FirstName,
                    LastName = activity.User.LastName
                } : null,
                Type = activity.Type != null ? new TypeResponseDTO
                {
                    Id = activity.Type.Id,
                    Name = activity.Type.Name
                } : null,
                Tasks = activity.Tasks.Select(t => new TaskResponseDTO
                {
                    Id = t.Id,
                    ActivityId = t.ActivityId,
                    Description = t.Description,
                    StartDateTime = t.StartDateTime,
                    EndDateTime = t.EndDateTime,
                    Finished = t.Finished
                }).ToList()
            };
        }

        public async Task<ActivityResponseDTO> CreateAsync(ActivityRequestDTO dto)
        {
            var activity = new Activity
            {
                StartDateTime = null,
                EndDateTime = null,
                Title = dto.Title,
                Description = dto.Description,
                UserId = dto.UserId,
                TypeId = dto.TypeId,
                Finished = false,
                Tasks = dto.Tasks.Select(t => new Task
                {
                    Description = t.Description,
                    StartDateTime = null,
                    EndDateTime = null,
                    Finished = false
                }).ToList()
            };

            await _activityRepository.AddAsync(activity);

            return new ActivityResponseDTO
            {
                Id = activity.Id,
                StartDateTime = activity.StartDateTime,
                EndDateTime = activity.EndDateTime,
                Title = activity.Title,
                Description = activity.Description,
                Finished = activity.Finished,
                UserId = activity.UserId,
                TypeId = activity.TypeId,
                Tasks = activity.Tasks.Select(t => new TaskResponseDTO
                {
                    Id = t.Id,
                    ActivityId = t.ActivityId,
                    Description = t.Description,
                    StartDateTime = t.StartDateTime,
                    EndDateTime = t.EndDateTime,
                    Finished = t.Finished
                }).ToList()
            };
        }

        public async Task<bool> UpdateAsync(int id, ActivityRequestDTO dto)
        {
            var activity = await _activityRepository.GetByIdAsync(id);
            if (activity == null) return false;

            activity.Title = dto.Title;
            activity.Description = dto.Description;
            activity.TypeId = dto.TypeId;
            
            activity.Tasks.Clear();
            activity.Tasks.AddRange(dto.Tasks.Select(t => new Task
            {
                Description = t.Description,
                StartDateTime = null,
                EndDateTime = null,
                Finished = false
            }));

            return await _activityRepository.UpdateAsync(activity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _activityRepository.DeleteAsync(id);
        }

        public async Task<bool> StartTaskAsync(int activityId, int taskId)
        {
            var activity = await _activityRepository.GetByIdAsync(activityId);
            if (activity == null) return false;

            var task = activity.Tasks.FirstOrDefault(t => t.Id == taskId);
            if (task == null || task.StartDateTime != null) return false;

            var now = DateTime.UtcNow;
            if (activity.StartDateTime == null)
            {
                activity.StartDateTime = now;
            }
            task.StartDateTime = now;

            return await _activityRepository.UpdateAsync(activity);
        }

        public async Task<bool> FinishTaskAsync(int activityId, int taskId)
        {
            var activity = await _activityRepository.GetByIdAsync(activityId);
            if (activity == null) return false;

            var task = activity.Tasks.FirstOrDefault(t => t.Id == taskId);
            if (task == null || task.Finished) return false;

            task.EndDateTime = DateTime.UtcNow;
            task.Finished = true;

            if (activity.Tasks.All(t => t.Finished))
            {
                activity.Finished = true;
                activity.EndDateTime = DateTime.UtcNow;
            }

            return await _activityRepository.UpdateAsync(activity);
        }

        public async Task<bool> UpdateTaskAsync(int activityId, int taskId, TaskRequestDTO dto)
        {
            var activity = await _activityRepository.GetByIdAsync(activityId);
            if (activity == null) return false;

            var task = activity.Tasks.FirstOrDefault(t => t.Id == taskId);
            if (task == null) return false;

            if (dto.Description != null) task.Description = dto.Description;

            return await _activityRepository.UpdateAsync(activity);
        }

        public async Task<TaskResponseDTO> AddTaskToActivityAsync(int activityId, TaskRequestDTO dto)
        {
            var activity = await _activityRepository.GetByIdAsync(activityId);
            if (activity == null) throw new KeyNotFoundException("Actividad no encontrada");

            var newTask = new Task
            {
                Description = dto.Description,
                StartDateTime = null,
                EndDateTime = null,
                Finished = false
            };

            activity.Tasks.Add(newTask);
            await _activityRepository.UpdateAsync(activity);

            var taskResponse = new TaskResponseDTO
            {
                Id = newTask.Id,
                ActivityId = newTask.ActivityId,
                Description = newTask.Description,
                StartDateTime = newTask.StartDateTime,
                EndDateTime = newTask.EndDateTime,
                Finished = newTask.Finished
            };

            return taskResponse;
        }

        public async Task<bool> DeleteTaskFromActivityAsync(int activityId, int taskId)
        {
            var activity = await _activityRepository.GetByIdAsync(activityId);
            if (activity == null) return false;

            var task = activity.Tasks.FirstOrDefault(t => t.Id == taskId);
            if (task == null) return false;

            activity.Tasks.Remove(task);

            return await _activityRepository.UpdateAsync(activity);
        }
    }
}
