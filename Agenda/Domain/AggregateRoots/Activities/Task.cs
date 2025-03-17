using Domain.Common;

namespace Domain.AggregateRoots.Activities
{
    public class Task : Entity
    {
        public int ActivityId { get; set; }
        public Activity? Activity { get; set; } 
        public string Description { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public bool Finished { get; set; } = false; 
    }
}