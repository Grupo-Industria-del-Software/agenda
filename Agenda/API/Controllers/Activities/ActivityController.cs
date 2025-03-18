using Application.DTOs.Activities;
using Application.Interfaces.Activities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Activities
{
        [ApiController]
        [Authorize]
        [Route("api/activity")]
        public class ActivityController : ControllerBase
        {
            private readonly IActivityService _activityService;

            public ActivityController(IActivityService activityService)
            {
                _activityService = activityService;
            }

            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var activities = await _activityService.GetAllAsync();
                return Ok(activities);
            }


            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                var activity = await _activityService.GetByIdAsync(id);
                return activity is null ? NotFound($"La actividad con ID {id} no existe.") : Ok(activity);
            }


            [HttpPost]
            public async Task<IActionResult> Create([FromBody] ActivityRequestDTO dto)
            {
                if (dto is null)
                    return BadRequest("Los datos de la actividad son requeridos.");

                var createdActivity = await _activityService.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = createdActivity.Id }, createdActivity);
            }


            [HttpPut("{id}")]
            public async Task<IActionResult> Update(int id, [FromBody] ActivityRequestDTO dto)
            {
                if (dto is null)
                    return BadRequest("Los datos de la actividad son requeridos.");

                var updated = await _activityService.UpdateAsync(id, dto);
                return updated ? NoContent() : NotFound($"El paquete con ID {id} no existe.");
            }


            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                var deleted = await _activityService.DeleteAsync(id);
                return deleted ? NoContent() : NotFound($"La actividad con ID {id} no existe.");
            }

            [HttpPatch("{activityId}/tasks/{taskId}/start")]
            public async Task<IActionResult> StartTask(int activityId, int taskId)
            {
                var success = await _activityService.StartTaskAsync(activityId, taskId);
                return success ? NoContent() : NotFound();
            }

            [HttpPatch("{activityId}/tasks/{taskId}/finish")]
            public async Task<IActionResult> FinishTask(int activityId, int taskId)
            {
                var success = await _activityService.FinishTaskAsync(activityId, taskId);
                return success ? NoContent() : NotFound();
            }

            [HttpPut("{activityId}/tasks/{taskId}")]
            public async Task<IActionResult> UpdateTask(
            int activityId,
            int taskId,
            [FromBody] TaskRequestDTO dto)
            {
                var success = await _activityService.UpdateTaskAsync(activityId, taskId, dto);
                return success ? NoContent() : NotFound();
            }

            [HttpPost("{activityId}/tasks")]
            public async Task<ActionResult<TaskResponseDTO>> AddTask(
            int activityId,
            [FromBody] TaskRequestDTO dto)
            {
                try
                {
                    var task = await _activityService.AddTaskToActivityAsync(activityId, dto);
                    return Ok(task);
                }
                catch (KeyNotFoundException ex)
                {
                    return NotFound(ex.Message);
                }
            }

            [HttpDelete("{activityId}/tasks/{taskId}")]
            public async Task<IActionResult> DeleteTask(int activityId, int taskId)
            {
                var success = await _activityService.DeleteTaskFromActivityAsync(activityId, taskId);
                return success
                    ? NoContent()
                    : NotFound($"La tarea con ID {taskId} en la actividad {activityId} no existe.");
            }
    }
}