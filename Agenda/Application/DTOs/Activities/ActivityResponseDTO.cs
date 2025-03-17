using Application.DTOs.TypesDTOs;
using Application.DTOs.Auth;

namespace Application.DTOs.Activities
{
    public class ActivityResponseDTO
    {
        public int Id { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public int UserId { get; set; }
        public int TypeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Finished { get; set; }
        public List<TaskResponseDTO> Tasks { get; set; } = new();
        public UserResponseDTO? User { get; set; }
        public TypeResponseDTO? Type { get; set; }
    }
}
