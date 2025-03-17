namespace Application.DTOs.Activities
{
    public class ActivityRequestDTO
    {
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int UserId { get; set; }
        public int TypeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Finished { get; set; }
        public List<TaskRequestDTO> Tasks { get; set; } = new();
    }
}
