namespace Application.DTOs.Activities
{
    public class TaskResponseDTO
    {
        public int Id { get; set; }
        public int ActivityId { get; set; }
        public string Description { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public bool Finished { get; set; }
        public ActivityResponseDTO? Activity { get; set; }
    }
}